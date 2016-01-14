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
    public partial class DeviceDisplay : Form
    {
        private DataTable tbldevices;
        private ComboBox cmbglobal = new ComboBox();
        
        public DeviceDisplay()
        {
            InitializeComponent();
        }

        private void DeviceDiaplay_Load(object sender, EventArgs e)
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                Connection.Open();
                string query = "select deviceID,device_name,slaveID,value_start_address ,value_return_datatype ,unit_start_address ,unit_return_datatype,alarm_start_address,alarm_return_datatype,resolution_start_address,resolution_return_datatype,Endianess from devices";
                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(query, Connection);
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");
                tbldevices = new DataTable();
                tbldevices = devicedata.Tables["devices"];
                DevicesGV.DataSource = tbldevices;
                DevicesGV.Columns["deviceID"].ReadOnly = true;
                DevicesGV.Columns["device_name"].ReadOnly = false;
                DevicesGV.Columns["slaveID"].ReadOnly = false;
                DevicesGV.Columns["value_start_address"].ReadOnly = false;
                DevicesGV.Columns["value_return_datatype"].ReadOnly = true;
                DevicesGV.Columns["unit_start_address"].ReadOnly = false;
                DevicesGV.Columns["unit_return_datatype"].ReadOnly = true;
                DevicesGV.Columns["alarm_start_address"].ReadOnly = false;
                DevicesGV.Columns["alarm_return_datatype"].ReadOnly = true;
                DevicesGV.Columns["resolution_start_address"].ReadOnly = false;
                DevicesGV.Columns["resolution_return_datatype"].ReadOnly = true;
                DevicesGV.Columns["Endianess"].ReadOnly = true;

                DevicesGV.Columns[0].Width = 125;
                DevicesGV.Columns[1].Width = 150;
                DevicesGV.Columns[1].HeaderText = "Device Name";
                DevicesGV.Columns[2].Width = 125;
                DevicesGV.Columns[2].HeaderText = "SlaveID";
                DevicesGV.Columns[3].Width = 125;
                DevicesGV.Columns[3].HeaderText = "Value Address";
                DevicesGV.Columns[4].Width = 125;
                DevicesGV.Columns[4].HeaderText = "Value Datatype";
                DevicesGV.Columns[5].Width = 125;
                DevicesGV.Columns[5].HeaderText = "Unit Address";
                DevicesGV.Columns[6].Width = 125;
                DevicesGV.Columns[6].HeaderText = "Unit Datatype";
                DevicesGV.Columns[7].Width = 125;
                DevicesGV.Columns[7].HeaderText = "Alarm Address";
                DevicesGV.Columns[8].Width = 125;
                DevicesGV.Columns[8].HeaderText = "Alarm Datatype";
                DevicesGV.Columns[9].Width = 125;
                DevicesGV.Columns[9].HeaderText = "Res Address";
                DevicesGV.Columns[10].Width = 125;
                DevicesGV.Columns[10].HeaderText = "Res Datatype";
                DevicesGV.Columns[11].Width = 125;



                DevicesGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

                Dictionary<int, String> modbus_return_datatypes = new Dictionary<int, string>();
                modbus_return_datatypes.Add(1, "uinteger-16 bits");
                modbus_return_datatypes.Add(2, "ulong-32 bits");

                DataGridViewComboBoxCell datatypes = new DataGridViewComboBoxCell();
                datatypes.DataSource = new BindingSource(modbus_return_datatypes, null);
                datatypes.ValueMember = "Key";
                datatypes.DisplayMember = "Value";
                DataGridViewColumn datatypevaluecolumn = new DataGridViewColumn(datatypes);
                datatypevaluecolumn.HeaderText = "Value datatype";
                datatypevaluecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                datatypevaluecolumn.Width = 150;

                DevicesGV.Columns.Insert(4, datatypevaluecolumn);
                DevicesGV.Columns[5].Visible = false;

                Dictionary<int, String> modbus_unit_alaram_res_datatypes = new Dictionary<int, string>();
                modbus_unit_alaram_res_datatypes.Add(1, "uinteger-16 bits");
                modbus_unit_alaram_res_datatypes.Add(2, "ulong-32 bits");
                modbus_unit_alaram_res_datatypes.Add(50000, "");

                DataGridViewComboBoxCell unitdatatypes = new DataGridViewComboBoxCell();
                unitdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                unitdatatypes.ValueMember = "Key";
                unitdatatypes.DisplayMember = "Value";
                DataGridViewColumn unitdatatypecolumn = new DataGridViewColumn(unitdatatypes);
                unitdatatypecolumn.HeaderText = "Unit datatype";
                unitdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                unitdatatypecolumn.Width = 150;

                DevicesGV.Columns.Insert(7, unitdatatypecolumn);
                DevicesGV.Columns[8].Visible = false;


                DataGridViewComboBoxCell alarmdatatypes = new DataGridViewComboBoxCell();
                alarmdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                alarmdatatypes.ValueMember = "Key";
                alarmdatatypes.DisplayMember = "Value";
                DataGridViewColumn alarmdatatypecolumn = new DataGridViewColumn(alarmdatatypes);
                alarmdatatypecolumn.HeaderText = "Alarm datatype";
                alarmdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                alarmdatatypecolumn.Width = 150;

                DevicesGV.Columns.Insert(10, alarmdatatypecolumn);
                DevicesGV.Columns[11].Visible = false;


                
                DataGridViewComboBoxCell resdatatypes = new DataGridViewComboBoxCell();
                resdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                resdatatypes.ValueMember = "Key";
                resdatatypes.DisplayMember = "Value";
                DataGridViewColumn resdatatypecolumn = new DataGridViewColumn(resdatatypes);
                resdatatypecolumn.HeaderText = "Res datatype";
                resdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                resdatatypecolumn.Width = 150;

                DevicesGV.Columns.Insert(13, resdatatypecolumn);
                DevicesGV.Columns[14].Visible = false;


                Dictionary<int, String> Endianess = new Dictionary<int, string>();
                Endianess.Add(0, "LittleEndian");
                Endianess.Add(1, "BigEndian");

                DataGridViewComboBoxCell endianessvalue = new DataGridViewComboBoxCell();
                endianessvalue.DataSource = new BindingSource(Endianess, null);
                endianessvalue.ValueMember = "Key";
                endianessvalue.DisplayMember = "Value";
                DataGridViewColumn endianessvaluecolumn = new DataGridViewColumn(endianessvalue);
                endianessvaluecolumn.HeaderText = "Endianess";
                endianessvaluecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                endianessvaluecolumn.Width = 150;

                DevicesGV.Columns.Insert(15, endianessvaluecolumn);
                DevicesGV.Columns[16].Visible = false;
                foreach (DataGridViewRow item in DevicesGV.Rows)
                {
                    item.Cells[4].Value = item.Cells[5].Value;
                    item.Cells[7].Value = item.Cells[8].Value;
                    item.Cells[10].Value = item.Cells[11].Value;
                    item.Cells[13].Value = item.Cells[14].Value;
                    item.Cells[15].Value = item.Cells[16].Value;
                    
                    item.Height = 30;
                }
                DevicesGV.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[15].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

                DevicesGV.AllowUserToAddRows = false;

                

            }
        }
        
        private void DevicesGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (e.Control is DataGridViewComboBoxEditingControl)
            //{
            //    ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
            //    ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
            //    ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            //}

            ComboBox cmbvalue = e.Control as ComboBox;
            if (DevicesGV.CurrentCell.ColumnIndex == 4 && e.Control is ComboBox)
            {
                
                cmbvalue.SelectedIndexChanged += new EventHandler(value_SelectedIndexChanged);
            }
            

            if (DevicesGV.CurrentCell.ColumnIndex == 7 && e.Control is ComboBox)
            {

                cmbvalue.SelectedIndexChanged += new EventHandler(value_SelectedIndexChanged);
            }
            

            if (DevicesGV.CurrentCell.ColumnIndex == 10 && e.Control is ComboBox)
            {

                cmbvalue.SelectedIndexChanged += new EventHandler(value_SelectedIndexChanged);
            }
            
            if (DevicesGV.CurrentCell.ColumnIndex == 13 && e.Control is ComboBox)
            {

                cmbvalue.SelectedIndexChanged += new EventHandler(value_SelectedIndexChanged);
            }
            
        }

        
        private void value_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbvalue = (ComboBox)sender;
            cmbglobal = cmbvalue;
            //MessageBox.Show(cmbunitsglobal.SelectedValue.ToString());
            if(DevicesGV.CurrentCell.ColumnIndex == 4)
            {
                DevicesGV.CurrentRow.Cells[5].Value = cmbglobal.SelectedValue.ToString();
            }

            if (DevicesGV.CurrentCell.ColumnIndex == 7)
            {
                DevicesGV.CurrentRow.Cells[8].Value = cmbglobal.SelectedValue.ToString();
            }

            if (DevicesGV.CurrentCell.ColumnIndex == 10)
            {
                DevicesGV.CurrentRow.Cells[11].Value = cmbglobal.SelectedValue.ToString();
            }

            if (DevicesGV.CurrentCell.ColumnIndex == 13)
            {
                DevicesGV.CurrentRow.Cells[14].Value = cmbglobal.SelectedValue.ToString();
            }
            //cmbvalue.SelectedIndexChanged += new EventHandler(value_SelectedIndexChanged);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {   
           
            DataTable tblchanges = new DataTable();
            tblchanges = tbldevices.GetChanges();
            int counter = 0;
            if (tblchanges != null)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
                    conn.Open();
                    MySqlCommand deviceUpdate = new MySqlCommand();

                    foreach (DataRow row in tblchanges.Rows)
                    {
                        if (row[0].ToString() != null)
                        {
                            //string rowvalues = row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString() + " " + row[4].ToString() + " " + row[7].ToString();
                            var results = DevicesGV.Rows.Cast<DataGridViewRow>()
                                          .FirstOrDefault(rvalue => rvalue.Cells[0].Value.ToString() == row[0].ToString());

                            string unitstartaddress = (!string.IsNullOrEmpty(results.Cells[6].Value.ToString())) ? results.Cells[6].Value.ToString() : "null";
                            string unitreturntype = (results.Cells[8].Value.ToString() != "50000") ? results.Cells[8].Value.ToString() : "null";

                            string alarmstartaddress = (!string.IsNullOrEmpty(results.Cells[9].Value.ToString())) ? results.Cells[9].Value.ToString() : "null";
                            string alarmreturntype = (results.Cells[11].Value.ToString() != "50000") ? results.Cells[11].Value.ToString() : "null";

                            string resstartaddress = (!string.IsNullOrEmpty(results.Cells[12].Value.ToString())) ? results.Cells[12].Value.ToString() : "null";
                            string resreturntype = (results.Cells[14].Value.ToString() != "50000") ? results.Cells[14].Value.ToString() : "null";

                            String UpdateSQL = "Update devices set device_name ='" + results.Cells[1].Value.ToString() + "', " +
                                                "slaveID =" + results.Cells[2].Value.ToString() +
                                                ", value_start_address =" + results.Cells[3].Value.ToString() +
                                                ", value_return_datatype =" + results.Cells[5].Value.ToString() +
                                                ", unit_start_address =" + unitstartaddress +
                                                ", unit_return_datatype =" + unitreturntype +
                                                ", alarm_start_address =" + alarmstartaddress +
                                                ", alarm_return_datatype =" + alarmreturntype +
                                                ", resolution_start_address=" + resstartaddress +
                                                ", resolution_return_datatype =" + resreturntype +
                                                ", Endianess =" + results.Cells[15].Value.ToString() + " where deviceID = " + row[0].ToString();

                            deviceUpdate.CommandType = CommandType.Text;
                            deviceUpdate.CommandText = UpdateSQL;
                            deviceUpdate.Connection = conn;
                            

                            deviceUpdate.ExecuteNonQuery();
                            counter =counter+ 1;
                            
                        }
                        
                    }
            
                    conn.Close();
                    refreshData();
                    if (counter > 0)
                    {
                        lblDeviceDisplayStatus.Text = counter + " rows sucessfully updated";
                        counter = 0;

                    }
                    
                }
                catch(Exception err)
                {
                    lblDeviceDisplayStatus.Text = "Error occured no rows updated" + err.Message;
                }
            }
            else
            {
                lblDeviceDisplayStatus.Text = "No rows updated";
                counter = 0;
            }
            
        }

        private void DevicesGV_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void DevicesGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DevicesGV.Rows[e.RowIndex].ErrorText = "";
            //string pkvalue = (!(String.IsNullOrEmpty(DevicesGV.Rows[e.RowIndex].Cells[0].Value.ToString()))) ? DevicesGV.Rows[e.RowIndex].Cells[0].Value.ToString() : "";
            if (DevicesGV.CurrentCell.ColumnIndex == 1)
            {
                string cellvalue = (string)e.FormattedValue;
                if(String.IsNullOrEmpty(cellvalue))
                {
                    DevicesGV.Rows[e.RowIndex].ErrorText = "Device Name can't be null";
                    e.Cancel = true;
                }

            }
            if(DevicesGV.CurrentCell.ColumnIndex ==2)
            { 
                int outvalue = 0;
                 string cellvalue = (string)e.FormattedValue;
                if (!(int.TryParse(cellvalue, out outvalue)))
                {
                    DevicesGV.Rows[e.RowIndex].ErrorText = "Numeric and not null";
                    e.Cancel = true;
                }

                if (outvalue <= 0 || outvalue >247)
                {
                    DevicesGV.Rows[e.RowIndex].ErrorText = "value should be in between 1 and 247";
                    e.Cancel = true;

                } 
            }

            if (DevicesGV.CurrentCell.ColumnIndex == 3)
            {
                int outvalue = 0;
                string cellvalue = (string)e.FormattedValue;
                if (!(int.TryParse(cellvalue, out outvalue)))
                {
                    DevicesGV.Rows[e.RowIndex].ErrorText = "Numeric and not null";
                    e.Cancel = true;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    DevicesGV.Rows[e.RowIndex].ErrorText = "Should be in between 0 and 9999";
                    e.Cancel = true;

                }
            }
            if(DevicesGV.CurrentCell.ColumnIndex == 6 || DevicesGV.CurrentCell.ColumnIndex == 9 || DevicesGV.CurrentCell.ColumnIndex == 12)
            {
                int outvalue = 0;
                string cellvalue = (string)e.FormattedValue;
                if(!String.IsNullOrEmpty(cellvalue))
                {

                    if (!(int.TryParse(cellvalue, out outvalue)))
                    {
                        DevicesGV.Rows[e.RowIndex].ErrorText = "Numeric";
                        e.Cancel = true;
                    }

                    if (outvalue < 0 || outvalue > 9999)
                    {
                        DevicesGV.Rows[e.RowIndex].ErrorText = "Should be in between 0 and 9999";
                        e.Cancel = true;

                    }

                }
                


            }
            




        }

        private void DevicesGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DevicesGV.Rows[e.RowIndex].ErrorText = "";
            DevicesGV.CurrentCell.ErrorText = "";
        }

        private void DevicesGV_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DevicesGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            
        }

        private void DevicesGV_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show("Row added");
        }

        private void DevicesGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DevicesGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rows = Convert.ToInt32(DevicesGV.Rows.Count.ToString());
            int rowindex = Convert.ToInt32(e.RowIndex);
            if(rowindex == rows-1)
            {
                
            }

            
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDevices adddevices = new AddDevices(ref DevicesGV);
            adddevices.ShowDialog();

            
        }
        private void refreshData()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                DevicesGV.DataSource = null;
                DevicesGV.Rows.Clear();
                DevicesGV.Columns.Clear();
                Connection.Open();
                string query = "select deviceID,device_name,slaveID,value_start_address ,value_return_datatype ,unit_start_address ,unit_return_datatype,alarm_start_address,alarm_return_datatype,resolution_start_address,resolution_return_datatype,Endianess from devices";
                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(query, Connection);
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");
                tbldevices = new DataTable();
                tbldevices = devicedata.Tables["devices"];
                DevicesGV.DataSource = tbldevices;
                DevicesGV.Columns["deviceID"].ReadOnly = true;
                DevicesGV.Columns["device_name"].ReadOnly = false;
                DevicesGV.Columns["slaveID"].ReadOnly = false;
                DevicesGV.Columns["value_start_address"].ReadOnly = false;
                DevicesGV.Columns["value_return_datatype"].ReadOnly = true;
                DevicesGV.Columns["unit_start_address"].ReadOnly = false;
                DevicesGV.Columns["unit_return_datatype"].ReadOnly = true;
                DevicesGV.Columns["alarm_start_address"].ReadOnly = false;
                DevicesGV.Columns["alarm_return_datatype"].ReadOnly = true;
                DevicesGV.Columns["resolution_start_address"].ReadOnly = false;
                DevicesGV.Columns["resolution_return_datatype"].ReadOnly = true;
                DevicesGV.Columns["Endianess"].ReadOnly = true;

                DevicesGV.Columns[0].Width = 125;
                DevicesGV.Columns[1].Width = 150;
                DevicesGV.Columns[1].HeaderText = "Device Name";
                DevicesGV.Columns[2].Width = 125;
                DevicesGV.Columns[2].HeaderText = "SlaveID";
                DevicesGV.Columns[3].Width = 125;
                DevicesGV.Columns[3].HeaderText = "Value Address";
                DevicesGV.Columns[4].Width = 125;
                DevicesGV.Columns[4].HeaderText = "Value Datatype";
                DevicesGV.Columns[5].Width = 125;
                DevicesGV.Columns[5].HeaderText = "Unit Address";
                DevicesGV.Columns[6].Width = 125;
                DevicesGV.Columns[6].HeaderText = "Unit Datatype";
                DevicesGV.Columns[7].Width = 125;
                DevicesGV.Columns[7].HeaderText = "Alarm Address";
                DevicesGV.Columns[8].Width = 125;
                DevicesGV.Columns[8].HeaderText = "Alarm Datatype";
                DevicesGV.Columns[9].Width = 125;
                DevicesGV.Columns[9].HeaderText = "Res Address";
                DevicesGV.Columns[10].Width = 125;
                DevicesGV.Columns[10].HeaderText = "Res Datatype";
                DevicesGV.Columns[11].Width = 125;



                DevicesGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

                Dictionary<int, String> modbus_return_datatypes = new Dictionary<int, string>();
                modbus_return_datatypes.Add(1, "uinteger-16 bits");
                modbus_return_datatypes.Add(2, "ulong-32 bits");

                DataGridViewComboBoxCell datatypes = new DataGridViewComboBoxCell();
                datatypes.DataSource = new BindingSource(modbus_return_datatypes, null);
                datatypes.ValueMember = "Key";
                datatypes.DisplayMember = "Value";
                DataGridViewColumn datatypevaluecolumn = new DataGridViewColumn(datatypes);
                datatypevaluecolumn.HeaderText = "Value datatype";
                datatypevaluecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                datatypevaluecolumn.Width = 150;

                DevicesGV.Columns.Insert(4, datatypevaluecolumn);
                DevicesGV.Columns[5].Visible = false;

                Dictionary<int, String> modbus_unit_alaram_res_datatypes = new Dictionary<int, string>();
                modbus_unit_alaram_res_datatypes.Add(1, "uinteger-16 bits");
                modbus_unit_alaram_res_datatypes.Add(2, "ulong-32 bits");
                modbus_unit_alaram_res_datatypes.Add(50000, "");

                DataGridViewComboBoxCell unitdatatypes = new DataGridViewComboBoxCell();
                unitdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                unitdatatypes.ValueMember = "Key";
                unitdatatypes.DisplayMember = "Value";
                DataGridViewColumn unitdatatypecolumn = new DataGridViewColumn(unitdatatypes);
                unitdatatypecolumn.HeaderText = "Unit datatype";
                unitdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                unitdatatypecolumn.Width = 150;

                DevicesGV.Columns.Insert(7, unitdatatypecolumn);
                DevicesGV.Columns[8].Visible = false;


                DataGridViewComboBoxCell alarmdatatypes = new DataGridViewComboBoxCell();
                alarmdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                alarmdatatypes.ValueMember = "Key";
                alarmdatatypes.DisplayMember = "Value";
                DataGridViewColumn alarmdatatypecolumn = new DataGridViewColumn(alarmdatatypes);
                alarmdatatypecolumn.HeaderText = "Alarm datatype";
                alarmdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                alarmdatatypecolumn.Width = 150;

                DevicesGV.Columns.Insert(10, alarmdatatypecolumn);
                DevicesGV.Columns[11].Visible = false;



                DataGridViewComboBoxCell resdatatypes = new DataGridViewComboBoxCell();
                resdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                resdatatypes.ValueMember = "Key";
                resdatatypes.DisplayMember = "Value";
                DataGridViewColumn resdatatypecolumn = new DataGridViewColumn(resdatatypes);
                resdatatypecolumn.HeaderText = "Res datatype";
                resdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                resdatatypecolumn.Width = 150;

                DevicesGV.Columns.Insert(13, resdatatypecolumn);
                DevicesGV.Columns[14].Visible = false;


                Dictionary<int, String> Endianess = new Dictionary<int, string>();
                Endianess.Add(0, "LittleEndian");
                Endianess.Add(1, "BigEndian");

                DataGridViewComboBoxCell endianessvalue = new DataGridViewComboBoxCell();
                endianessvalue.DataSource = new BindingSource(Endianess, null);
                endianessvalue.ValueMember = "Key";
                endianessvalue.DisplayMember = "Value";
                DataGridViewColumn endianessvaluecolumn = new DataGridViewColumn(endianessvalue);
                endianessvaluecolumn.HeaderText = "Endianess";
                endianessvaluecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                endianessvaluecolumn.Width = 150;

                DevicesGV.Columns.Insert(15, endianessvaluecolumn);
                DevicesGV.Columns[16].Visible = false;
                foreach (DataGridViewRow item in DevicesGV.Rows)
                {
                    item.Cells[4].Value = item.Cells[5].Value;
                    item.Cells[7].Value = item.Cells[8].Value;
                    item.Cells[10].Value = item.Cells[11].Value;
                    item.Cells[13].Value = item.Cells[14].Value;
                    item.Cells[15].Value = item.Cells[16].Value;

                    item.Height = 30;
                }
                DevicesGV.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[15].SortMode = DataGridViewColumnSortMode.NotSortable;
                DevicesGV.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

                DevicesGV.AllowUserToAddRows = false;

            }
        }
        private void DevicesGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            cmbglobal.SelectedIndexChanged -= new EventHandler(value_SelectedIndexChanged);
        }
    }
}
