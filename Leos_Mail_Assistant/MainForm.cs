using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading;
using System.Reflection;
using MarkupConverter;

/// <summary>
/// Created by Leo Taffazoli
/// A simple program that send Outlook email through a template.
/// 
/// Created: 25/01/2023
/// Updated: 02/02/2023
/// </summary>
namespace Leos_Mail_Assistant
{

    public partial class MainForm : Form
    {
        string bodyMessage = "";
        DataTable dtCutID = new DataTable();
        To_Form formTO = new To_Form();
        Help formHelp = new Help();
        EditTemplate formTemplate = new EditTemplate();
        MarkupConverter markupConverter = new MarkupConverter();
        List<String> fileLocation = new List<string>();


        //splittingBy.Items.Add("Scores");
        /*mvcheckedList.SetItemChecked(0, true);
                mvcheckedList.Items.Add("Valid N");
                mvcheckedList.SetItemChecked(1, true);
                mvcheckedList.Items.Add("StdDev");
                mvcheckedList.SetItemChecked(2, false);
                mvcheckedList.Items.Add("Std Loading");
                mvcheckedList.Items.Add("Unstd Weight");*/

        public MainForm()
        {
            InitializeComponent();
            downloadLogButton.Visible = false;
            SMPTBox.Visible = false;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (!useOutlook.Checked && !useSMPT.Checked)
            {
                MessageBox.Show("Please select either Outlook or SMPT", "Error");
                return;
            }

            listBox1.Items.Add("--- Starting Checking Information ---");
            listBox1.Items.Add("--- Time: " + DateTime.Now);
            listBox1.Refresh();
            string toWho = "", toWhere = "";

            //if(fromName.Text.ToString().Length == 0)
            //{
            //    toWho = "Name and stuff";
            //}
            //else
            //{
            //    toWho = fromName.Text.ToString();
            //}


            //Seperate this code so that it takes all of the contact in the list
            List<MailAddress> to = new List<MailAddress>();
            List<MailAddress> cc = new List<MailAddress>();
            List<string> URLS = new List<string>();
            List<string> toName = new List<string>();
            List<string> invalidAdresses = new List<string>();

            string checkIfItIsRight = "";
            bool isValid = true;
            bool shouldSendOut = true;
            int lengthofToList = SaveContacts.toList.Count();
            string[] toListDistinct = { };

            for (int i = 0; i < SaveContacts.toList.Count(); i++)
            {
                if (!SaveContacts.toList[i].Contains("|"))
                {
                    SaveContacts.toList[i] += " |";
                }

                //string cResond = SaveContacts.toList[i].Split('|')[0].Trim();
                int fResondLength = SaveContacts.toList[i].Split('|').Length - 1;
                string fResond = SaveContacts.toList[i].Split('|')[fResondLength].Trim();
                if(SaveContacts.toList[i].Split('|')[fResondLength].Trim().Length == 0)
                {
                    fResond = SaveContacts.toList[i].Split('|')[fResondLength - 1].Trim();
                }

                bool alreadyExist = toListDistinct.Contains(fResond);

                checkIfItIsRight = fResond;

                isValid = IsValidEmail(checkIfItIsRight);
                if (!isValid)
                {
                    lengthofToList--;
                    invalidAdresses.Add(checkIfItIsRight);
                    shouldSendOut = false;
                }
                else
                {
                    shouldSendOut = true;
                    //to.Add(new MailAddress(cResond, ""));
                }

                if (fResond.Length == 0)
                {
                    toWhere = "Anonymous@Nowhere.pleaseEnterRealAddress";
                }
                else
                {
                    toWhere = fResond;
                }
                MailAddress fromSender = new MailAddress(toWhere, toWho);
                if (SaveContacts.ccList != null)
                {
                    foreach (string correspond in SaveContacts.ccList)
                    {
                        checkIfItIsRight = correspond;
                        isValid = IsValidEmail(checkIfItIsRight);
                        if (!isValid)
                        {
                            invalidAdresses.Add(checkIfItIsRight);
                            shouldSendOut = false;
                        }
                        else
                        {
                            shouldSendOut = true;
                            cc.Add(new MailAddress(correspond, "Name and stuff"));
                        }
                    }
                }
                if (!shouldSendOut)
                {
                    listBox1.Items.Add("Error: Invalid adresses has been found!");
                    listBox1.Items.Add(lengthofToList + " out of " + SaveContacts.toList.Count() + " adresses where invalid.");
                    listBox1.Items.Add("The invalid adresses where:");
                    foreach (string x in invalidAdresses)
                    {
                        listBox1.Items.Add(x);
                    }
                    listBox1.Items.Add("Please only enter adresses in the To and CC lists.");
                }
                if (shouldSendOut)
                {
                    listBox1.Items.Add("All senders adresses are valid!");
                    //if (SaveContacts.urlList != null)
                    //{
                    //    foreach (string uniformResourceLocators in SaveContacts.urlList)
                    //    {
                    //        URLS.Add(uniformResourceLocators);
                    //    }
                    //}

                    //if (SaveContacts.toNameList != null)
                    //{
                    //    foreach (string yourName in SaveContacts.toNameList)
                    //    {
                    //        toName.Add(yourName);
                    //    }
                    //}

                    System.Windows.Controls.RichTextBox rtb = new System.Windows.Controls.RichTextBox();

                    string failSafe = bodyText.Rtf.Replace("\\par\r\n\\par\r\n", "\\par\r\n[RemoveLaterz]\\par\r\n");
                    failSafe = failSafe.Replace("\\line", "\\line[RemoveLaterz]");
                    failSafe = failSafe.Replace("\\par\r\n\\cf2\\b\\f1\\fs20\\par\r\n\\cf3\\b0\\f0\\fs24 ", "\\par\r\n\\cf2\\b\\f1\\fs20\\par\r\n[RemoveLaterz]\\cf3\\b0\\f0\\fs24");

                    string textContent = ConvertRtfToHtml(failSafe);

                    bodyMessage = textContent;

                    if (useOutlook.Checked)
                    {
                        string url = "";
                        string cName = "";
                        toWho = "";
                        if (SaveContacts.urlList != null)
                        {
                            if (i < SaveContacts.urlList.Count())
                            {
                                url = SaveContacts.urlList[i];
                            }
                        }
                        else
                        {
                            SaveContacts.urlList = new string[SaveContacts.toList.Count() + 1];
                        }
                        if (SaveContacts.toNameList != null)
                        {
                            if (i < SaveContacts.toNameList.Count())
                            {
                                if (!SaveContacts.toNameList[i].Contains("|"))
                                {
                                    SaveContacts.toNameList[i] += " |";
                                }
                                cName = SaveContacts.toNameList[i].Split('|')[0];
                                if (cName.Length <= 0)
                                {
                                    //cName = "You";
                                    cName = " ";
                                }
                                if (haveMailto.Checked)
                                {
                                    toWho = SaveContacts.toNameList[i].Split('|')[1].Trim();
                                    if (toWho.Length <= 2)
                                    {
                                        toWho = "Anonymous";
                                    }
                                }
                                else
                                {
                                    toWho = "";
                                }
                            }
                        }
                        //SendingEmailOutLook(fromSubject.Text, bodyMessage, URLS, toName, toWho, toWhere, to, cc);
                        SendingEmailOutLook(fromSubject.Text, bodyMessage, url, cName, toWho, toWhere, fResond, i, cc);

                    }
                    else if (useSMPT.Checked)
                    {
                        SendingEmailSMPT(fromSubject.Text, bodyMessage, URLS, toName, fromSender, to, cc);
                    }
                }
            }


            listBox1.Items.Add("--- Finished at " + DateTime.Now);
            downloadLogButton.Visible = true;
        }

        private string ConvertRtfToHtml(string rtfText)
        {
            var thread = new Thread(ConvertRtfInSTAThread);
            var threadData = new ConvertRtfThreadData { RtfText = rtfText };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(threadData);
            thread.Join();
            return threadData.HtmlText;
        }

        private void ConvertRtfInSTAThread(object rtf)
        {
            var threadData = rtf as ConvertRtfThreadData;
            threadData.HtmlText = markupConverter.ConvertRtfToHtml(threadData.RtfText);
        }

        private class ConvertRtfThreadData
        {
            public string RtfText { get; set; }
            public string HtmlText { get; set; }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //private void SendingEmailOutLook(string _subject, string body, List<string> _respondentURL, List<string> _respodentName,
        //    string _toWho, string _toWhere,
        //    List<MailAddress> _to,
        //    List<MailAddress> _cc, List<MailAddress> _bcc = null)
        private void SendingEmailOutLook(string _subject, string body, string _respondentURL, string _respodentName,
            string _toWho, string _toWhere,
            string _to, int iDontCare,
            List<MailAddress> _cc, List<MailAddress> _bcc = null)
        {
            //try
            //{
            List<string> invalidAdresses = new List<string>();
            bool shouldSendOut = true;
            string checkIfItIsRight = "";
            int lengthofToList = SaveContacts.toList.Count();
            bool isValid;

            listBox1.Items.Add("--- Starting Checking Further Information ---");
            listBox1.Items.Add("--- Time: " + DateTime.Now);
            listBox1.Refresh();

            if (haveMailto.Checked)
            {
                for (int i = 0; i < SaveContacts.toList.Count(); i++)
                {
                    if (SaveContacts.toList[i].Split('|')[1].Contains(_toWhere))
                    {
                        checkIfItIsRight = SaveContacts.toList[i].Split('|')[0].Trim();
                        isValid = IsValidEmail(checkIfItIsRight);
                        if (!isValid)
                        {
                            lengthofToList--;
                            invalidAdresses.Add(checkIfItIsRight);
                            shouldSendOut = false;
                        }
                    }
                }

            }
            if (!shouldSendOut)
            {
                listBox1.Items.Add("Error: Invalid adresses has been found!");
                listBox1.Items.Add(lengthofToList + " out of " + SaveContacts.toList.Count() + " adresses where invalid.");
                listBox1.Items.Add("The invalid adresses where:");
                foreach (string x in invalidAdresses)
                {
                    listBox1.Items.Add(x);
                }
                listBox1.Items.Add("Please only enter adresses in the To and CC lists.");
            }
            else
            {

                Outlook.Application app = new Outlook.Application();
                listBox1.Items.Add("--- Starting Sending Out ---");
                listBox1.Items.Add("--- Time: " + DateTime.Now);
                listBox1.Refresh();

                //To list should be for all email they can send the link to
                // for (int j = 0; j < _to.Count(); j++)
                // {
                //listBox1.Items.Add("Sending email to " + _to[j]);
                listBox1.Items.Add("Sending email to " + _to);
                Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);

                if (_subject.Contains("[CFIRSTNAME]"))
                {
                    _subject = _subject.Replace("[CFIRSTNAME]", _respodentName.Split(' ')[0]);
                }
                if (_subject.Contains("[CFULLNAME]"))
                {
                    _subject = _subject.Replace("[CFULLNAME]", _respodentName.TrimEnd());
                }

                mailItem.Subject = _subject;
                //mailItem.To = _to[j].ToString();
                mailItem.To = _to;
                //mailItem.SentOnBehalfOfName = _toWhere;
                //mailItem.Sender.Name = _toWho;
                if (fromName.Text.Length > 2)
                {
                    mailItem.SentOnBehalfOfName = fromName.Text;
                }
                else
                {
                    mailItem.SentOnBehalfOfName = app.Session.CurrentUser.Name;
                }
                // mailItem.SendUsingAccount.

                string mailtoo2 = "";


                //Mailto function starts here where it takes the template and transfer it
                if (haveMailto.Checked)
                {
                    //for (int i = 0; i < SaveContacts.toList.Count(); i++)
                    //{

                        if (SaveContacts.toList[iDontCare].Split('|')[1].Contains(_toWhere))
                        {
                            string emailforCostumersCostumers = "";
                            string nameforCostumersCostumers = "";
                            string urlforCostumersCostumers = "";

                            if (SaveContacts.urlList.Count() > SaveContacts.toList.Count())
                            {
                                SaveContacts.urlList[iDontCare] = "";
                            }

                            emailforCostumersCostumers = CV(SaveContacts.toList[iDontCare].Split('|')[0].Trim());
                            nameforCostumersCostumers = CV(SaveContacts.toNameList[iDontCare].Split('|')[0].Trim());
                            urlforCostumersCostumers = CV(SaveContacts.urlList[iDontCare].Replace("&", "%26"));

                            string excellentworkPanda = "<a href=\"mailto:{0}?subject=" + SaveContacts.mailSubTemplate
                                + "&Body=" + SaveContacts.mailBodyTemplate + "\">Send reminder to {6}</a><br>";

                            mailtoo2 += string.Format(excellentworkPanda,
                                    emailforCostumersCostumers,
                                    nameforCostumersCostumers.Split(' ')[0],
                                    urlforCostumersCostumers,
                                    _toWho.Split(' ')[0],
                                   nameforCostumersCostumers,
                                   _toWho,
                                   nameforCostumersCostumers);
                        }
                       
                   // }
                }
 //if (_respondentURL.Count > 0 && body.Contains("[URL]"))
                        //{
                        //    body = body.Replace("[URL]", _respondentURL[j]);
                        //}
                        //if (_respodentName.Count > 0 && body.Contains("[FNAME]"))
                        //{
                        //    body = body.Replace("[FNAME]", _respodentName[j]);
                        //}
                        if (body.Contains("[URL]"))
                        {
                            body = body.Replace("[URL]", _respondentURL + "<br>");
                        }
                        if (body.Contains("[MAILTOO]") && mailtoo2.Length > 3)
                        {
                            body = body.Replace("[MAILTOO]", mailtoo2);
                        }
                        if (body.Contains("[CFULLNAME]"))
                        {
                            body = body.Replace("[CFULLNAME]", _respodentName.TrimEnd());
                            body = body.Replace(" !", "!");
                        }
                        if (body.Contains("[CFIRSTNAME]"))
                        {
                            body = body.Replace("[CFIRSTNAME]", _respodentName.Split(' ')[0]);
                            body = body.Replace(" !", "!");
                        }
                        if (body.Contains("[FEMAIL]"))
                        {
                            //body = body.Replace("[FEMAIL]", _to[j].ToString());
                            body = body.Replace("[FEMAIL]", _to.ToString());
                        }
                        if (body.Contains("[PFIRSTNAME]"))
                        {
                            body = body.Replace("[PFIRSTNAME]", _toWho.Split(' ')[0]);
                            body = body.Replace(" !", "!");
                        }
                        if (body.Contains("[PFULLNAME]"))
                        {
                            body = body.Replace("[PFULLNAME]", _toWho);
                            body = body.Replace(" !", "!");
                        }
                        if (body.Contains("[OWNFIRSTNAME]"))
                        {
                            body = body.Replace("[OWNFIRSTNAME]", mailItem.SentOnBehalfOfName.Split(' ')[0]);
                            body = body.Replace(" !", "!");
                        }
                        if (body.Contains("[OWNFULLNAME]"))
                        {
                            body = body.Replace("[OWNFULLNAME]", mailItem.SentOnBehalfOfName);
                            body = body.Replace(" !", "!");
                        }
                        if (body.Contains("[SIG]"))
                        {
                            string readMySignature = ReadSignature();
                            body = body.Replace("[SIG]", readMySignature);
                        }

                        //string dummy = mailItem.HTMLBody;
                        //mailItem.HTMLBody = mailItem.HTMLBody.Replace("<!-- Converted from text/plain format -->",
                        //                                               "<table cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#F9F9F9\">" + body.Replace("[RemoveLaterz]", "<br>")) + "<br>" + readMySignature + "</table>";
                        mailItem.HTMLBody = mailItem.HTMLBody.Replace("<!-- Converted from text/plain format -->",
                                                                       body.Replace("[RemoveLaterz]", "<br>"));

                        if (fileLocation.Count > 0)
                        {
                            listBox1.Items.Add("--- Adding Attachment");
                            listBox1.Refresh();
                            foreach (string yourFile in fileLocation)
                            {
                                mailItem.Attachments.Add(yourFile);//logPath is a string holding path to the log.txt file
                            }
                            listBox1.Items.Add("--- Attachment Added!");
                            listBox1.Refresh();
                        }
                        mailItem.Display(false);
                        mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
                        mailItem.Send();
                        listBox1.Items.Add("Successful sent the email!");
                        listBox1.Refresh();
             
                //mailItem.Delete();
                // }
            }
            //}
            //catch(Exception ex)
            //{
            //    listBox1.Items.Add("Error: Delivery failed. \n\n Either you or the outlook server denied to send it out");
            //    listBox1.Items.Add(ex);
            //    listBox1.Refresh();
            //}

        }

        public string CV(string para)
        {
            if (para == null)
            {
                para = "";
            }
            return para;
        }

        /// <summary>
        /// Sending Email through SMPT
        /// </summary>
        /// <param name="helpMessage"></param>
        private void SendingEmailSMPT(string _subject, string body, List<string> _respondentURL, List<string> _respodentName, MailAddress _from,
            List<MailAddress> _to,
            List<MailAddress> _cc, List<MailAddress> _bcc = null)
        {
            listBox1.Items.Add("--- Starting Sending Out ---");
            listBox1.Items.Add("--- Time: " + DateTime.Now);
            listBox1.Refresh();
            for (int j = 0; j < _to.Count(); j++)
            {
                listBox1.Items.Add("Sending email to " + _to[j]);
                string Text = "";
                string theHost = "";
                MailMessage msgMail;
                Text = body;
                if (_respondentURL.Count > 0 && Text.Contains("[URL]"))
                {
                    Text = Text.Replace("[URL]", _respondentURL[j]);
                }
                if (_respodentName.Count > 0 && Text.Contains("[FNAME]"))
                {
                    Text = Text.Replace("[FNAME]", _respodentName[j]);
                }
                if (Text.Contains("[FEMAIL]"))
                {
                    Text = Text.Replace("[FEMAIL]", _to[j].ToString());
                }
                msgMail = new MailMessage();
                msgMail.From = _from;
                msgMail.To.Add(_to[j]);
                foreach (MailAddress addr in _cc)
                {
                    msgMail.CC.Add(addr);
                }
                if (_bcc != null)
                {
                    foreach (MailAddress addr in _bcc)
                    {
                        msgMail.Bcc.Add(addr);
                    }
                }
                msgMail.Subject = _subject;
                msgMail.Body = Text;
                msgMail.IsBodyHtml = true;
                if (fileLocation.Count > 0)
                {
                    listBox1.Items.Add("--- Adding Attachment");
                    listBox1.Refresh();
                    foreach (string yourFile in fileLocation)
                    {
                        Attachment data = new Attachment(yourFile);
                        msgMail.Attachments.Add(data);
                    }
                    listBox1.Items.Add("--- Attachment Added!");
                    listBox1.Refresh();
                }

                theHost = changeSMTP.Text;
                string testAgainSMPT = "";
                string[] SMTPList = new string[] { theHost,
                    "smtp.mail.yahoo.co.uk"};
                foreach (string s in SMTPList)
                {
                    testAgainSMPT = s;
                    try
                    {
                        SmtpClient mailClient = new SmtpClient(s);
                        mailClient.Send(msgMail);
                        msgMail.Dispose();
                        listBox1.Items.Add("Successful sent the email!");
                        listBox1.Refresh();
                        break;
                    }
                    catch (SmtpFailedRecipientsException ex)
                    {
                        for (int i = 0; i < ex.InnerExceptions.Length; i++)
                        {
                            SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                            if (status == SmtpStatusCode.MailboxBusy ||
                                status == SmtpStatusCode.MailboxUnavailable)
                            {
                                listBox1.Items.Add("Error: Delivery failed");
                                listBox1.Items.Add("Retrying in 5 seconds.");
                                listBox1.Refresh();
                                System.Threading.Thread.Sleep(5000);
                                SmtpClient mailClient = new SmtpClient(testAgainSMPT);
                                mailClient.Send(msgMail);
                                msgMail.Dispose();
                            }
                            else
                            {
                                listBox1.Items.Add("Failed to deliver message to " +
                                    ex.InnerExceptions[i].FailedRecipient);
                                msgMail.Dispose();
                                listBox1.Refresh();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        listBox1.Items.Add("Error: " + ex.Message);
                        listBox1.Items.Add("Failed sending email to " + _to[j] + " with " + s);
                        msgMail.Dispose();
                        listBox1.Refresh();
                        /*MessageBox.Show("Error: The Host adress '" + theHost
                            + "' didn't work. Please try this again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show("Error: " + ex.Message + "\n\nThis error happened when you where going through " +
                            _to[i] + "\n\n-Please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                    }
                }
            }
        }

        /// <summary>
        /// This Code gets your signature and add it to the mail.
        /// </summary>
        /// <returns></returns>
        private string ReadSignature()
        {
            string[] language = { "Signatures", "Signaturer", "Firmas", "Underskrifter", "Подписи" };
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\";
            string appDataDir = "";
            string signature = string.Empty;

            foreach (string cigg in language)
            {
                appDataDir = "";
                appDataDir = appData + cigg;
                DirectoryInfo diInfo = new DirectoryInfo(appDataDir);
                if (diInfo.Exists)
                {
                    FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

                    if (fiSignature.Length > 0)
                    {
                        StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                        signature = sr.ReadToEnd();
                        if (!string.IsNullOrEmpty(signature))
                        {
                            string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                            signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                        }
                    }

                }
            }
            return signature;
        }


        /// <summary>
        /// Loads Data from file and sees what method to use to seperate data
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <param name="fileNr"></param>
        private void LoadContentTable(String fileLocation)
        {
            //Cut ID
            /* filePath1.Text = fileLocation;
             dtCutID = ConvertToDataTable(fileLocation, "cutid");
             if (dtCutID == null)
                 filePath1.Text = "";*/

        }
        private void ToButton_Click(object sender, EventArgs e)
        {
            SaveContacts.gatherListMode = 0;
            if (SaveContacts.toList != null)
            {
                foreach (string s in SaveContacts.toList)
                {
                    SaveContacts.rtb.AppendText(s + "\n");
                }
                SaveContacts.toList = new string[0];
            }
            formTO.Show();
            formTO.Text = "Add or remove contact from list";
        }

        private void CCButton_Click(object sender, EventArgs e)
        {
            SaveContacts.gatherListMode = 1;
            if (SaveContacts.ccList != null)
            {
                foreach (string s in SaveContacts.ccList)
                {
                    SaveContacts.rtb.AppendText(s + "\n");
                }
                SaveContacts.ccList = new string[0];
            }
            formTO.Show();
            formTO.Text = "Add or remove contact from list";
        }

        private void URLButton_Click(object sender, EventArgs e)
        {
            SaveContacts.gatherListMode = 2;
            if (SaveContacts.urlList != null)
            {
                foreach (string s in SaveContacts.urlList)
                {
                    SaveContacts.rtb.AppendText(s + "\n");
                }
                SaveContacts.urlList = new string[0];
            }
            formTO.Show();
            formTO.Text = "Add or remove URL from list";
        }

        private void NameButton_Click(object sender, EventArgs e)
        {
            SaveContacts.gatherListMode = 3;
            if (SaveContacts.toNameList != null)
            {
                foreach (string s in SaveContacts.toNameList)
                {
                    SaveContacts.rtb.AppendText(s + "\n");
                }
                SaveContacts.toNameList = new string[0];
            }
            formTO.Show();
            formTO.Text = "Add or remove name of contact from list";
        }

        private void attButton_Click(object sender, EventArgs e)
        {
            fileLocation = SelectedFileName();
        }

        private List<string> SelectedFileName()
        {
            OpenFileDialog ofd = new OpenFileDialog(); ;
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> FileNameList = new List<string>();
                //savedFileName = Path.GetFileNameWithoutExtension(ofd.FileName);
                foreach (string filename in ofd.FileNames)
                {
                    FileNameList.Add(filename);
                }
                return FileNameList;
            }
            else
                return new List<string>();
        }

        private void useSMPT_CheckedChanged(object sender, EventArgs e)
        {
            SMPTBox.Visible = true;
        }

        private void useOutlook_CheckedChanged(object sender, EventArgs e)
        {
            SMPTBox.Visible = false;
        }

        private void downloadLogButton_Click(object sender, EventArgs e)
        {
            //tring sPath = "LEO_EmailLog_" + DateTime.Now.ToString() + ".txt";
            char separators = ':';
            string sPath = "C:\\Users\\" + System.Environment.UserName + "\\Downloads\\LEO_Log_" + DateTime.Now.ToString().Replace(separators, '-') + ".txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();

            MessageBox.Show("Log saved at " + sPath);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            formHelp.Show();
        }

        private void haveMailto_CheckedChanged(object sender, EventArgs e)
        {
            if (haveMailto.Checked)
            {
                TempButton.Visible = true;
                if(SaveContacts.openOnce == false)
                {
                    formTemplate.Show();
                }
            }
            else
            {
                TempButton.Visible = false;
            }
        }

        private void TempButton_Click(object sender, EventArgs e)
        {
            formTemplate.Show();
        }
    }

    public interface IMarkupConverter
    {
        string ConvertXamlToHtml(string xamlText);
        string ConvertHtmlToXaml(string htmlText);
        string ConvertRtfToHtml(string rtfText);
    }

    public class MarkupConverter : IMarkupConverter
    {
        public string ConvertXamlToHtml(string xamlText)
        {
            return HtmlFromXamlConverter.ConvertXamlToHtml(xamlText, false);
        }

        public string ConvertHtmlToXaml(string htmlText)
        {
            return HtmlToXamlConverter.ConvertHtmlToXaml(htmlText, true);
        }

        public string ConvertRtfToHtml(string rtfText)
        {
            return RtfToHtmlConverter.ConvertRtfToHtml(rtfText);
        }
    }
}
