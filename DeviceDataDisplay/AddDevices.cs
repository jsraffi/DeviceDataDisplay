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
        private DataGridView DeviceGVRef;
        private bool validateStatus;
       
        public AddDevices()
        {
            InitializeComponent();
        }
        public AddDevices(ref DataGridView devicegv)
        {
            DeviceGVRef = devicegv;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool savechk = SavetoDB();
            if(savechk)
            {
                RefershData();
                this.Close();
            }

        }
        private void RefershData()
        {
            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                DeviceGVRef.DataSource = null;
                DeviceGVRef.Rows.Clear();
                DeviceGVRef.Columns.Clear();
                Connection.Open();
                string query = "select deviceID,device_name,slaveID,value_start_address ,value_return_datatype ,unit_start_address ,unit_return_datatype,alarm_start_address,alarm_return_datatype,resolution_start_address,resolution_return_datatype,alarm_status_start_address,alarm_status_return_datatype,channel_name_address,channel_name_length,min_level_address,min_level_length,max_level_address,max_level_length,Endianess from devices"; //,alarm_status_start_address,alarm_status_return_datatype
                MySqlDataAdapter deviceadapter = new MySqlDataAdapter(query, Connection);
                DataSet devicedata = new DataSet();
                deviceadapter.Fill(devicedata, "devices");
                DataTable tbldevices = new DataTable();
                tbldevices = devicedata.Tables["devices"];

                DeviceGVRef.DataSource = tbldevices;

                DeviceGVRef.Columns["deviceID"].ReadOnly = true;
                DeviceGVRef.Columns["device_name"].ReadOnly = false;
                DeviceGVRef.Columns["slaveID"].ReadOnly = false;
                DeviceGVRef.Columns["value_start_address"].ReadOnly = false;
                DeviceGVRef.Columns["value_return_datatype"].ReadOnly = false;
                DeviceGVRef.Columns["unit_start_address"].ReadOnly = false;
                DeviceGVRef.Columns["unit_return_datatype"].ReadOnly = false;
                DeviceGVRef.Columns["alarm_start_address"].ReadOnly = false;
                DeviceGVRef.Columns["alarm_return_datatype"].ReadOnly = false;
                DeviceGVRef.Columns["resolution_start_address"].ReadOnly = false;
                DeviceGVRef.Columns["resolution_return_datatype"].ReadOnly = false;
                DeviceGVRef.Columns["alarm_status_start_address"].ReadOnly = false;
                DeviceGVRef.Columns["alarm_status_return_datatype"].ReadOnly = false;
                DeviceGVRef.Columns["channel_name_address"].ReadOnly = false;
                DeviceGVRef.Columns["channel_name_length"].ReadOnly = false;
                DeviceGVRef.Columns["min_level_address"].ReadOnly = false;
                DeviceGVRef.Columns["min_level_length"].ReadOnly = false;
                DeviceGVRef.Columns["max_level_address"].ReadOnly = false;
                DeviceGVRef.Columns["max_level_length"].ReadOnly = false;
                DeviceGVRef.Columns["Endianess"].ReadOnly = true;

                DeviceGVRef.Columns[0].Width = 125;
                DeviceGVRef.Columns[1].Width = 150;
                DeviceGVRef.Columns[1].HeaderText = "Device Name";
                DeviceGVRef.Columns[2].Width = 125;
                DeviceGVRef.Columns[2].HeaderText = "SlaveID";
                DeviceGVRef.Columns[3].Width = 125;
                DeviceGVRef.Columns[3].HeaderText = "Value Address";
                DeviceGVRef.Columns[4].Width = 125;
                DeviceGVRef.Columns[4].HeaderText = "Value Datatype";
                DeviceGVRef.Columns[5].Width = 125;
                DeviceGVRef.Columns[5].HeaderText = "Unit Address";
                DeviceGVRef.Columns[6].Width = 125;
                DeviceGVRef.Columns[6].HeaderText = "Unit Datatype";
                DeviceGVRef.Columns[7].Width = 125;
                DeviceGVRef.Columns[7].HeaderText = "Alarm Address";
                DeviceGVRef.Columns[8].Width = 125;
                DeviceGVRef.Columns[8].HeaderText = "Alarm Datatype";
                DeviceGVRef.Columns[9].Width = 125;
                DeviceGVRef.Columns[9].HeaderText = "Res Address";
                DeviceGVRef.Columns[10].Width = 125;
                DeviceGVRef.Columns[10].HeaderText = "Res Datatype";
                DeviceGVRef.Columns[11].Width = 150;
                DeviceGVRef.Columns[11].HeaderText = "Alarm status address";
                DeviceGVRef.Columns[12].Width = 200;
                DeviceGVRef.Columns[12].HeaderText = "Alarm status Datatype";
                DeviceGVRef.Columns[13].Width = 150;
                DeviceGVRef.Columns[13].HeaderText = "Channel Name Address";

                DeviceGVRef.Columns[14].Width = 150;
                DeviceGVRef.Columns[14].HeaderText = "Channel Length";

                DeviceGVRef.Columns[15].Width = 150;
                DeviceGVRef.Columns[15].HeaderText = "Min level address";

                DeviceGVRef.Columns[16].Width = 150;
                DeviceGVRef.Columns[16].HeaderText = "Min level length";

                DeviceGVRef.Columns[17].Width = 150;
                DeviceGVRef.Columns[17].HeaderText = "Max level address";

                DeviceGVRef.Columns[18].Width = 150;
                DeviceGVRef.Columns[18].HeaderText = "Max level length";

                DeviceGVRef.Columns[19].Width = 150;



                DeviceGVRef.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;

                /*
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

                DeviceGVRef.Columns.Insert(4, datatypevaluecolumn);
                
                DeviceGVRef.Columns[5].Visible = false;

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

                DeviceGVRef.Columns.Insert(7, unitdatatypecolumn);
                DeviceGVRef.Columns[8].Visible = false;


                DataGridViewComboBoxCell alarmdatatypes = new DataGridViewComboBoxCell();
                alarmdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                alarmdatatypes.ValueMember = "Key";
                alarmdatatypes.DisplayMember = "Value";
                DataGridViewColumn alarmdatatypecolumn = new DataGridViewColumn(alarmdatatypes);
                alarmdatatypecolumn.HeaderText = "Alarm datatype";
                alarmdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                alarmdatatypecolumn.Width = 150;

                DeviceGVRef.Columns.Insert(10, alarmdatatypecolumn);
                DeviceGVRef.Columns[11].Visible = false;

                DataGridViewComboBoxCell resdatatypes = new DataGridViewComboBoxCell();
                resdatatypes.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                resdatatypes.ValueMember = "Key";
                resdatatypes.DisplayMember = "Value";
                DataGridViewColumn resdatatypecolumn = new DataGridViewColumn(resdatatypes);
                resdatatypecolumn.HeaderText = "Res datatype";
                resdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                resdatatypecolumn.Width = 150;

                DeviceGVRef.Columns.Insert(13, resdatatypecolumn);
                DeviceGVRef.Columns[14].Visible = false;


                
                DataGridViewComboBoxCell alarmstatus = new DataGridViewComboBoxCell();
                alarmstatus.DataSource = new BindingSource(modbus_unit_alaram_res_datatypes, null);
                alarmstatus.ValueMember = "Key";
                alarmstatus.DisplayMember = "Value";
                DataGridViewColumn alarmstatusdatatypecolumn = new DataGridViewColumn(alarmstatus);
                alarmstatusdatatypecolumn.HeaderText = "Alarm Status Datatype";
                alarmstatusdatatypecolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                alarmstatusdatatypecolumn.Width = 150;

                DeviceGVRef.Columns.Insert(16, alarmstatusdatatypecolumn);
                DeviceGVRef.Columns[17].Visible = false;

                */

                Dictionary<int, string> endianess = new Dictionary<int, string>()
                {
                    { 0, "LittleEndian"},
                    {1, "BigEndian" }
                };

                DataGridViewComboBoxCell endianessvalue = new DataGridViewComboBoxCell()
                {   
                    DataSource = new BindingSource(endianess,null),
                    ValueMember = "Key",
                    DisplayMember = "Value"
                };

                DataGridViewColumn endianessvaluecolumn = new DataGridViewColumn(endianessvalue)
                {
                    HeaderText = "Endianess",
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Width = 150
                };
                
                DeviceGVRef.Columns.Insert(19, endianessvaluecolumn);
                DeviceGVRef.Columns[20].Visible = false;


                /*

                foreach (DataGridViewRow item in DeviceGVRef.Rows)
                {
                    item.Cells[4].Value = item.Cells[5].Value;
                    item.Cells[7].Value = item.Cells[8].Value;
                    item.Cells[10].Value = item.Cells[11].Value;
                    item.Cells[13].Value = item.Cells[14].Value;
                    item.Cells[16].Value = item.Cells[17].Value;
                    item.Cells[18].Value = item.Cells[19].Value;
                    item.Height = 30;
                }
                */
                foreach (DataGridViewRow item in DeviceGVRef.Rows)
                {
                    item.Height = 30;
                    item.Cells[19].Value = item.Cells[20].Value;
                }


                DeviceGVRef.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;

                DeviceGVRef.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[15].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[17].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[18].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.Columns[19].SortMode = DataGridViewColumnSortMode.NotSortable;
                DeviceGVRef.AllowUserToAddRows = false;


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
                using (MySqlConnection connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
                {
                    string unitaddress = (txtUnitAddress.Text != "") ? txtUnitAddress.Text : "null";
                    string unitdatatype = (txtUnitsLength.Text != "") ? txtUnitsLength.Text : "null";

                    string alarmaddress = (txtAlarmAddress.Text != "") ? txtAlarmAddress.Text : "null";
                    string alarmdatatype = (txtAlarmLength.Text != "") ? txtAlarmLength.Text : "null";

                    string resaddress = (txtResolutionAddress.Text != "") ? txtResolutionAddress.Text : "null";
                    string resdatatype = (txtResLength.Text != "") ? txtResLength.Text : "null";

                    string alarmstatusaddress = (txtAlarmStatus.Text != "") ? txtAlarmStatus.Text : "null";
                    string alarmstatusdatatype = (txtAlarmStatusLength.Text != "") ? txtAlarmStatusLength.Text : "null";

                    string channelnameaddress = (txtChannelNameAddr.Text != "") ? txtChannelNameAddr.Text : "null";
                    string channellength = (txtChannelNameLength.Text != "") ? txtChannelNameLength.Text : "null";

                    string maxleveladdress = (txtMaxLevelAddr.Text != "") ? txtMaxLevelAddr.Text : "null";
                    string maxlevellength = (txtMaxLevelLength.Text != "") ? txtMaxLevelLength.Text : "null";

                    string minlevelhaddress = (txtMinLevelAddr.Text != "") ? txtMinLevelAddr.Text : "null";
                    string minlevellength = (txtMinLevelLength.Text != "") ? txtMinLevelLength.Text : "null";
               
                    string SQL = "Insert into devices(device_name, slaveID, value_start_address, value_return_datatype," +
                                 "unit_start_address, unit_return_datatype, alarm_start_address, alarm_return_datatype," +
                                  "resolution_start_address, resolution_return_datatype,alarm_status_start_address,alarm_status_return_datatype,channel_name_address,channel_name_length,min_level_address,min_level_length,max_level_address,max_level_length,Endianess)" +
                                  "Values('" + txtDeviceName.Text + "'," + txtSlaveID.Text +
                                  "," + txtValueAddress.Text + "," + txtValueLength.Text +
                                  "," + unitaddress + "," + unitdatatype +
                                  "," + alarmaddress+ "," + alarmdatatype+
                                  "," + resaddress + ","+ resdatatype +
                                  "," + alarmstatusaddress + "," + alarmstatusdatatype +
                                  "," + channelnameaddress + "," + channellength +
                                  "," + minlevelhaddress + "," + minlevellength +
                                  "," + maxleveladdress + "," + maxlevellength +
                                  "," + cmbEndianess.SelectedValue + ")";

                    MySqlCommand cmdadddevice = new MySqlCommand()
                    {
                        CommandType = CommandType.Text,
                        CommandText = SQL,
                        Connection = connection
                    };
                    
                    connection.Open();
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
        private bool validate_form()
        {
            int outvalue;
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
                lblStatus.Text = "Please enter a slaveid value between 0 and 247";
                validateStatus = false;
                return false;
            }
            if (!(int.TryParse(txtValueAddress.Text, out outvalue)))
            {
                txtValueAddress.Focus();
                lblStatus.Text = "value address required and should be numeric";
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

            if (!(int.TryParse(txtValueLength.Text, out outvalue)))
            {
                txtValueLength.Focus();
                lblStatus.Text = "Value length required and should be numeric";
                validateStatus = false;
                return false;
            }
            else if (outvalue < 0 || outvalue > 9999)
            {
                txtValueLength.Focus();
                lblStatus.Text = "value length is between 0 and 9999";
                validateStatus = false;
                return false;

            }
            if ((txtUnitAddress.Text =="") ^ (txtUnitsLength.Text == ""))
            {
                txtUnitAddress.Focus();
                lblStatus.Text = "Please enter values for both unit address and unit length or leave both blank";
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
                if (!(int.TryParse(txtUnitsLength.Text, out outvalue)))
                {
                    txtUnitsLength.Focus();
                    lblStatus.Text = "Unit length should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtUnitsLength.Focus();
                    lblStatus.Text = "Unit length should be between 0 and 9999";
                    validateStatus = false;
                    return false;

                }
            }

            if ((txtResolutionAddress.Text == "") ^ (txtResLength.Text == ""))
            {
                txtResolutionAddress.Focus();
                lblStatus.Text = "Please enter values for both resolution address and resolution length or leave both blank";
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

                if (!(int.TryParse(txtResLength.Text, out outvalue)))
                {
                    txtResLength.Focus();
                    lblStatus.Text = "Resolution length should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtResLength.Focus();
                    lblStatus.Text = "Resolution length should be between 0 and 9999";
                    validateStatus = false;
                    return false;

                }
            }

            if ((txtAlarmAddress.Text == "") ^ (txtAlarmLength.Text == ""))
            {
                txtAlarmAddress.Focus();
                lblStatus.Text = "Please enter values for both Alarm address and Alarm length or leave both blank";
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
                if (!(int.TryParse(txtAlarmLength.Text, out outvalue)))
                {
                    txtAlarmLength.Focus();
                    lblStatus.Text = "Alarm length should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtAlarmLength.Focus();
                    lblStatus.Text = "Alarm length should be between 0 and 9999";
                    validateStatus = false;
                    return false;

                }
            }
            if ((txtAlarmStatus.Text == "") ^ (txtAlarmStatusLength.Text == ""))
            {
                txtAlarmStatus.Focus();
                lblStatus.Text = "Please enter values for both Alarm status address and Alarm status length or leave both blank";
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
                    lblStatus.Text = "Alarm status address should be between 0 and 9999";
                    validateStatus = false;
                    return false;

                }
                if (!(int.TryParse(txtAlarmStatusLength.Text, out outvalue)))
                {
                    txtAlarmStatusLength.Focus();
                    lblStatus.Text = "Alarm status length should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtAlarmStatusLength.Focus();
                    lblStatus.Text = "Alarm status length should be between 0 and 9999";
                    validateStatus = false;
                    return false;

                }
            }

            if ((txtChannelNameAddr.Text == "") ^ (txtChannelNameLength.Text == ""))
            {
                txtChannelNameAddr.Focus();
                lblStatus.Text = "Please enter values for both channel address and channel length or leave both blank";
                validateStatus = false;
                return false;
            }
            else if (txtChannelNameAddr.Text != "")
            {
                if (!(int.TryParse(txtChannelNameAddr.Text, out outvalue)))
                {
                    txtChannelNameAddr.Focus();
                    lblStatus.Text = "Channel name address should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtChannelNameAddr.Focus();
                    lblStatus.Text = "Channel name address should be between 0 and 9999";
                    validateStatus = false;
                    return false;
                }

                if (!(int.TryParse(txtChannelNameLength.Text, out outvalue)))
                {
                    txtChannelNameLength.Focus();
                    lblStatus.Text = "Channel name length should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtChannelNameLength.Focus();
                    lblStatus.Text = "Channel name length should be between 0 and 9999";
                    validateStatus = false;
                    return false;
                }
            }

            if ((txtMaxLevelAddr.Text == "") ^ (txtMaxLevelLength.Text == ""))
            {
                txtMaxLevelAddr.Focus();
                lblStatus.Text = "Please enter values for both max level address and max level length or leave both blank";
                validateStatus = false;
                return false;
            }
            else if (txtMaxLevelAddr.Text != "")
            {
                if (!(int.TryParse(txtMaxLevelAddr.Text, out outvalue)))
                {
                    txtMaxLevelAddr.Focus();
                    lblStatus.Text = "Max level address should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtMaxLevelAddr.Focus();
                    lblStatus.Text = "Max level address should be between 0 and 9999";
                    validateStatus = false;
                    return false;
                }

                if (!(int.TryParse(txtMaxLevelLength.Text, out outvalue)))
                {
                    txtMaxLevelLength.Focus();
                    lblStatus.Text = "Max level length should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtMaxLevelLength.Focus();
                    lblStatus.Text = "Max level length should be between 0 and 9999";
                    validateStatus = false;
                    return false;
                }

            }
            if ((txtMinLevelAddr.Text == "") ^ (txtMinLevelLength.Text == ""))
            {
                txtMinLevelAddr.Focus();
                lblStatus.Text = "Please enter values for both Min level address and Min level length or leave both blank";
                validateStatus = false;
                return false;
            }
            else if (txtMaxLevelAddr.Text != "")
            {
                if (!(int.TryParse(txtMinLevelAddr.Text, out outvalue)))
                {
                    txtMinLevelAddr.Focus();
                    lblStatus.Text = "Min level address should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtMinLevelAddr.Focus();
                    lblStatus.Text = "Min level address should be between 0 and 9999";
                    validateStatus = false;
                    return false;
                }

                if (!(int.TryParse(txtMinLevelLength.Text, out outvalue)))
                {
                    txtMinLevelLength.Focus();
                    lblStatus.Text = "Min level length should be numeric";
                    validateStatus = false;
                    return false;
                }

                if (outvalue < 0 || outvalue > 9999)
                {
                    txtMinLevelLength.Focus();
                    lblStatus.Text = "Min level length should be between 0 and 9999";
                    validateStatus = false;
                    return false;
                }

            }
            var address = new List<string>();
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
            if (txtChannelNameAddr.Text != "")
            {
                address.Add(txtChannelNameAddr.Text);
            }
            if (txtMaxLevelAddr.Text != "")
            {
                address.Add(txtMaxLevelAddr.Text);
            }
            if (txtMinLevelAddr.Text != "")
            {
                address.Add(txtMinLevelAddr.Text);
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
            /*
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
            */
            List<Datatypes> endianessvalues = new List<Datatypes>()
            {
                new Datatypes(0, "Little Endian"),
                new Datatypes(1, "Big Endian")
            };
            /*
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
            */

            cmbEndianess.DataSource = endianessvalues;
            cmbEndianess.ValueMember = "ValueIndex";
            cmbEndianess.DisplayMember = "ValueDatatype";
            cmbEndianess.DropDownStyle = ComboBoxStyle.DropDownList;

            /*
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
            */
        }
        internal class Datatypes
        {
            public Datatypes(int valuindex,string valuedatatype)
            {
                ValueDatatype = valuedatatype;
                ValueIndex = valuindex;
            }
            public int ValueIndex { get; set; }

            public string ValueDatatype { get; set; }
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
