namespace Leos_Mail_Assistant
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SendButton = new System.Windows.Forms.Button();
            this.CCButton = new System.Windows.Forms.Button();
            this.bodyText = new System.Windows.Forms.RichTextBox();
            this.ToButton = new System.Windows.Forms.Button();
            this.URLButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fromSubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.changeSMTP = new System.Windows.Forms.TextBox();
            this.attButton = new System.Windows.Forms.Button();
            this.NameButton = new System.Windows.Forms.Button();
            this.downloadLogButton = new System.Windows.Forms.Button();
            this.useSMPT = new System.Windows.Forms.RadioButton();
            this.useOutlook = new System.Windows.Forms.RadioButton();
            this.SMPTBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fromEmail = new System.Windows.Forms.TextBox();
            this.fromName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.haveMailto = new System.Windows.Forms.CheckBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.TempButton = new System.Windows.Forms.Button();
            this.SMPTBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.SystemColors.Control;
            this.SendButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SendButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SendButton.ImageKey = "(none)";
            this.SendButton.Location = new System.Drawing.Point(456, 494);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(221, 23);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send";
            this.SendButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // CCButton
            // 
            this.CCButton.BackColor = System.Drawing.SystemColors.Control;
            this.CCButton.Location = new System.Drawing.Point(12, 45);
            this.CCButton.Name = "CCButton";
            this.CCButton.Size = new System.Drawing.Size(97, 27);
            this.CCButton.TabIndex = 2;
            this.CCButton.Text = "CC...";
            this.CCButton.UseVisualStyleBackColor = false;
            this.CCButton.Click += new System.EventHandler(this.CCButton_Click);
            // 
            // bodyText
            // 
            this.bodyText.Location = new System.Drawing.Point(330, 78);
            this.bodyText.Name = "bodyText";
            this.bodyText.Size = new System.Drawing.Size(447, 397);
            this.bodyText.TabIndex = 18;
            this.bodyText.Text = resources.GetString("bodyText.Text");
            // 
            // ToButton
            // 
            this.ToButton.BackColor = System.Drawing.SystemColors.Control;
            this.ToButton.Location = new System.Drawing.Point(12, 12);
            this.ToButton.Name = "ToButton";
            this.ToButton.Size = new System.Drawing.Size(97, 27);
            this.ToButton.TabIndex = 1;
            this.ToButton.Text = "To...";
            this.ToButton.UseVisualStyleBackColor = false;
            this.ToButton.Click += new System.EventHandler(this.ToButton_Click);
            // 
            // URLButton
            // 
            this.URLButton.BackColor = System.Drawing.SystemColors.Control;
            this.URLButton.Location = new System.Drawing.Point(12, 78);
            this.URLButton.Name = "URLButton";
            this.URLButton.Size = new System.Drawing.Size(97, 27);
            this.URLButton.TabIndex = 19;
            this.URLButton.Text = "URLs...";
            this.URLButton.UseVisualStyleBackColor = false;
            this.URLButton.Click += new System.EventHandler(this.URLButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 224);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(312, 251);
            this.listBox1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Subject";
            // 
            // fromSubject
            // 
            this.fromSubject.Location = new System.Drawing.Point(398, 45);
            this.fromSubject.Name = "fromSubject";
            this.fromSubject.Size = new System.Drawing.Size(353, 20);
            this.fromSubject.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Output Log";
            // 
            // changeSMTP
            // 
            this.changeSMTP.Location = new System.Drawing.Point(3, 16);
            this.changeSMTP.Name = "changeSMTP";
            this.changeSMTP.Size = new System.Drawing.Size(136, 20);
            this.changeSMTP.TabIndex = 29;
            this.changeSMTP.Text = "Zakura.nordic.Bi";
            // 
            // attButton
            // 
            this.attButton.BackColor = System.Drawing.SystemColors.Control;
            this.attButton.Location = new System.Drawing.Point(130, 45);
            this.attButton.Name = "attButton";
            this.attButton.Size = new System.Drawing.Size(97, 27);
            this.attButton.TabIndex = 31;
            this.attButton.Text = "Attachment";
            this.attButton.UseVisualStyleBackColor = false;
            this.attButton.Click += new System.EventHandler(this.attButton_Click);
            // 
            // NameButton
            // 
            this.NameButton.BackColor = System.Drawing.SystemColors.Control;
            this.NameButton.Location = new System.Drawing.Point(130, 12);
            this.NameButton.Name = "NameButton";
            this.NameButton.Size = new System.Drawing.Size(97, 27);
            this.NameButton.TabIndex = 32;
            this.NameButton.Text = "Name";
            this.NameButton.UseVisualStyleBackColor = false;
            this.NameButton.Click += new System.EventHandler(this.NameButton_Click);
            // 
            // downloadLogButton
            // 
            this.downloadLogButton.BackColor = System.Drawing.SystemColors.Control;
            this.downloadLogButton.Location = new System.Drawing.Point(12, 494);
            this.downloadLogButton.Name = "downloadLogButton";
            this.downloadLogButton.Size = new System.Drawing.Size(95, 20);
            this.downloadLogButton.TabIndex = 33;
            this.downloadLogButton.Text = "Download Log";
            this.downloadLogButton.UseVisualStyleBackColor = false;
            this.downloadLogButton.Click += new System.EventHandler(this.downloadLogButton_Click);
            // 
            // useSMPT
            // 
            this.useSMPT.AutoSize = true;
            this.useSMPT.Location = new System.Drawing.Point(240, 111);
            this.useSMPT.Name = "useSMPT";
            this.useSMPT.Size = new System.Drawing.Size(77, 17);
            this.useSMPT.TabIndex = 34;
            this.useSMPT.Text = "Use SMPT";
            this.useSMPT.UseVisualStyleBackColor = true;
            this.useSMPT.Visible = false;
            this.useSMPT.CheckedChanged += new System.EventHandler(this.useSMPT_CheckedChanged);
            // 
            // useOutlook
            // 
            this.useOutlook.AutoSize = true;
            this.useOutlook.Checked = true;
            this.useOutlook.Location = new System.Drawing.Point(240, 88);
            this.useOutlook.Name = "useOutlook";
            this.useOutlook.Size = new System.Drawing.Size(84, 17);
            this.useOutlook.TabIndex = 35;
            this.useOutlook.TabStop = true;
            this.useOutlook.Text = "Use Outlook";
            this.useOutlook.UseVisualStyleBackColor = true;
            this.useOutlook.Visible = false;
            this.useOutlook.CheckedChanged += new System.EventHandler(this.useOutlook_CheckedChanged);
            // 
            // SMPTBox
            // 
            this.SMPTBox.Controls.Add(this.changeSMTP);
            this.SMPTBox.Location = new System.Drawing.Point(12, 145);
            this.SMPTBox.Name = "SMPTBox";
            this.SMPTBox.Size = new System.Drawing.Size(153, 46);
            this.SMPTBox.TabIndex = 36;
            this.SMPTBox.TabStop = false;
            this.SMPTBox.Text = " Enter your SMPT here...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "From (Email)";
            this.label2.Visible = false;
            // 
            // fromEmail
            // 
            this.fromEmail.Location = new System.Drawing.Point(398, -1);
            this.fromEmail.Name = "fromEmail";
            this.fromEmail.Size = new System.Drawing.Size(353, 20);
            this.fromEmail.TabIndex = 24;
            this.fromEmail.Visible = false;
            // 
            // fromName
            // 
            this.fromName.Location = new System.Drawing.Point(398, 19);
            this.fromName.Name = "fromName";
            this.fromName.Size = new System.Drawing.Size(353, 20);
            this.fromName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "From (Name)";
            // 
            // haveMailto
            // 
            this.haveMailto.AutoSize = true;
            this.haveMailto.Location = new System.Drawing.Point(145, 122);
            this.haveMailto.Name = "haveMailto";
            this.haveMailto.Size = new System.Drawing.Size(82, 17);
            this.haveMailto.TabIndex = 38;
            this.haveMailto.Text = "Have mailto";
            this.haveMailto.UseVisualStyleBackColor = true;
            this.haveMailto.CheckedChanged += new System.EventHandler(this.haveMailto_CheckedChanged);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.Control;
            this.helpButton.Location = new System.Drawing.Point(225, 171);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(82, 20);
            this.helpButton.TabIndex = 39;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // TempButton
            // 
            this.TempButton.BackColor = System.Drawing.SystemColors.Control;
            this.TempButton.Location = new System.Drawing.Point(130, 78);
            this.TempButton.Name = "TempButton";
            this.TempButton.Size = new System.Drawing.Size(97, 27);
            this.TempButton.TabIndex = 40;
            this.TempButton.Text = "Edit M.Template";
            this.TempButton.UseVisualStyleBackColor = false;
            this.TempButton.Visible = false;
            this.TempButton.Click += new System.EventHandler(this.TempButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(789, 529);
            this.Controls.Add(this.TempButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.haveMailto);
            this.Controls.Add(this.SMPTBox);
            this.Controls.Add(this.useOutlook);
            this.Controls.Add(this.useSMPT);
            this.Controls.Add(this.downloadLogButton);
            this.Controls.Add(this.NameButton);
            this.Controls.Add(this.attButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fromSubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fromEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fromName);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.URLButton);
            this.Controls.Add(this.bodyText);
            this.Controls.Add(this.CCButton);
            this.Controls.Add(this.ToButton);
            this.Controls.Add(this.SendButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Leos Mail Assistant";
            this.SMPTBox.ResumeLayout(false);
            this.SMPTBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button CCButton;
        private System.Windows.Forms.RichTextBox bodyText;
        private System.Windows.Forms.Button ToButton;
        private System.Windows.Forms.Button URLButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fromSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox changeSMTP;
        private System.Windows.Forms.Button attButton;
        private System.Windows.Forms.Button NameButton;
        private System.Windows.Forms.Button downloadLogButton;
        private System.Windows.Forms.RadioButton useSMPT;
        private System.Windows.Forms.RadioButton useOutlook;
        private System.Windows.Forms.GroupBox SMPTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fromEmail;
        private System.Windows.Forms.TextBox fromName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox haveMailto;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button TempButton;
    }
}

