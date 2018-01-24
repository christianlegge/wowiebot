using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace wowiebot
{
    public partial class PeriodicMessagesForm : Form
    {
        DataTable periodicMessagesDataTable;

        public PeriodicMessagesForm()
        {
            InitializeComponent();

            periodicMessagesDataTable = getDataTableFromSettings();

            dataGridView1.DataSource = periodicMessagesDataTable;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            minimumMessagesNum.Value = Properties.Settings.Default.minimumMessagesBetweenPeriodic;
        }

        private DataTable getDataTableFromSettings()
        {
            if (Properties.Settings.Default.periodicMessagesDataTableJson == null || Properties.Settings.Default.periodicMessagesDataTableJson == "" || Properties.Settings.Default.periodicMessagesDataTableJson == "[]")
            {
                ((MainForm)ParentForm).loadDefaultPeriodicMessagesTable();
            }
            return JsonConvert.DeserializeObject<DataTable>(Properties.Settings.Default.periodicMessagesDataTableJson);

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.periodicMessagesDataTableJson = JsonConvert.SerializeObject(dataGridView1.DataSource);
            Properties.Settings.Default.minimumMessagesBetweenPeriodic = (int)minimumMessagesNum.Value;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
