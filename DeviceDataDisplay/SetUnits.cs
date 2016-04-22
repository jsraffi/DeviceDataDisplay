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
using System.Configuration;
namespace DeviceDataDisplay
{
    public partial class SetUnits : Form
    {
        public SetUnits()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The grid is populated with data form channels and combo box is added with
        /// look from units table changing the units automatially gets saved to db
        /// </summary>
        /// <param name="sender">system defined params</param>
        /// <param name="e">system defined params</param>
        private void SetUnits_Load(object sender, EventArgs e)
        {
            //string connectionstring = "SERVER=localhost;Database=datalogger;UID=root;Password=Raffi1971$";

            using(MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            { 
                Connection.Open();
                string query = "Select Channel_no,channel_name,units from channels";
                MySqlDataAdapter channeladapter = new MySqlDataAdapter(query, Connection);
                DataSet channelsdata = new DataSet();
                channeladapter.Fill(channelsdata, "channels");

                //Datasource for dataviewgrid is set to channels dataset;
                //based on the query defined
                ChannelsGV.DataSource = channelsdata.Tables["channels"];
                ChannelsGV.Columns["Channel_no"].ReadOnly = true;
                ChannelsGV.Columns["channel_name"].ReadOnly = true;
                ChannelsGV.Columns["units"].ReadOnly = false;

                //query for units table is defined
                string queryunits = "Select * from unitsofmesurement order by UnitID";

                    
                //An sql adapter is opened
                MySqlDataAdapter unitsadapter = new MySqlDataAdapter(queryunits, Connection);
                    
                //units table dataset is defined   
                DataSet unitsdata = new DataSet();
                unitsadapter.Fill(unitsdata, "unitsofmesurement");

                //Data table for unitsofmesurement table is defined
                DataTable tblunits = unitsdata.Tables["unitsofmesurement"];

                //ChannelGV datagrid units colum is hidden    
                ChannelsGV.Columns[2].Visible = false;
                

                //Combo box for datagrid is created
                DataGridViewComboBoxCell bc = new DataGridViewComboBoxCell();

                //Combo source is set to datasource datatable of unitofmesurement table
                bc.DataSource = tblunits;
                bc.DisplayMember = "Units";// set  value to units column of unitofmesurement
                bc.ValueMember = "UnitID";// set index to unitid column of unitofmesurement

                //attach datagridcombo to a datagrid column
                DataGridViewColumn cc = new DataGridViewColumn(bc);
                cc.HeaderText = "Units";
                cc.Name = "Units";
                    
                    
                //add new column to grid;
                cc.DataPropertyName = "units";
                ChannelsGV.Columns.Add(cc);    
                //loop thru the grids invsible column units of channel table
                // and set the value to the combobox value
                /*
                foreach (DataGridViewRow item in ChannelsGV.Rows)
                {
                    item.Cells[3].Value = item.Cells[2].Value;
                    item.Height = 30;    
                
                }
                */
                ChannelsGV.Columns[0].Width = 125;
                ChannelsGV.Columns[1].Width = 200;
                ChannelsGV.Columns[1].HeaderText = "Channels";
                //ChannelsGV.Columns[3].Width = 125;
                    
            ChannelsGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            ChannelsGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //ChannelsGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            ChannelsGV.AllowUserToAddRows = false;
        }

        /// <summary>
        /// This method attaches a event selectedindex change of of the drop down box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelsGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cmbcunits = e.Control as ComboBox;
            if (ChannelsGV.CurrentCell.ColumnIndex == 3 && e.Control is ComboBox)
            {
                
                cmbcunits.SelectedIndexChanged += new EventHandler(units_SelectedIndexChanged);
            }
            else
            {
                cmbcunits.SelectedIndexChanged -= new EventHandler(units_SelectedIndexChanged);
            }
        }


        /// <summary>
        /// On change of the unit value the value is saved back to db.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void units_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbunits = (ComboBox)sender;
            string channelNo = ChannelsGV.CurrentRow.Cells[0].Value.ToString();
            if (cmbunits.SelectedIndex >=0)
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
                {
                    MySqlCommand cmdUnitsUpdate = new MySqlCommand();
                    int unitid = cmbunits.SelectedIndex + 1;
                    cmdUnitsUpdate.CommandText = "Update channels set units =" + unitid.ToString() + " where channel_no =" + channelNo + "";
                    cmdUnitsUpdate.CommandType = CommandType.Text;
                    cmdUnitsUpdate.Connection = conn;

                    conn.Open();
                    cmdUnitsUpdate.ExecuteNonQuery();
                }

                /*ChannelsGV.Refresh();
                foreach (DataGridViewRow item in ChannelsGV.Rows)
                {
                    item.Cells[3].Value = item.Cells[2].Value;
                    item.Height = 30;

                }*/
            }

            cmbunits.SelectedIndexChanged -= new EventHandler(units_SelectedIndexChanged);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SetUnits.ActiveForm.Close();
        }

        private void ChannelsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
