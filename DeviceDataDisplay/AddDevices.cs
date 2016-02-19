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
    public partial class AddDevices : Form
    {
        private DataGridView adddevicegidview;
        private bool validateStatus;
       
        public AddDevices()
        {
            InitializeComponent();
        }
        public AddDevices(ref DataGridView deviceGV)
        {
            adddevicegidview = deviceGV;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool savechk = SavetoDB();
            if(savechk)
            {
                refershdata();
                this.Close();
            }

        }
        private void refershdata()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                adddevicegidview.DataSource = null;
                adddevicegidview.Rows.Clear();
                adddevicegidview.Columns.Clear();
                string query = "select deviceID,device_name,slaveID,value_start_address ,value_return_datatype ,unit_start_address ,unit_return_datatype,alarm_start_address,alarm_return_datatype,resolution_start_address,resolution_return_datatype,alarm_status_start_address,alarm_status_return_datatype,Endianess from devices"; //,alarm_status_start_address,alarm_status_return_datatype
                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(query, Connection);
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");
                DataTable tbldevices = new DataTable();
                tbldevices = devicedata.Tables["devices"];
                adddevicegidview.DataSource = tbldevices;
                adddevicegidview.Columns["deviceID"].ReadOnly = true;
                adddevicegidview.Columns["device_name"].ReadOnly = false;
                adddevicegidview.Columns["slaveID"].ReadOnly = false;
                adddevicegidview.Columns["value_start_address"].ReadOnly = false;
                adddevicegidview.Columns["value_return_datatype"].ReadOnly = true;
                adddevicegidview.Columns["unit_start_address"].ReadOnly = false;
                adddevicegidview.Columns["unit_return_datatype"].ReadOnly = true;
                adddevicegidview.Columns["alarm_start_address"].ReadOnly = false;
                adddevicegidview.Columns["alarm_return_datatype"].ReadOnly = true;
                adddevicegidview.Columns["resolution_start_address"].ReadOnly = false;
                adddevicegidview.Columns["resolution_return_datatype"].ReadOnly = true;
                adddevicegidview.Columns["alarm_status_start_address"].ReadOnly = false;
                adddevicegidview.Columns["alarm_status_return_datatype"].ReadOnly = true;
                adddevicegidview.Columns["Endianess"].ReadOnly = true;

                adddevicegidview.Columns[0].Width = 125;
                adddevicegidview.Columns[1].Width = 150;
                adddevicegidview.Columns[1].HeaderText = "Device Name";
                adddevicegidview.Columns[2].Width = 125;
                adddevicegidview.Columns[2].HeaderText = "SlaveID";
                adddevicegidview.Columns[3].Width = 125;
                adddevicegidview.Columns[3].HeaderText = "Value Address";
                adddevicegidview.Columns[4].Width = 125;
                adddevicegidview.Columns[4].HeaderText = "Value Datatype";
                adddevicegidview.Columns[5].Width = 125;
                adddevicegidview.Columns[5].HeaderText = "Unit Address";
                adddevicegidview.Columns[6].Width = 125;
                adddevicegidview.Columns[6].HeaderText = "Unit Datatype";
                adddevicegidview.Columns[7].Width = 125;
                adddevicegidview.Columns[7].HeaderText = "Alarm Address";
                adddevicegidview.Columns[8].Width = 125;
                adddevicegidview.Columns[8].HeaderText = "Alarm Datatype";
                adddevicegidview.Columns[9].Width = 125;
                adddevicegidview.Columns[9].HeaderText = "Res Address";
                adddevicegidview.Columns[10].Width = 125;
                adddevicegidview.Columns[10].HeaderText = "Res Datatype";
                adddevicegidview.Columns[11].Width = 150;
                adddevicegidview.Columns[11].HeaderText = "Alarm status address";
                adddevicegidview.Columns[12].Width = 200;
                adddevicegidview.Columns[12].HeaderText = "Alarm status Datatype";
                adddevicegidview.Columns[13].Width = 150;




                adddevicegidview.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

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

                adddevicegidview.Columns.Insert(4, datatypevaluecolumn);
                adddevicegidview.Columns[5].Visible = false;

                Dictionary<int, String> modbus_unit_alaram_res_datatypes = new Dictionary<int, string>();
                modbus_unit_alaram_res_datatypes.Add(1, "uinteger-16 bits");
                //modbus_unit_alaram_res_datatypes.Add(2, "ulong-32 bits");
                modbus_unit_alaram_res_datatypes.Add(50000, "");

                DataGridViewComboBoxCell unitdatatypes = new DataGridViewComboBoxCell();
                unitdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                unitdatatypes.ValueMember = "Key";
                unitdatatypes.DisplayMember = "Value";
                DataGridViewColumn unitdatatypecolumn = new DataGridViewColumn(unitdatatypes);
                unitdatatypecolumn.HeaderText = "Unit datatype";
                unitdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                unitdatatypecolumn.Width = 150;

                adddevicegidview.Columns.Insert(7, unitdatatypecolumn);
                adddevicegidview.Columns[8].Visible = false;


                DataGridViewComboBoxCell alarmdatatypes = new DataGridViewComboBoxCell();
                alarmdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                alarmdatatypes.ValueMember = "Key";
                alarmdatatypes.DisplayMember = "Value";
                DataGridViewColumn alarmdatatypecolumn = new DataGridViewColumn(alarmdatatypes);
                alarmdatatypecolumn.HeaderText = "Alarm datatype";
                alarmdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                alarmdatatypecolumn.Width = 150;

                adddevicegidview.Columns.Insert(10, alarmdatatypecolumn);
                adddevicegidview.Columns[11].Visible = false;

                DataGridViewComboBoxCell resdatatypes = new DataGridViewComboBoxCell();
                resdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                resdatatypes.ValueMember = "Key";
                resdatatypes.DisplayMember = "Value";
                DataGridViewColumn resdatatypecolumn = new DataGridViewColumn(resdatatypes);
                resdatatypecolumn.HeaderText = "Res datatype";
                resdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                resdatatypecolumn.Width = 150;

                adddevicegidview.Columns.Insert(13, resdatatypecolumn);
                adddevicegidview.Columns[14].Visible = false;



                DataGridViewComboBoxCell alarmstatus = new DataGridViewComboBoxCell();
                alarmstatus.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                alarmstatus.ValueMember = "Key";
                alarmstatus.DisplayMember = "Value";
                DataGridViewColumn alarmstatusdatatypecolumn = new DataGridViewColumn(alarmstatus);
                alarmstatusdatatypecolumn.HeaderText = "Alarm Status Datatype";
                alarmstatusdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                alarmstatusdatatypecolumn.Width = 150;

                adddevicegidview.Columns.Insert(16, alarmstatusdatatypecolumn);
                adddevicegidview.Columns[17].Visible = false;



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

                adddevicegidview.Columns.Insert(18, endianessvaluecolumn);
                adddevicegidview.Columns[19].Visible = false;




                foreach (DataGridViewRow item in adddevicegidview.Rows)
                {
                    item.Cells[4].Value = item.Cells[5].Value;
                    item.Cells[7].Value = item.Cells[8].Value;
                    item.Cells[10].Value = item.Cells[11].Value;
                    item.Cells[13].Value = item.Cells[14].Value;
                    item.Cells[16].Value = item.Cells[17].Value;
                    item.Cells[18].Value = item.Cells[19].Value;
                    item.Height = 30;
                }
                adddevicegidview.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[15].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[17].SortMode = DataGridViewColumnSortMode.NotSortable;
                adddevicegidview.Columns[18].SortMode = DataGridViewColumnSortMode.NotSortable;

                adddevicegidview.AllowUserToAddRows = false;
            }

               
   }
        
        private bool SavetoDB()
        {   
            try
            {   
                if(!(validate_form()) )
                {
                    return false;
                }
                using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
                {
                    string unitaddress = (txtUnitAddress.Text != "") ? txtUnitAddress.Text : "null";
                    string unitdatatype = (cmbUnitDatatype.SelectedValue.ToString() == "100")?"null": cmbUnitDatatype.SelectedValue.ToString();

                    string alarmaddress = (txtAlarmAddress.Text != "") ? txtAlarmAddress.Text : "null";
                    string alarmdatatype = (cmbAlarmDatatype.SelectedValue.ToString() == "100") ? "null" : cmbAlarmDatatype.SelectedValue.ToString();

                    string resaddress = (txtResolutionAddress.Text != "") ? txtResolutionAddress.Text : "null";
                    string resdatatype = (cmbResolutionDatatype.SelectedValue.ToString() == "100") ? "null" : cmbResolutionDatatype.SelectedValue.ToString();

                    string alarmstatusaddress = (txtAlarmStatus.Text != "") ? txtAlarmStatus.Text : "null";
                    string alarmstatusdatatype = (cmbAlarmStatus.SelectedValue.ToString() == "100") ? "null" : cmbAlarmStatus.SelectedValue.ToString();

                    string SQL = "Insert into devices(device_name, slaveID, value_start_address, value_return_datatype," +
                                 "unit_start_address, unit_return_datatype, alarm_start_address, alarm_return_datatype," +
                                  "resolution_start_address, resolution_return_datatype,alarm_status_start_address,alarm_status_return_datatype,Endianess)" +
                                  "Values('" + txtDeviceName.Text + "'," + txtSlaveID.Text +
                                  "," + txtValueAddress.Text + "," + cmbValueDatatype.SelectedValue +
                                  "," + unitaddress + "," + unitdatatype +
                                  "," + alarmaddress+ "," + alarmdatatype+
                                  "," + resaddress + ","+ resdatatype +
                                  "," + alarmstatusaddress + "," + alarmstatusdatatype +
                                  "," + cmbEndianess.SelectedValue + ")";

                    MySqlCommand cmdadddevice = new MySqlCommand();
                    cmdadddevice.CommandType = CommandType.Text;
                    cmdadddevice.CommandText = SQL;
                    cmdadddevice.Connection = Connection;
                    Connection.Open();
                    cmdadddevice.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception err)
            {
                lblStatus.Text = "Unable to add device" + err.Message;
                return false;
            }

        }
        private Boolean validate_form()
        {
            int outvalue = 0;
            if(txtDeviceName.Text == "")
            {
                txtDeviceName.Focus();
                lblStatus.Text = "Device name is required";
                validateStatus = false;
                return false;
            }

            if (!(int.TryParse(txtSlaveID.Text, out outvalue)))
            {
                txtSlaveID.Focus();
                lblStatus.Text = "slave id required and should be numeric";
                validateStatus = false;
                return false;
            }
            else if (outvalue <= 0 || outvalue > 247)
            {
                txtSlaveID.Focus();
                lblStatus.Text = "Please enter a value between 0 and 247";
                validateStatus = false;
                return false;
            }
            if (!(int.TryParse(txtValueAddress.Text, out outvalue)))
            {
                txtValueAddress.Focus();
                lblStatus.Text = "value address id required and should be numeric";
                validateStatus = false;
                return false;
            }
            else if (outvalue < 0 || outvalue > 9999)
            {
                txtValueAddress.Focus();
                lblStatus.Text = "value address is between 0 and 9999";
                validateStatus = false;
                return false;

            }
            if((txtUnitAddress.Text =="") ^ (cmbUnitDatatype.Text == ""))
            {
                txtUnitAddress.Focus();
                lblStatus.Text = "Both unit address & unit datatype is required else both are not required";
                validateStatus = false;
                return false;
            }
            else if(txtUnitAddress.Text != "")
            {
                if(!(int.TryParse(txtUnitAddress.Text, out outvalue)))
                {
                    txtUnitAddress.Focus();
                    lblStatus.Text = "Unit address should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtUnitAddress.Focus();
                    lblStatus.Text = "Unit address should be between 0 and 9999";
                    validateStatus = false;
                    return false;

                }
            }

            if ((txtResolutionAddress.Text == "") ^ (cmbResolutionDatatype.Text == ""))
            {
                txtResolutionAddress.Focus();
                lblStatus.Text = "Both resolution address & resolution datatype is required else both are not required";
                validateStatus = false;
                return false;
            }
            else if (txtResolutionAddress.Text != "")
            {
                if (!(int.TryParse(txtResolutionAddress.Text, out outvalue)))
                {
                    txtResolutionAddress.Focus();
                    lblStatus.Text = "Resolution address should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtResolutionAddress.Focus();
                    lblStatus.Text = "Resolution address should be between 0 and 9999";
                    validateStatus = false;
                    return false;

                }
            }

            if ((txtAlarmAddress.Text == "") ^ (cmbAlarmDatatype.Text == ""))
            {
                txtAlarmAddress.Focus();
                lblStatus.Text = "Both alarm address & alarm datatype is required else both are not required";
                validateStatus = false;
                return false;
            }
            else if (txtAlarmAddress.Text != "")
            {
                if (!(int.TryParse(txtAlarmAddress.Text, out outvalue)))
                {
                    txtAlarmAddress.Focus();
                    lblStatus.Text = "Alarm address should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtAlarmAddress.Focus();
                    lblStatus.Text = "Alarm address should be between 0 and 9999";
                    validateStatus = false;
                    return false;

                }
            }
            if ((txtAlarmStatus.Text == "") ^ (cmbAlarmStatus.Text == ""))
            {
                txtAlarmStatus.Focus();
                lblStatus.Text = "Both Alarm status address & Alarm Status datatype is required else both are not required";
                validateStatus = false;
                return false;
            }
            else if (txtAlarmStatus.Text != "")
            {
                if (!(int.TryParse(txtAlarmStatus.Text, out outvalue)))
                {
                    txtAlarmStatus.Focus();
                    lblStatus.Text = "Alarm status address should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtAlarmStatus.Focus();
                    lblStatus.Text = "Alarm status should be between 0 and 9999";
                    validateStatus = false;
                    return false;

                }
            }
            List<string> address = new List<string>();
            address.Add(txtValueAddress.Text);
               
            if(txtUnitAddress.Text != "")
            {
                address.Add(txtUnitAddress.Text);
                    
            }

            if (txtResolutionAddress.Text != "")
            {
                address.Add(txtResolutionAddress.Text);
                    
            }

            if (txtAlarmAddress.Text != "")
            {
                address.Add(txtAlarmAddress.Text);
                    
            }
            if(txtAlarmStatus.Text != "")
            {
                address.Add(txtAlarmStatus.Text);
            }
            
            if(address.Count() > 0)
            {
                var distinct = address.Distinct().Count();
                if(distinct != address.Count())
                {
                    lblStatus.Text = "All address or not unique";
                    validateStatus = false;
                    return false;
                }

            }           
            return true;
          
        }
        private void AddDevices_Load(object sender, EventArgs e)
        {
            List<Datatypes> vdatatypes = new List<Datatypes>()
            {
                new Datatypes { valueIndex=1, valueDatatype ="UInteger 16bit" },
                new Datatypes { valueIndex=2, valueDatatype ="Ulong 32bit" }
            };
            List<Datatypes> Unitdatatypes = new List<Datatypes>()
            {
                new Datatypes { valueIndex=1, valueDatatype ="UInteger 16bit" },
                //new Datatypes { valueIndex=2, valueDatatype ="Ulong 32bit" },
                new Datatypes { valueIndex=100, valueDatatype ="" }
            };
            List<Datatypes> alarmdatatypes = new List<Datatypes>()
            {
                new Datatypes { valueIndex=1, valueDatatype ="UInteger 16bit" },
                //new Datatypes { valueIndex=2, valueDatatype ="Ulong 32bit" },
                new Datatypes { valueIndex=100, valueDatatype ="" }
            };
            List<Datatypes> Resdatatypes = new List<Datatypes>()
            {
                new Datatypes { valueIndex=1, valueDatatype ="UInteger 16bit" },
                //new Datatypes { valueIndex=2, valueDatatype ="Ulong 32bit" },
                new Datatypes { valueIndex=100, valueDatatype ="" }
            };
            List<Datatypes> alarmstatusdatatypes = new List<Datatypes>()
            {
                new Datatypes { valueIndex=1, valueDatatype ="UInteger 16bit" },
                //new Datatypes { valueIndex=2, valueDatatype ="Ulong 32bit" },
                new Datatypes { valueIndex=100, valueDatatype ="" }
            };
            List<Datatypes> Endianessvalues = new List<Datatypes>()
            {
                new Datatypes { valueIndex=0, valueDatatype ="Little Endian" },
                new Datatypes { valueIndex=1, valueDatatype ="Big Endian" }
            };
            cmbValueDatatype.DataSource = vdatatypes;
            cmbValueDatatype.ValueMember = "valueIndex";
            cmbValueDatatype.DisplayMember = "valueDatatype";
            cmbValueDatatype.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbValueDatatype.SelectedIndex = 1;

            cmbUnitDatatype.DataSource = Unitdatatypes;
            cmbUnitDatatype.ValueMember = "valueIndex";
            cmbUnitDatatype.DisplayMember = "valueDatatype";
            cmbUnitDatatype.SelectedIndex = cmbUnitDatatype.FindStringExact("");
            cmbUnitDatatype.DropDownStyle = ComboBoxStyle.DropDownList;


            cmbResolutionDatatype.DataSource = Resdatatypes;
            cmbResolutionDatatype.ValueMember = "valueIndex";
            cmbResolutionDatatype.DisplayMember = "valueDatatype";
            cmbResolutionDatatype.SelectedIndex = cmbResolutionDatatype.FindStringExact("");
            cmbResolutionDatatype.DropDownStyle = ComboBoxStyle.DropDownList;


            cmbEndianess.DataSource = Endianessvalues;
            cmbEndianess.ValueMember = "valueIndex";
            cmbEndianess.DisplayMember = "valueDatatype";
            cmbEndianess.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbAlarmDatatype.DataSource = alarmdatatypes;
            cmbAlarmDatatype.ValueMember = "valueIndex";
            cmbAlarmDatatype.DisplayMember = "valueDatatype";
            cmbAlarmDatatype.SelectedIndex = cmbAlarmDatatype.FindStringExact("");
            cmbAlarmDatatype.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbAlarmStatus.DataSource = alarmstatusdatatypes;
            cmbAlarmStatus.ValueMember = "valueIndex";
            cmbAlarmStatus.DisplayMember = "valueDatatype";
            cmbAlarmStatus.SelectedIndex = cmbAlarmDatatype.FindStringExact("");
            cmbAlarmStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private class Datatypes
        {
            public int valueIndex { get; set; }

            public string valueDatatype { get; set; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    } 
}
