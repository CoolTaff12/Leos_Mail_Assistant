using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leos_Mail_Assistant
{
    public partial class To_Form : Form
    {

        public To_Form()
        {
            InitializeComponent();
            this.ControlBox = false;
            SaveContacts.rtb = toRichText;
        }

        private void importTO_Click(object sender, EventArgs e)
        {
            string gatherTheList = "";
            string[] checkingTheList = new string[0];

            gatherTheList = toRichText.Text.ToString().Replace("\t", "");
            checkingTheList = gatherTheList.Split('\n');
            checkingTheList = checkingTheList.Where(val => val != "").ToArray();

            switch (SaveContacts.gatherListMode)
            {
                case 0:
                    SaveContacts.toList = checkingTheList;
                    break;

                case 1:
                    SaveContacts.ccList = checkingTheList;
                    break;

                case 2:
                    SaveContacts.urlList = checkingTheList;
                    break;

                case 3:
                    SaveContacts.toNameList = checkingTheList;
                    break;
            }
            toRichText.Clear();
            this.Hide();
        }

        private void cancelTo_Click(object sender, EventArgs e)
        {
            toRichText.Clear();
            this.Hide();
        }
    }
}
