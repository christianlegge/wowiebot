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
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            minimumMessagesNum.Value = Properties.Settings.Default.minimumMessagesBetweenPeriodic;
        }

        private DataTable getDataTableFromSettings()
        {
            if (Properties.Settings.Default.periodicMessagesDataTableJson == null || Properties.Settings.Default.periodicMessagesDataTableJson == "" || Properties.Settings.Default.periodicMessagesDataTableJson == "[]")
            {
                loadDefaultPeriodicMessagesTable();
            }
            return JsonConvert.DeserializeObject<DataTable>(Properties.Settings.Default.periodicMessagesDataTableJson);

        }

        public void loadDefaultPeriodicMessagesTable()
        {
            // return default table
            DataTable table = new DataTable();
            DataColumn msg = new DataColumn("Message");
            DataColumn period = new DataColumn("Period", typeof(double));
            DataColumn offset = new DataColumn("Offset", typeof(double));

            table.Columns.Add(msg);
            table.Columns.Add(period);
            table.Columns.Add(offset);
            DataRow discordRow = table.NewRow();
            DataRow twitterRow = table.NewRow();
            discordRow.SetField<string>(msg, "Like this bot? You can get it for yourself! https://github.com/scatterclegge/wowiebot/releases");
            discordRow.SetField<double>(period, 30);
            discordRow.SetField<double>(offset, 0);
            twitterRow.SetField<string>(msg, "Be sure to leave a follow if you're enjoying the stream!");
            twitterRow.SetField<double>(period, 30);
            twitterRow.SetField<double>(offset, 15);
            table.Rows.Add(discordRow);
            table.Rows.Add(twitterRow);
            String x = JsonConvert.SerializeObject(table);
            Properties.Settings.Default.periodicMessagesDataTableJson = x;
            Properties.Settings.Default.Save();
            DataTable test = JsonConvert.DeserializeObject<DataTable>(x);
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
