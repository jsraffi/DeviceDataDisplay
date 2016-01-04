using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceDataDisplay
{
    public partial class AddUnits : Form
    {
        public AddUnits()
        {
            InitializeComponent();
        }

        private DataTable refershdata()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                Connection.Open();
                string query = "Select unitID as UnitsID,units as Units from unitsofmesurement";
                MySqlDataAdapter unitsofmesureadapter = new MySqlDataAdapter(query, Connection);
                DataSet unitsofmesuredata = new DataSet();
                unitsofmesureadapter.Fill(unitsofmesuredata, "unitsofmesurement");

                return unitsofmesuredata.Tables["unitsofmesurement"];
            }
        }
        private void AddUnits_Load(object sender, EventArgs e)
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                Connection.Open();
                string query = "Select unitID as UnitsID,units as Units from unitsofmesurement";
                MySqlDataAdapter unitsofmesureadapter = new MySqlDataAdapter(query, Connection);
                DataSet unitsofmesuredata = new DataSet();
                unitsofmesureadapter.Fill(unitsofmesuredata, "unitsofmesurement");


                //Datasource for dataviewgrid is set to channels dataset;
                //based on the query defined
                AddUnitsGV.DataSource = unitsofmesuredata.Tables["unitsofmesurement"];
                AddUnitsGV.Columns[0].ReadOnly = true;

                

            }
            AddUnitsGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            AddUnitsGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (DataGridViewRow item in AddUnitsGV.Rows)
            {
                item.Height = 30;

            }
            AddUnitsGV.Columns[1].Width = 150;
        }

        private void AddUnitsGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (AddUnitsGV.CurrentCell.ColumnIndex == 1)
            {
                if(AddUnitsGV.CurrentRow.Cells[0].Value.ToString()=="")
                {
                    string sql = "Insert into unitsofmesurement(units) values('" + AddUnitsGV.CurrentRow.Cells[1].Value.ToString() + "')";
                    DataInsertUpdate(sql);
                }
                else
                {
                    int unitsid = Convert.ToInt32(AddUnitsGV.CurrentRow.Cells[0].Value.ToString());
                    string sql = "Update unitsofmesurement set units ='" + AddUnitsGV.CurrentRow.Cells[1].Value.ToString() + "' where UnitID = "+ unitsid + "";
                    DataInsertUpdate(sql);
                }
                AddUnitsGV.DataSource = null;
                AddUnitsGV.DataSource = refershdata();
                //MessageBox.Show(AddUnitsGV.CurrentCell.Value.ToString());
                //MessageBox.Show(AddUnitsGV.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void DataInsertUpdate(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                MySqlCommand cmdminmaxUpdate = new MySqlCommand();
                cmdminmaxUpdate.CommandText = sql;
                cmdminmaxUpdate.CommandType = CommandType.Text;
                cmdminmaxUpdate.Connection = conn;

                conn.Open();
                cmdminmaxUpdate.ExecuteNonQuery();
            }
        }
    }
}
