using System;
using System.Collections;
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
using System.Threading;
using DeviceDataDisplay.Modbus;
using System.IO.Ports;

namespace DeviceDataDisplay
{
    public partial class DeviceDataDisplay : Form
    {
        modbus mb = new modbus();

        SerialPort sp = new SerialPort();

        System.Threading.Timer tmrChannel1;
        System.Threading.Timer tmrChannel2;
        System.Threading.Timer tmrChannel3;
        System.Threading.Timer tmrChannel4;
        System.Threading.Timer tmrChannel5;
        System.Threading.Timer tmrChannel6;
        System.Threading.Timer tmrChannel7;
        System.Threading.Timer tmrChannel8;
        System.Threading.Timer tmrChannel9;
        System.Threading.Timer tmrChannel10;
        System.Threading.Timer tmrChannel11;
        System.Threading.Timer tmrChannel12;
        System.Threading.Timer tmrChannel13;
        System.Threading.Timer tmrChannel14;
        System.Threading.Timer tmrChannel15;
        System.Threading.Timer tmrChannel16;
        System.Threading.Timer tmrChannel17;
        System.Threading.Timer tmrChannel18;
        System.Threading.Timer tmrChannel19;
        System.Threading.Timer tmrChannel20;
        System.Threading.Timer tmrChannel21;
        System.Threading.Timer tmrChannel22;
        System.Threading.Timer tmrChannel23;
        System.Threading.Timer tmrChannel24;
        System.Threading.Timer tmrChannel25;
        System.Threading.Timer tmrChannel26;
        System.Threading.Timer tmrChannel27;
        System.Threading.Timer tmrChannel28;
        System.Threading.Timer tmrChannel29;
        System.Threading.Timer tmrChannel30;
        System.Threading.Timer tmrChannel31;
        System.Threading.Timer tmrChannel32;
        
        bool flag2 = true;
        bool flag3 = true;
        bool flag4 = true;
        bool flag5 = true;
        bool flag6 = true;
        bool flag7 = true;
        bool flag8 = true;
        bool flag9 = true;
        bool flag10 = true;
        bool flag11 = true;
        bool flag12 = true;
        bool flag13 = true;
        bool flag14 = true;
        bool flag15 = true;
        bool flag16 = true;
        bool flag17 = true;
        bool flag18 = true;
        bool flag19 = true;
        bool flag20 = true;
        bool flag21 = true;
        bool flag22 = true;
        bool flag23 = true;
        bool flag24 = true;
        bool flag25 = true;
        bool flag26= true;
        bool flag27 = true;
        bool flag28 = true;
        bool flag29 = true;
        bool flag30 = true;
        bool flag31= true;
        bool flag32 = true;
        bool flag = true;

        bool ConnectionStatus = false;

        //loading database values in list for the device
        List<ushort> devicevalues1 = new List<ushort>();
        Dictionary<ushort, int> deviceresolution1 = new Dictionary<ushort, int>();
        Dictionary<ushort, string> deviceunits1 = new Dictionary<ushort, string>();
        string lastdisplayedvalue;
        bool firstcalltochannel1 = true;

        int CurrentNoOfChannelSelected = 0;
        public DeviceDataDisplay()
        {
            InitializeComponent();

            
        }

        private void DeviceDataDisplay_Load(object sender, EventArgs e)
        {
            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());

            string[] channels = new string[] { "1", "2", "3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31","32"};
            
            ShowChannels.Items.AddRange(channels);

            ChannelSetting();
        }

        private void ChannelTimer1(object state)
        {
            try
            {
                if (firstcalltochannel1)
                {
                    //if application is running not offloaded the following list and dictionary needs to be cleared
                    //because channel setting connected to  a device may have changed 
                    if (devicevalues1.Count > 0)
                    {
                        devicevalues1.Clear();
                    }

                    if (deviceresolution1.Count > 0)
                    {
                        deviceresolution1.Clear();
                    }
                    if (deviceunits1.Count > 0)
                    {
                        deviceunits1.Clear();
                    }

                    MySqlConnection Connection1 = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
                    Connection1.Open();
                    string querydev = "select deviceID from devices_to_channels where channelID =1";
                    MySqlCommand getdevice = new MySqlCommand(querydev, Connection1);

                    // get the device id for channel 1
                    int deviceID = (int) getdevice.ExecuteScalar();

                    //get the device setting for channel1
                    string query = "Select deviceID,device_name,slaveID,value_start_address,value_return_datatype,unit_start_address,unit_return_datatype,alarm_start_address,alarm_return_datatype,resolution_start_address,resolution_return_datatype,Endianess from devices where deviceID ="+ deviceID;
                    getdevice.CommandText = query;
                    getdevice.Connection = Connection1;
                    MySqlDataReader devicereader = getdevice.ExecuteReader();
                    string device_name = "";
               
                    //add device data to list devicevalues1

                    if(devicereader.HasRows )
                    {
                        while(devicereader.Read())
                        {
                            devicevalues1.Add(devicereader.GetUInt16(0));//deviceID 0
                            device_name = devicereader.GetString(1); //device_name
                            devicevalues1.Add(devicereader.GetUInt16(2));//slaveID 1
                            devicevalues1.Add(devicereader.GetUInt16(3));//value_start_address 2
                            devicevalues1.Add(devicereader.GetUInt16(4));//value_return_datatype 3

                           /* 4 unit_start_address*/ devicevalues1.Add((!(devicereader.IsDBNull(5)) ? devicereader.GetUInt16(5):Convert.ToUInt16(60000)));
                           /* 5unit_return_datatype */ devicevalues1.Add((!(devicereader.IsDBNull(6)) ? devicereader.GetUInt16(6) : Convert.ToUInt16(60000)));
                           /* 6alarm_start_datatype */ devicevalues1.Add((!(devicereader.IsDBNull(7)) ? devicereader.GetUInt16(7) : Convert.ToUInt16(60000))); 
                           /* 7alarm_return_datatype */ devicevalues1.Add((!(devicereader.IsDBNull(8)) ? devicereader.GetUInt16(8) : Convert.ToUInt16(60000))); 
                            /* 8resolution_start_address */devicevalues1.Add((!(devicereader.IsDBNull(9)) ? devicereader.GetUInt16(9) : Convert.ToUInt16(60000)));
                           /* 9resolution_return_datatype */ devicevalues1.Add((!(devicereader.IsDBNull(10)) ? devicereader.GetUInt16(10) : Convert.ToUInt16(60000)));
                           /* 10Endianess */devicevalues1.Add((!(devicereader.IsDBNull(11)) ? devicereader.GetUInt16(11) : Convert.ToUInt16(60000)));
                        }
                    }

                    devicereader.Close();

                    //adding units value to dictionary from db one time, if the value is set as null
                    //by the user an out of range value of 6000 is set to check for nullable values
                    // a nullable ushort cannot be defined as modbus expect non-nullable datatype

                    if(devicevalues1[4]!= 60000)
                    {
                        var queryunits = "Select units_index,units_value from device_units where deviceID="+ deviceID +" order by units_index ";
                        getdevice.CommandText = queryunits;
                        getdevice.Connection = Connection1;
                        MySqlDataReader unitReader = getdevice.ExecuteReader();

                        if (unitReader.HasRows)
                        {
                            while (unitReader.Read())
                            {
                                deviceunits1.Add(unitReader.GetUInt16(0),unitReader.GetString(1));
                            }
                        }
                        unitReader.Close();
                    }
                    
                    // same as units if resolution is defined than add those values to dictionary
                    if(devicevalues1[8] != 60000)
                    { 
                        var queryres = "Select resolution_index,resolution_value from device_resolution where deviceID="+ deviceID + " order by resolution_index ";
                        getdevice.CommandText = queryres;
                        getdevice.Connection = Connection1;
                        MySqlDataReader resolutionReader = getdevice.ExecuteReader();

                        if(resolutionReader.HasRows)
                        {
                            while(resolutionReader.Read())
                            {
                                deviceresolution1.Add(resolutionReader.GetUInt16(0),resolutionReader.GetInt32(1));
                            }
                        }
                        resolutionReader.Close();
                    }
                    // get database values for just once store it in list and dictionary's and set the flag to false
                    firstcalltochannel1 = false;
                }
               
                // try catch inside try catch just to get modbus errors
                try {

                    //reteriving units values
                    //poll modbus if units are confgured by the user
                    string unit_value_db = "";
                    //array postion 4 denotes unit value address
                    if (devicevalues1[4] != 60000)
                    {   
                        //address 5 denotes the return address type of units, 16bit(integer in C short in C#)or long.
                        // In this case it is integer (short), length of addresses to be read is one for integer
                        //and 2 for long or int32 in C#
                        ushort[] unit_value = new ushort[devicevalues1[5]];

                        //address 1 denotess slaveid,address4=units start address,address5=unints return datatypes
                        mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[4], devicevalues1[5], ref unit_value);
                        
                        // get the units value from dictionary using key we get from device
                        unit_value_db = deviceunits1.First(k => k.Key == unit_value[0]).Value;

                        //allow the sometimme gap before requesting the meter
                        Thread.Sleep(50);
                    }
                    
                    //for value reteriving
                    int intValue=0;
                    //value devicevalue1[3]  denotes meter value return datatype, 
                    // if its ulong or int32 , modbus returns two 16 bit values
                    //which needs to be bit shifted to create a 32 bit value
                    //devicevalue1[2]= meter value start address
                    if (devicevalues1[3]==2)
                    { 
                        ushort[] values = new ushort[devicevalues1[3]];
                        mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[2], devicevalues1[3], ref values);
                        //concat two 16 bit values using loop
                        //devicevalues1[10] holds the value for endianess 0=little endian and 1 = big endian
                        if (devicevalues1[10] == 0)
                        { 
                            for (int i = 0; i < devicevalues1[3] / 2; i++)
                            {
                                intValue = values[2 * i];
                                intValue <<= 16;
                                intValue += values[2 * i + 1];//for little endian
                            }
                        }
                        else if(devicevalues1[10] == 1)
                        {
                            for (int i = 0; i < devicevalues1[3] / 2; i++)
                            {
                                intValue = values[2 * i +1];
                                intValue <<= 16;
                                intValue += values[2 * i];//for big endian 
                            }

                        }
                        Thread.Sleep(50);
                    }
                    else if(devicevalues1[3] == 1)// if meter value return datatype is ushort or integer(C) no need shift it is only 16bit value
                    {
                        ushort[] values = new ushort[devicevalues1[3]];
                        mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[2], devicevalues1[3], ref values);
                        intValue = (int)values[0];
                        Thread.Sleep(50);

                    }
                    //get resolution
                    double dval = (double)intValue;
                    string itemString = "";
                    // same like units only address begin and end value changes/see while loop to know address
                    if (devicevalues1[8] != 60000)
                    {
                        ushort[] resolution_value = new ushort[devicevalues1[9]];
                        mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[8], devicevalues1[9], ref resolution_value);
                        //loop thru the reoslution dictionary
                        foreach (var resolution in deviceresolution1)
                        {   
                            // if the key matchess the meter returned value
                            if (resolution.Key == resolution_value[0])
                            {   
                                string resval = resolution.Value.ToString();// get the value for the matched key
                                //to format for decimal places we have to give value like ex "0.00" for two decimals to ToSring("0.00")
                                //the db value for decimal places returns 1000,100,10 or 1, except for 1 all values
                                //will be formated for decimal places
                                
                                if (resolution.Value != 1)
                                {
                                    string decimalplaces = "0." + resval.Substring(1, (resval.Length - 1));
                                    itemString = (dval / resolution.Value).ToString(decimalplaces) + " " + unit_value_db;
                                }
                                else if(resolution.Value == 1)
                                {
                                    itemString = dval.ToString() + " " + unit_value_db;
                                }
                                
                                
                            }
                        }
                        Thread.Sleep(50);
                    }

                    if(itemString=="")
                    {
                        string unints = (unit_value_db != "") ? " " + unit_value_db : "";
                        itemString = intValue.ToString() + unints;
                    }

                    lastdisplayedvalue = itemString;

                    this.Invoke((MethodInvoker)delegate
                    {
                        var p = Controls.Find("Channel1", false);
                        p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel1").Text = itemString;
                    });
                    
                }
                catch(Exception err)
                {
                        this.Invoke((MethodInvoker)delegate
                        {   
                            lblStatus.Text = "Error in modbus read: " + err.Message;
                        });
                }
                finally
                {
                    if (ConnectionStatus == false)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            var p = Controls.Find("Channel1", false);
                            p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel1").Text = lastdisplayedvalue;

                            lblStatus.Text = "Timer polling stopped ";
                        });
                        tmrChannel1.Dispose();
                    }
                    
                }
            }
            catch (Exception err)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text="DB or thread Error: " + err.Message;
                });
            }
            if(firstcalltochannel1 == false)
            { 
                tmrChannel1.Change(TimeSpan.FromMilliseconds(50), TimeSpan.FromMilliseconds(-1));
            }
        }
        
        private void ChannelTimer2(object state)
        {

            if (flag2 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel2", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel2").ForeColor = Color.Red;
                });
                flag2 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel2", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel2").ForeColor = Color.Green;
                });

                flag2 = true;
            }
            tmrChannel2.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer3(object state)
        {

            if (flag3 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel3", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel3").ForeColor = Color.Red;
                });
                flag3 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel3", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel3").ForeColor = Color.Green;
                });

                flag3 = true;
            }
            tmrChannel3.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer4(object state)
        {

            if (flag4 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel4", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel4").ForeColor = Color.Red;
                });
                flag4 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel4", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel4").ForeColor = Color.Green;
                });

                flag4 = true;
            }
            tmrChannel4.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer5(object state)
        {

            if (flag5 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel5", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel5").ForeColor = Color.Red;
                });
                flag5 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel5", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel5").ForeColor = Color.Green;
                });

                flag5 = true;
            }
            tmrChannel5.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer6(object state)
        {

            if (flag6 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel6", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel6").ForeColor = Color.Red;
                });
                flag6 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel6", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel6").ForeColor = Color.Green;
                });

                flag6 = true;
            }
            tmrChannel6.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer7(object state)
        {

            if (flag7 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel7", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel7").ForeColor = Color.Red;
                });
                flag7 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel7", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel7").ForeColor = Color.Green;
                });

                flag7 = true;
            }
            tmrChannel7.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer8(object state)
        {

            /*if (flag8 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel8", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel8").ForeColor = Color.Red;
                });
                flag8 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel8", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel8").ForeColor = Color.Green;
                });

                flag8 = true;
            }*/
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel8", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel8").ForeColor = Color.Red;
                });

            }
            catch(Exception e)
            {

            }
            tmrChannel8.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer9(object state)
        {

            if (flag9 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel9", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel9").ForeColor = Color.Red;
                });
                flag9 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel9", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel9").ForeColor = Color.Green;
                });

                flag9 = true;
            }
            tmrChannel9.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer10(object state)
        {

            if (flag10 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel10", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel10").ForeColor = Color.Red;
                });
                flag10 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel10", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel10").ForeColor = Color.Green;
                });

                flag10 = true;
            }
            tmrChannel10.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer11(object state)
        {

            if (flag11 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel11", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel11").ForeColor = Color.Red;
                });
                flag11 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel11", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel11").ForeColor = Color.Green;
                });

                flag11 = true;
            }
            tmrChannel11.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer12(object state)
        {

            if (flag12 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel12", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel12").ForeColor = Color.Red;
                });
                flag12 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel12", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel12").ForeColor = Color.Green;
                });

                flag12 = true;
            }
            tmrChannel12.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer13(object state)
        {

            if (flag13 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel13", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel13").ForeColor = Color.Red;
                });
                flag13 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel13", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel13").ForeColor = Color.Green;
                });

                flag13 = true;
            }
            tmrChannel13.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer14(object state)
        {

            if (flag14 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel14", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel14").ForeColor = Color.Red;
                });
                flag14 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel14", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel14").ForeColor = Color.Green;
                });

                flag14 = true;
            }
            tmrChannel14.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer15(object state)
        {

            if (flag15 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel15", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel15").ForeColor = Color.Red;
                });
                flag15 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel15", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel15").ForeColor = Color.Green;
                });

                flag15 = true;
            }
            tmrChannel15.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer16(object state)
        {

            if (flag16 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel16", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel16").ForeColor = Color.Red;
                });
                flag16 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel16", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel16").ForeColor = Color.Green;
                });

                flag16 = true;
            }
            tmrChannel16.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer17(object state)
        {

            if (flag17 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel17", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel17").ForeColor = Color.Red;
                });
                flag17 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel17", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel17").ForeColor = Color.Green;
                });

                flag17 = true;
            }
            tmrChannel17.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer18(object state)
        {

            if (flag18 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel18", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel18").ForeColor = Color.Red;
                });
                flag18 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel18", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel18").ForeColor = Color.Green;
                });

                flag18 = true;
            }
            tmrChannel18.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer19(object state)
        {

            if (flag19 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel19", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel19").ForeColor = Color.Red;
                });
                flag19 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel19", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel19").ForeColor = Color.Green;
                });

                flag19 = true;
            }
            tmrChannel19.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer20(object state)
        {

            if (flag20 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel20", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel20").ForeColor = Color.Red;
                });
                flag20 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel20", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel20").ForeColor = Color.Green;
                });

                flag20 = true;
            }
            tmrChannel20.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer21(object state)
        {

            if (flag21 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel21", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel21").ForeColor = Color.Red;
                });
                flag21= false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel21", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel21").ForeColor = Color.Green;
                });

                flag21 = true;
            }
            tmrChannel21.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }
        private void ChannelTimer22(object state)
        {

            if (flag22 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel22", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel22").ForeColor = Color.Red;
                });
                flag22 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel22", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel22").ForeColor = Color.Green;
                });

                flag22 = true;
            }
            tmrChannel22.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer23(object state)
        {

            if (flag23 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel23", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel23").ForeColor = Color.Red;
                });
                flag23 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel23", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel23").ForeColor = Color.Green;
                });

                flag23 = true;
            }
            tmrChannel23.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer24(object state)
        {

            if (flag24 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel24", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel24").ForeColor = Color.Red;
                });
                flag24 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel24", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel24").ForeColor = Color.Green;
                });

                flag24 = true;
            }
            tmrChannel24.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer25(object state)
        {

            if (flag25 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel25", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel25").ForeColor = Color.Red;
                });
                flag25 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel25", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel25").ForeColor = Color.Green;
                });

                flag25 = true;
            }
            tmrChannel25.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }


        private void ChannelTimer26(object state)
        {

            if (flag26 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel26", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel26").ForeColor = Color.Red;
                });
                flag26 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel26", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel26").ForeColor = Color.Green;
                });

                flag26 = true;
            }
            tmrChannel26.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }


        private void ChannelTimer27(object state)
        {

            if (flag27 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel27", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel27").ForeColor = Color.Red;
                });
                flag27 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel27", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel27").ForeColor = Color.Green;
                });

                flag27 = true;
            }
            tmrChannel27.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer28(object state)
        {

            if (flag28 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel28", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel28").ForeColor = Color.Red;
                });
                flag28 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel28", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel28").ForeColor = Color.Green;
                });

                flag28 = true;
            }
            tmrChannel28.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer29(object state)
        {

            if (flag29 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel29", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel29").ForeColor = Color.Red;
                });
                flag29 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel29", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel29").ForeColor = Color.Green;
                });

                flag29 = true;
            }
            tmrChannel29.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer30(object state)
        {

            if (flag30 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel30", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel30").ForeColor = Color.Red;
                });
                flag30 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel30", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel30").ForeColor = Color.Green;
                });

                flag30 = true;
            }
            tmrChannel30.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer31(object state)
        {

            if (flag31 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel31", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel31").ForeColor = Color.Red;
                });
                flag31 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel31", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel31").ForeColor = Color.Green;
                });

                flag31 = true;
            }
            tmrChannel31.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }

        private void ChannelTimer32(object state)
        {

            if (flag32 == true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel32", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel32").ForeColor = Color.Red;
                });
                flag32 = false;
            }
            else
            {

                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find("Channel32", false);
                    p[0].Controls.OfType<Label>().Single(l => l.Name == "lblvalueChannel32").ForeColor = Color.Green;
                });

                flag32 = true;
            }
            tmrChannel32.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
        }


        private void PaintPanelBorder(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid);

        }

        private void ChannelSetting(int noOfChannels=32, int columns=8,int rows=4)
        {
            
            if (noOfChannels >= 1 && noOfChannels <= 4)
            {
                if (noOfChannels == 1)
                {
                    rows = 1;
                    columns = 1;

                }
                else if (noOfChannels == 2)
                {
                    
                    rows = 1;
                    columns = 2;
                }
                else if (noOfChannels == 3)
                {
                    rows = 2;
                    columns = 2;
                }
                else if (noOfChannels == 4)
                {
                    
                    rows = 2;
                    columns = 2;
                }
            }
            else if (noOfChannels >= 5 && noOfChannels <= 8)
            {
                rows = 2;
                columns = 4;

            }
            else if (noOfChannels >= 9 && noOfChannels <= 12)
            {
                rows = 3;
                columns = 4;
                
            }
            else if (noOfChannels >= 13 && noOfChannels <= 16)
            {
                rows = 4;
                columns = 4;
                
            }
            else if (noOfChannels >= 13 && noOfChannels <= 16)
            {
                rows = 4;
                columns = 4;
                
            }
            else if (noOfChannels >= 17 && noOfChannels <= 20)
            {
                rows = 4;
                columns = 5;
                
            }
            else if (noOfChannels >= 21 && noOfChannels <= 24)
            {
                rows = 4;
                columns = 6;
                
            }
            else if (noOfChannels >= 25 && noOfChannels <= 28)
            {
                rows = 4;
                columns = 7;
                
            }
            else if (noOfChannels >= 29 && noOfChannels <= 32)
            {
                rows = 4;
                columns = 8;
                
            }



            int width = Screen.PrimaryScreen.WorkingArea.Width;
            int height = Screen.PrimaryScreen.WorkingArea.Height - 22;
            int panelheight = (height / rows);
            int panelwidth = (width / columns);

            
            MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
            Connection.Open();
            string query = "Select channel_no,display_name,channel_name,um.units as unitsmesure,value,minlevel,maxlevel,onlyminlevel,onlymaxlevel,alarmswitch from channels ch inner join unitsofmesurement um on ch.units=um.unitID";
            MySqlDataAdapter channeladapter = new MySqlDataAdapter(query, Connection);
            DataSet channelsdata = new DataSet();
            channeladapter.Fill(channelsdata, "channels");

            DataTable tblChannel = channelsdata.Tables["channels"];
            int channelid = 0;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (noOfChannels == 3 && i == 1 && j == 1) { break; }

                    if (noOfChannels >=5 && noOfChannels <=8)
                    { 
                        if(noOfChannels == 5 && i == 1 && j == 1) { break; }
                        if(noOfChannels == 6 && i == 1 && j == 2) { break; }
                        if(noOfChannels == 7 && i == 1 && j == 3) { break; }
                        if(noOfChannels == 8 && i == 1 && j == 4) { break; }
                    }

                    if (noOfChannels >= 9 && noOfChannels <= 12)
                    {
                        if (noOfChannels == 9 && i == 2 && j == 1) { break; }
                        if (noOfChannels == 10 && i == 2 && j == 2) { break; }
                        if (noOfChannels ==11 && i == 2 && j == 3) { break; }
                        if (noOfChannels == 12 && i == 2 && j == 4) { break; }
                    }

                    if (noOfChannels >= 13 && noOfChannels <= 16)
                    {
                        if (noOfChannels == 13 && i == 3 && j == 1) { break; }
                        if (noOfChannels == 14 && i == 3 && j == 2) { break; }
                        if (noOfChannels == 15 && i == 3 && j == 3) { break; }
                        if (noOfChannels == 16 && i == 3 && j == 4) { break; }
                    }
                    if (noOfChannels >= 17 && noOfChannels <= 20)
                    {
                        if (noOfChannels == 17 && i == 3 && j == 2) { break; }
                        if (noOfChannels == 18 && i == 3 && j == 3) { break; }
                        if (noOfChannels == 19 && i == 3 && j == 4) { break; }
                        if (noOfChannels == 20 && i == 3 && j == 5) { break; }
                    }
                    if (noOfChannels >= 21 && noOfChannels <= 24)
                    {
                        if (noOfChannels == 21 && i == 3 && j == 3) { break; }
                        if (noOfChannels == 22 && i == 3 && j == 4) { break; }
                        if (noOfChannels == 23 && i == 3 && j == 5) { break; }
                        if (noOfChannels == 24 && i == 3 && j == 6) { break; }
                    }

                    if (noOfChannels >= 25 && noOfChannels <= 28)
                    {
                        if (noOfChannels == 25 && i == 3 && j == 4) { break; }
                        if (noOfChannels == 26 && i == 3 && j == 5) { break; }
                        if (noOfChannels == 27 && i == 3 && j == 6) { break; }
                        if (noOfChannels == 28 && i == 3 && j == 7) { break; }
                    }

                    if (noOfChannels >= 29 && noOfChannels <= 32)
                    {
                        if (noOfChannels == 29 && i == 3 && j == 5) { break; }
                        if (noOfChannels == 30 && i == 3 && j == 6) { break; }
                        if (noOfChannels == 31 && i == 3 && j == 7) { break; }
                        if (noOfChannels == 32 && i == 3 && j == 8) { break; }
                    }

                    
                    Panel p = new Panel();
                    channelid = channelid + 1;
                    p.Name = "Channel" + channelid;
                    p.Height = panelheight;
                    p.Width = panelwidth;
                    p.BorderStyle = BorderStyle.None;
                    p.BackColor = Color.DarkBlue;
                    p.Paint += PaintPanelBorder;
                    
                    p.Location = new Point((panelwidth * j), (panelheight * i));
                    

                    if (noOfChannels == 1)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1restfontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
                        
                        if(Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        { 
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["maxlevel"]));
                        }
                        else if(Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["maxlevel"]));
                        }
                        else if(Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString() ,fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["maxlevel"]));
                        }
                    }
                    if (noOfChannels ==2)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2restfontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();

                        if (Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }


                    }
                    if (noOfChannels >=3 && noOfChannels <=4)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch34valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch34restfontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
                        

                        if (Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }

                    }
                    if (noOfChannels >= 5 && noOfChannels <= 8)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch58valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch58restfontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();

                        if (Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }


                    }

                    if (noOfChannels >= 9 && noOfChannels <= 12)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch912valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch912restfontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();

                        if (Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }

                    }
                    if (noOfChannels >= 13 && noOfChannels <= 16)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1316valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1316restfontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();

                        if (Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, null, fontvalue, fontChannelminmax, null, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                    }

                    if (noOfChannels >= 17 && noOfChannels <= 20)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1720valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1720restfontsize"]), FontStyle.Bold);
                        Font fontChannel = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["chname1720fontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();

                        if (Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString(), fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, null, fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }

                    }
                    if (noOfChannels >= 21 && noOfChannels <= 24)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2124valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2124restfontsize"]), FontStyle.Bold);
                        Font fontChannel = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["chnameafter20fontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();

                        if (Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString(), fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, null, fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }



                    }
                    if (noOfChannels >= 25 && noOfChannels <= 28)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2528valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2528restfontsize"]), FontStyle.Bold);
                        Font fontChannel = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["chnameafter20fontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();

                        if (Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString(), fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, null, fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }


                    }
                    if (noOfChannels >= 29 && noOfChannels <= 32)
                    {

                        DataRow drow = getchannel(tblChannel, channelid);
                        Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2932valuefontsize"]), FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2932restfontsize"]), FontStyle.Bold);
                        Font fontChannel = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["chnameafter20fontsize"]), FontStyle.Bold);
                        var value = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();

                        if (Convert.ToBoolean(drow["onlyminlevel"]) && Convert.ToBoolean(drow["onlymaxlevel"]))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlyminlevel"]) && !(Convert.ToBoolean(drow["onlymaxlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), null, fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else if (Convert.ToBoolean(drow["onlymaxlevel"]) && !(Convert.ToBoolean(drow["onlyminlevel"])))
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, drow["maxlevel"].ToString(), fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }
                        else
                        {
                            p = screenbuilder(p, value, drow["channel_name"].ToString(), null, null, fontvalue, fontChannelminmax,fontChannel, Convert.ToBoolean(drow["alarmswitch"]));
                        }


                    }
                    Controls.Add(p);
                    
                }
            }

        }
        
        
        private DataRow getchannel(DataTable memchannel,int channelno)
        {
            var result = (from channel in memchannel.AsEnumerable()
                          where channel.Field<int>("channel_no") == channelno
                          select channel).FirstOrDefault();

            return result;
            
        }
        
        private void mainMneuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ShowChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentNoOfChannelSelected = Convert.ToInt32(ShowChannels.SelectedItem.ToString());
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i].Name != "mainmenuStrip" && Controls[i].Name != "lblSelectChannel" && Controls[i].Name != "poller" && Controls[i].Name != "lblStatus")
                {
                    
                    Controls[i].Dispose();
                    
                }
            }
            
            ChannelSetting(CurrentNoOfChannelSelected, 3, 3);

        }

        private void setUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUnits setunits = new SetUnits();
            setunits.ShowDialog();
        }

        private void setLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLevel setlevels = new SetLevel();
            setlevels.ShowDialog();
        }

        private Panel screenbuilder(Panel p, string valuewithunits, string channelname, string minlevel, string maxlevel, Font valuefont, Font minmaxchannel, Font channel21above =null,bool alarmsetting=false)
        {

            Label lbl = new Label();
            //Adding value to panel and units
            Font fontChannel1 = valuefont;
            Font fontChannelminmax = minmaxchannel;
            lbl.Name = "lblvalue" + p.Name;
            lbl.Font = fontChannel1;
            lbl.AutoSize = true;
            lbl.Text = valuewithunits;
            Graphics g = CreateGraphics();
            SizeF extent = g.MeasureString(lbl.Text, lbl.Font);

            lbl.Height = Convert.ToInt32(extent.Height);
            lbl.Width = Convert.ToInt32(extent.Width);
            var x = (p.Width / 2) - (lbl.Width / 2);
            Point pointvalue = new Point(x, ((p.Height / 2) - (lbl.Height / 2)));

            lbl.Location = pointvalue;

            lbl.ForeColor = Color.White;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(lbl);

            //Adding channel to panel
            

            Label lblchannelname = new Label();
            if(channel21above == null)
            {
                lblchannelname.Font = fontChannelminmax;
            }
            else if(channel21above!=null)
            {
                lblchannelname.Font = channel21above;
            }
            
            lblchannelname.AutoSize = true;
            lblchannelname.Text = channelname;
            lblchannelname.Name = "lblchname" + p.Name;

            SizeF extentchannel = g.MeasureString(lblchannelname.Text, lblchannelname.Font);

            lblchannelname.Height = Convert.ToInt32(extentchannel.Height);
            lblchannelname.Width = Convert.ToInt32(extentchannel.Width);

            var xchannelname = (p.Width / 2) - (lblchannelname.Width / 2);
            Point pointvaluechannelname = new Point(xchannelname, (p.Height / 8));

            lblchannelname.Location = pointvaluechannelname;

            lblchannelname.ForeColor = Color.White;
            lblchannelname.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(lblchannelname);

            //adding min level

            if (minlevel != null)
            {
                Label lblmin = new Label();
                lblmin.Font = fontChannelminmax;
                lblmin.AutoSize = true;
                lblmin.Text = "Min = " + minlevel;
                lblmin.Name = "lblmin" + p.Name;

                SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                lblmin.Location = pointminlevel;

                lblmin.ForeColor = Color.White;
                lblmin.BorderStyle = BorderStyle.FixedSingle;
                p.Controls.Add(lblmin);
            }
            //adding max level
            if(maxlevel != null)
            { 
                Label lblmax = new Label();
                lblmax.Font = fontChannelminmax;
                lblmax.AutoSize = true;
                lblmax.Text = "Max = " + maxlevel;
                lblmax.Name = "lblmax" + p.Name;

                SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                double maxpos = 0;
                if(minlevel==null)
                {
                    maxpos = p.Height * .65;
                }
                else
                {
                    maxpos = p.Height * .80;
                }
                Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32(maxpos));

                lblmax.Location = pointmaxlevel;

                lblmax.ForeColor = Color.White;
                lblmax.BorderStyle = BorderStyle.FixedSingle;
                p.Controls.Add(lblmax);

            }
            // adding alarm led
            if(alarmsetting == true)
            {
                Label lblalarmled = new Label();
                lblalarmled.Name = "lblalarm" + p.Name;
                int lblalarmHW = Convert.ToInt32(p.Height * 0.1);
                lblalarmled.Height = lblalarmHW;
                lblalarmled.Width = lblalarmHW;
                lblalarmled.BackColor = Color.Red;

                int lblalarmledxpos = Convert.ToInt32(p.Width * 0.85);
                int lblalarmledypos = Convert.ToInt32(p.Height * 0.85);
                Point lblalarmledpt = new Point(lblalarmledxpos, lblalarmledypos);
                lblalarmled.Location = lblalarmledpt;

                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, lblalarmled.Width, lblalarmled.Height);

                lblalarmled.Region = new Region(path);

                p.Controls.Add(lblalarmled);

                Label lblalarmmode = new Label();
                lblalarmmode.Name = "lblalarmmode" + p.Name;
                lblalarmmode.Font = fontChannelminmax;
                lblalarmmode.AutoSize = true;
                lblalarmmode.Text = "Alarm Mode";
                lblalarmmode.ForeColor = Color.White;

                SizeF extentalarmlevel = g.MeasureString(lblalarmmode.Text, lblalarmmode.Font);

                lblalarmmode.Height = Convert.ToInt32(extentalarmlevel.Height);
                lblalarmmode.Width = Convert.ToInt32(extentalarmlevel.Width);

                int lblalarmmodexpos = Convert.ToInt32(p.Width * 0.09);
                int lblalarmmodeypos = Convert.ToInt32(p.Height * 0.85);

                Point lblalarmmodept = new Point(lblalarmmodexpos, lblalarmmodeypos);

                lblalarmmode.Location = lblalarmmodept;

                

                p.Controls.Add(lblalarmmode);
            }

            return p;
        }

        private void addUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUnits addunits = new AddUnits();
            addunits.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btnpoller = (Button)sender;
            if(btnpoller.Text == "Connect")
            {
                if (ShowChannels.SelectedItem == null)
                {
                    CurrentNoOfChannelSelected = 1;
                    if (OpenPort()) { 
                        ShowChannels.Enabled = false;
                        ConnectionStatus = true;
                        CallTimers(CurrentNoOfChannelSelected);
                        btnpoller.Text = "Disconnect";
                    }
                }
                else
                {
                    if (OpenPort())
                    {
                        ShowChannels.Enabled = false;
                        ConnectionStatus = true;
                        CallTimers(CurrentNoOfChannelSelected);
                        btnpoller.Text = "Disconnect";
                    }
                }

            }
            else if(btnpoller.Text=="Disconnect")
            {
                ConnectionStatus = false;
                StopTimers(CurrentNoOfChannelSelected);
                ClosePort();
                ShowChannels.Enabled = true;
                btnpoller.Text = "Connect";
            }
        }

        public class CustomColorTable : ProfessionalColorTable
        {
            public override Color ImageMarginGradientBegin
            {
                get
                {
                    return Color.RoyalBlue;
                }
            }

            public override Color ImageMarginGradientMiddle
            {
                get
                {
                    return Color.RoyalBlue;
                }
            }

            public override Color ImageMarginGradientEnd
            {
                get
                {
                    return Color.RoyalBlue;
                }
            }

            public override Color ToolStripDropDownBackground
            {
                get
                {
                    return Color.RoyalBlue;
                }
            }
        }

        private void pollSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pollsetting pollsetting = new Pollsetting();
            pollsetting.ShowDialog();
        }

        private void CallTimers(int nofotimers)
        {
            if (nofotimers == 1)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(2000));

            }
            else if (nofotimers == 2)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));


            }
            else if (nofotimers == 3)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));


            }
            else if (nofotimers == 4)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));


            }
            else if (nofotimers == 5)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 6)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 7)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));


            }
            else if (nofotimers == 8)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 9)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 10)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));


            }
            else if (nofotimers == 11)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));



            }
            else if (nofotimers == 12)
            {

                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));
            }
            else if (nofotimers == 13)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 14)
            {

                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 15)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));


            }
            else if (nofotimers == 16)
            {

                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 17)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 18)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 19)
            {

                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 20)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 21)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 22)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));
            }

            else if (nofotimers == 23)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 24)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel24 = new System.Threading.Timer(ChannelTimer24, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel24.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));
            }
            else if (nofotimers == 25)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel24 = new System.Threading.Timer(ChannelTimer24, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel24.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel25 = new System.Threading.Timer(ChannelTimer25, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel25.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }

            else if (nofotimers == 26)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel24 = new System.Threading.Timer(ChannelTimer24, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel24.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel25 = new System.Threading.Timer(ChannelTimer25, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel25.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel26 = new System.Threading.Timer(ChannelTimer26, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel26.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));
            }
            else if (nofotimers == 27)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel24 = new System.Threading.Timer(ChannelTimer24, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel24.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel25 = new System.Threading.Timer(ChannelTimer25, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel25.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel26 = new System.Threading.Timer(ChannelTimer26, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel26.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel27 = new System.Threading.Timer(ChannelTimer27, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel27.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 28)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel24 = new System.Threading.Timer(ChannelTimer24, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel24.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel25 = new System.Threading.Timer(ChannelTimer25, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel25.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel26 = new System.Threading.Timer(ChannelTimer26, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel26.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel27 = new System.Threading.Timer(ChannelTimer27, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel27.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel28 = new System.Threading.Timer(ChannelTimer28, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel28.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));


            }
            else if (nofotimers == 29)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel24 = new System.Threading.Timer(ChannelTimer24, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel24.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel25 = new System.Threading.Timer(ChannelTimer25, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel25.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel26 = new System.Threading.Timer(ChannelTimer26, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel26.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel27 = new System.Threading.Timer(ChannelTimer27, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel27.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel28 = new System.Threading.Timer(ChannelTimer28, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel28.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel29 = new System.Threading.Timer(ChannelTimer29, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel29.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

            }
            else if (nofotimers == 30)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel24 = new System.Threading.Timer(ChannelTimer24, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel24.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel25 = new System.Threading.Timer(ChannelTimer25, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel25.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel26 = new System.Threading.Timer(ChannelTimer26, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel26.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel27 = new System.Threading.Timer(ChannelTimer27, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel27.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel28 = new System.Threading.Timer(ChannelTimer28, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel28.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel29 = new System.Threading.Timer(ChannelTimer29, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel29.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel30 = new System.Threading.Timer(ChannelTimer30, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel30.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));
            }
            else if (nofotimers == 31)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel24 = new System.Threading.Timer(ChannelTimer24, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel24.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel25 = new System.Threading.Timer(ChannelTimer25, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel25.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel26 = new System.Threading.Timer(ChannelTimer26, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel26.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel27 = new System.Threading.Timer(ChannelTimer27, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel27.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel28 = new System.Threading.Timer(ChannelTimer28, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel28.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel29 = new System.Threading.Timer(ChannelTimer29, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel29.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel30 = new System.Threading.Timer(ChannelTimer30, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel30.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel31 = new System.Threading.Timer(ChannelTimer31, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel31.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));


            }
            else if (nofotimers == 32)
            {
                tmrChannel1 = new System.Threading.Timer(ChannelTimer1, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel2 = new System.Threading.Timer(ChannelTimer2, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel3 = new System.Threading.Timer(ChannelTimer3, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel3.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel4 = new System.Threading.Timer(ChannelTimer4, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel4.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel5 = new System.Threading.Timer(ChannelTimer5, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel5.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel6 = new System.Threading.Timer(ChannelTimer6, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel6.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel7 = new System.Threading.Timer(ChannelTimer7, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel7.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel8 = new System.Threading.Timer(ChannelTimer8, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel8.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel9 = new System.Threading.Timer(ChannelTimer9, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel9.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel10 = new System.Threading.Timer(ChannelTimer10, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel10.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel11 = new System.Threading.Timer(ChannelTimer11, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel11.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel12 = new System.Threading.Timer(ChannelTimer12, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel12.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel13 = new System.Threading.Timer(ChannelTimer13, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel13.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel14 = new System.Threading.Timer(ChannelTimer14, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel14.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel15 = new System.Threading.Timer(ChannelTimer15, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel15.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel16 = new System.Threading.Timer(ChannelTimer16, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel16.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel17 = new System.Threading.Timer(ChannelTimer17, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel17.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel18 = new System.Threading.Timer(ChannelTimer18, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel18.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel19 = new System.Threading.Timer(ChannelTimer19, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel19.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel20 = new System.Threading.Timer(ChannelTimer20, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel20.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel21 = new System.Threading.Timer(ChannelTimer21, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel21.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel22 = new System.Threading.Timer(ChannelTimer22, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel22.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel23 = new System.Threading.Timer(ChannelTimer23, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel23.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel24 = new System.Threading.Timer(ChannelTimer24, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel24.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel25 = new System.Threading.Timer(ChannelTimer25, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel25.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel26 = new System.Threading.Timer(ChannelTimer26, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel26.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel27 = new System.Threading.Timer(ChannelTimer27, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel27.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel28 = new System.Threading.Timer(ChannelTimer28, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel28.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel29 = new System.Threading.Timer(ChannelTimer29, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel29.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel30 = new System.Threading.Timer(ChannelTimer30, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel30.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel31 = new System.Threading.Timer(ChannelTimer31, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel31.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));

                tmrChannel32 = new System.Threading.Timer(ChannelTimer32, "", Timeout.Infinite, Timeout.Infinite);
                tmrChannel32.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));
            }
        }

        private void StopTimers(int nofotimers)
        {
            if (nofotimers == 1)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);
                firstcalltochannel1 = true;

            }
            else if (nofotimers == 2)
            {
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);
                
            }
            else if (nofotimers == 3)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);


            }
            else if (nofotimers == 4)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);


            }
            else if (nofotimers == 5)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 6)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 7)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);


            }
            else if (nofotimers == 8)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 9)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite); ;

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 10)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);


            }
            else if (nofotimers == 11)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite); ;

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);



                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);



            }
            else if (nofotimers == 12)
            {

                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);
            }
            else if (nofotimers == 13)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 14)
            {

                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 15)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);


            }
            else if (nofotimers == 16)
            {

                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 17)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 18)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 19)
            {

                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 20)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 21)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 22)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);
            }

            else if (nofotimers == 23)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 24)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel24.Change(Timeout.Infinite, Timeout.Infinite);
            }
            else if (nofotimers == 25)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel24.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel25.Change(Timeout.Infinite, Timeout.Infinite);

            }

            else if (nofotimers == 26)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel24.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel25.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel26.Change(Timeout.Infinite, Timeout.Infinite);
            }
            else if (nofotimers == 27)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel24.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel25.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel26.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel27.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 28)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel24.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel25.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel26.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel27.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel28.Change(Timeout.Infinite, Timeout.Infinite);


            }
            else if (nofotimers == 29)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel24.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel25.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel26.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel27.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel28.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel29.Change(Timeout.Infinite, Timeout.Infinite);

            }
            else if (nofotimers == 30)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel24.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel25.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel26.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel27.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel28.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel29.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel30.Change(Timeout.Infinite, Timeout.Infinite);
            }
            else if (nofotimers == 31)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel24.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel25.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel26.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel27.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel28.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel29.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel30.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel31.Change(Timeout.Infinite, Timeout.Infinite);


            }
            else if (nofotimers == 32)
            {
                
                tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel2.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel3.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel4.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel5.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel6.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel7.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel8.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel9.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel10.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel11.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel12.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel13.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel14.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel15.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel16.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel17.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel18.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel19.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel20.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel21.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel22.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel23.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel24.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel25.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel26.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel27.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel28.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel29.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel30.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel31.Change(Timeout.Infinite, Timeout.Infinite);

                
                tmrChannel32.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        private void DeviceDataDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Connection1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool OpenPort()
        { 
            if (mb.Open("COM9", 9600, 8, Parity.None, StopBits.One))
            {
                lblStatus.Text = "Status: " + mb.modbusStatus;
                return true;
            }
            
            lblStatus.Text ="Status: "+mb.modbusStatus;
            return false;
        }
        private void ClosePort()
        {
            mb.Close();
            lblStatus.Text =  "Polling stopped";
        }

        private void deviceSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceDisplay devicedisplay = new DeviceDisplay();
            devicedisplay.ShowDialog();
        }
    }
}
