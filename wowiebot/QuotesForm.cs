using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wowiebot
{
    public partial class QuotesForm : Form
    {
        public QuotesForm()
        {
            InitializeComponent();
            foreach (string s in Properties.Settings.Default.quotes)
            {
                textBox1.Text += s + "\r\n";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Properties.Settings.Default.quotes = new System.Collections.Specialized.StringCollection();
            // Properties.Settings.Default.quotes.AddRange(textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            System.Collections.Specialized.StringCollection s = new System.Collections.Specialized.StringCollection();
            string[] strArr = textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strArr.Length; i++)
            {
                strArr[i] = strArr[i].Trim();
            }
            strArr = strArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s.AddRange(strArr);
            Properties.Settings.Default.quotes = s;
            Properties.Settings.Default.Save();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
