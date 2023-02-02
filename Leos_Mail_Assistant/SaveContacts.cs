using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leos_Mail_Assistant
{
    /// <summary>
    /// Stores DataTables
    /// </summary>
    public static class SaveContacts
    {
        public static string[] toList { get; set; }
        public static string[] toNameList { get; set; }
        public static string[] ccList { get; set; }
        public static string[] urlList { get; set; }
        public static string mailSubTemplate { get; set; }
        public static string mailBodyTemplate { get; set; }
        public static int gatherListMode { get; set; }
        public static bool openOnce = false;
        public static RichTextBox rtb { get; set; }
    }
}
