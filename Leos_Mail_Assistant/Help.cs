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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void cancelTo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switch (trackBar1.Value)
            {
                case 0:
                    TitleLab.Text = "Default settings";
                    DescLab.Text = "When you just want to send to your costumer.";
                    ToLab.Text = "Add costumers email to list that you are\ngoing to send your email to.\n\nExample:\nleo.taff @cfigroup.se";
                    NamLab.Text = "Add costumers name to list that you are\ngoing to send your email to.\n\nExample:\nLeo Taff";
                    break;

                case 1:
                    TitleLab.Text = "Mailto settings";
                    DescLab.Text = "When you want to send to your partners, whom needs to send to their costumer.";
                    ToLab.Text = "Add costumers and partners email to list that you are\ngoing to send your email to.\nPut the costumer email first,\nthen add the partner email,\nand put | in the middle to seperate them.\n\nExample:\nleo.taff @cfigroup.se | fred.lutt@cfigroup.se";
                    NamLab.Text = "Add costumers and partners name to list that you are\ngoing to send your email to.\nPut the costumer name first,\nthen add the partner name,\nand put | in the middle to seperate them.\n\nExample:\nLeo Taff | Fred Lutt";
                    break;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
