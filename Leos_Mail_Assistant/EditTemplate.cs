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
    public partial class EditTemplate : Form
    {
        public EditTemplate()
        {
            InitializeComponent();
        }

        private void importTOO_Click(object sender, EventArgs e)
        {
            SaveContacts.mailSubTemplate = fromSub.Text.Replace(" ", "%20");
            SaveContacts.mailBodyTemplate = 
                mBodyText.Text.Replace(" ", "%20").Replace("\n", "%0D%0A").Replace("[CFIRSTNAME]", "{1}").Replace("[URL]", "{2}").Replace("[PFIRSTNAME]", "{3}").Replace("[CFULLNAME]", "{4}").Replace("[PFULLNAME]", "{5}");
            SaveContacts.openOnce = true;
            this.Hide();
        }
    }
}
