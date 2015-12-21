using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DeviceDataDisplay
{
    public partial class SetUnits : Form
    {
        public SetUnits()
        {
            InitializeComponent();
        }

        private void SetUnits_Load(object sender, EventArgs e)
        {
            string connectionstring = "SERVER=localhost;Database=datalogger;UID=root;Password=Raffi1971$";

            MySqlConnection Connection = new MySqlConnection(connectionstring);
            Connection.Open();
            string query = "Select Channel_no,reference_name,units from channels c";
            MySqlDataAdapter channeladapter = new MySqlDataAdapter(query, Connection);
            DataSet channelsdata = new DataSet();
            channeladapter.Fill(channelsdata, "channels");



            ChannelsGV.DataSource = channelsdata.Tables["channels"];
            ChannelsGV.Columns["Channel_no"].ReadOnly = true;
            ChannelsGV.Columns["reference_name"].ReadOnly = true;
            ChannelsGV.Columns["units"].ReadOnly = false;

            string queryunits = "Select * from unitsofmesurement";

            DataGridViewComboBoxCell bc = new DataGridViewComboBoxCell();
            MySqlDataAdapter unitsadapter = new MySqlDataAdapter(queryunits, Connection);
            DataSet unitsdata = new DataSet();
            unitsadapter.Fill(unitsdata, "unitsofmesurement");
            DataTable tblunits = unitsdata.Tables["unitsofmesurement"];

            ChannelsGV.Columns[2].Visible = false;

            bc.DataSource = tblunits;
            bc.DisplayMember = "Units";
            bc.ValueMember = "UnitID";
            
            DataGridViewColumn cc = new DataGridViewColumn(bc);
            cc.HeaderText = "Units";
            
            ChannelsGV.Columns.Add(cc);

            foreach (DataGridViewRow item in ChannelsGV.Rows)
            {
                item.Cells[3].Value = item.Cells[2].Value;
                item.Height = 30;    
                
            }
            ChannelsGV.Columns[0].Width = 125;
            ChannelsGV.Columns[1].Width = 150;
            ChannelsGV.Columns[1].HeaderText = "Channels";
            ChannelsGV.Columns[2].Width = 150;
        }
    }
}
