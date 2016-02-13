using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;

namespace DeviceDataDisplay.Modbus
{
    public class ModbusReader
    {
        modbus mb = new modbus();
        List<ushort> devicevalues1 = new List<ushort>();
        Dictionary<ushort, int> deviceresolution1 = new Dictionary<ushort, int>();
        Dictionary<ushort, string> deviceunits1 = new Dictionary<ushort, string>();
        Dictionary<ushort, string> devicealarm1 = new Dictionary<ushort, string>();
        
        public ModbusReader(int channelid,SerialPort serialport)
        {
            mb.sp = serialport;
            Channelid = channelid;
            
        }
        public string AlarmMode { get; set; }

        public string value_resolution_units { get; set; }

        public string ModbusError { get; set; } = null;

        public string DBError { get; set; } = null;

        public bool AlarmOn { get; set; }

        public int Channelid { get; set; }

        public bool AlarmStatus { get; set; } 

        public string Units { get; set; }

        public int Resolution { get; set; }

        public bool DeviceNotFound { get; set; }

        public bool IsIntialzeDB { get; set; } = false;
        
        public bool IntializeDB()
        {
            try
            {
                MySqlConnection Connection1 = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
                Connection1.Open();
                string querydev = "select deviceRefID from channels where channel_no = " + Channelid;
                MySqlCommand getdevice = new MySqlCommand(querydev, Connection1);

                // get the device id for channel 1
                int deviceID = (int)getdevice.ExecuteScalar();

                if(deviceID == 0)
                {
                    DBError = "No device";
                    DeviceNotFound = true;
                    IsIntialzeDB = true;
                    return false;
                }

                //get the device setting for channel1
                string query = "Select deviceID,device_name,slaveID,value_start_address,value_return_datatype,unit_start_address,unit_return_datatype,alarm_start_address,alarm_return_datatype,resolution_start_address,resolution_return_datatype,Endianess,alarm_status_start_address,alarm_status_return_datatype from devices where deviceID =" + deviceID;
                getdevice.CommandText = query;
                getdevice.Connection = Connection1;
                MySqlDataReader devicereader = getdevice.ExecuteReader();
                string device_name = "";

                //add device data to list devicevalues1

                if (devicereader.HasRows)
                {
                    while (devicereader.Read())
                    {
                        devicevalues1.Add(devicereader.GetUInt16(0));//deviceID 0
                        device_name = devicereader.GetString(1); //device_name
                        devicevalues1.Add(devicereader.GetUInt16(2));//slaveID 1
                        devicevalues1.Add(devicereader.GetUInt16(3));//value_start_address 2
                        devicevalues1.Add(devicereader.GetUInt16(4));//value_return_datatype 3

                        /* 4 unit_start_address*/
                        devicevalues1.Add((!(devicereader.IsDBNull(5)) ? devicereader.GetUInt16(5) : Convert.ToUInt16(60000)));
                        /* 5unit_return_datatype */
                        devicevalues1.Add((!(devicereader.IsDBNull(6)) ? devicereader.GetUInt16(6) : Convert.ToUInt16(60000)));
                        /* 6alarm_start_datatype */
                        devicevalues1.Add((!(devicereader.IsDBNull(7)) ? devicereader.GetUInt16(7) : Convert.ToUInt16(60000)));
                        /* 7alarm_return_datatype */
                        devicevalues1.Add((!(devicereader.IsDBNull(8)) ? devicereader.GetUInt16(8) : Convert.ToUInt16(60000)));
                        /* 8resolution_start_address */
                        devicevalues1.Add((!(devicereader.IsDBNull(9)) ? devicereader.GetUInt16(9) : Convert.ToUInt16(60000)));
                        /* 9resolution_return_datatype */
                        devicevalues1.Add((!(devicereader.IsDBNull(10)) ? devicereader.GetUInt16(10) : Convert.ToUInt16(60000)));
                        /* 10Endianess */
                        devicevalues1.Add((!(devicereader.IsDBNull(11)) ? devicereader.GetUInt16(11) : Convert.ToUInt16(60000)));
                        /* 11 alarm_status_start_address */
                        devicevalues1.Add((!(devicereader.IsDBNull(12)) ? devicereader.GetUInt16(12) : Convert.ToUInt16(60000)));
                        /* 12 alarm_status_return_datatype */
                        devicevalues1.Add((!(devicereader.IsDBNull(13)) ? devicereader.GetUInt16(13) : Convert.ToUInt16(60000)));
                    }
                }

                devicereader.Close();

                //adding units value to dictionary from db one time, if the value is set as null
                //by the user an out of range value of 6000 is set to check for nullable values
                // a nullable ushort cannot be defined as modbus expect non-nullable datatype
                
                //Revised on 11-feb-2016, the system doesn't query for units
                //resolution and alarmmode, but reads them from the meter for
                //the frist time and stores them as properties to be applied
                //to values and alarm status which are polled by timer every 
                //specified milliseconds-Hence the previous contionous polling
                //has been commented
                if (devicevalues1[4] != 60000)
                {
                    //get unit value for the device from db after querying the device
                    ushort[] unit_index = new ushort[devicevalues1[5]];

                    //address 1 denotess slaveid,address4=units start address,address5=unints return datatypes
                    mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[4], devicevalues1[5], ref unit_index);
                    Thread.Sleep(50);
                    
                    var queryunits = "Select units_value from device_units where deviceID=" + deviceID + " and units_index = " + unit_index[0];
                    getdevice.CommandText = queryunits;
                    getdevice.Connection = Connection1;
                    object units = getdevice.ExecuteScalar();
                    Units = (units != DBNull.Value) ? units.ToString() : "";
                    
                    /*
                    Revision for once read above
                    MySqlDataReader unitReader = getdevice.ExecuteReader();

                    if (unitReader.HasRows)
                    {
                        while (unitReader.Read())
                        {
                            deviceunits1.Add(unitReader.GetUInt16(0), unitReader.GetString(1));
                        }
                    }
                    unitReader.Close();
                    */
                }
                //get alarm defination from db and load it in to dictionary
                if (devicevalues1[6] != 60000)
                {
                    ushort[] alarm_index = new ushort[devicevalues1[7]];
                    mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[6], devicevalues1[7], ref alarm_index);
                    Thread.Sleep(50);
                    var queryalarm = "Select alarm_value from device_alarm where deviceID=" + deviceID + " and alarm_index=" + alarm_index[0];
                    getdevice.CommandText = queryalarm;
                    getdevice.Connection = Connection1;


                    object alarmmode= getdevice.ExecuteScalar();
                    AlarmMode = (alarmmode != DBNull.Value) ? alarmmode.ToString() : "";
                    AlarmOn = true;
                    /*
                    MySqlDataReader alarmReader = getdevice.ExecuteReader();

                    if (alarmReader.HasRows)
                    {
                        while (alarmReader.Read())
                        {
                            devicealarm1.Add(alarmReader.GetUInt16(0), alarmReader.GetString(1));
                            AlarmOn = true;

                        }
                    }
                    alarmReader.Close();
                    */
                }

                // same as units if resolution is defined than add those values to dictionary
                if (devicevalues1[8] != 60000)
                {
                    ushort[] resolution_index = new ushort[devicevalues1[9]];
                    mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[8], devicevalues1[9], ref resolution_index);
                    Thread.Sleep(50);
                    var queryres = "Select resolution_value from device_resolution where deviceID=" + deviceID + " and resolution_index = "+ resolution_index[0];
                    getdevice.CommandText = queryres;
                    getdevice.Connection = Connection1;

                    object resolution = getdevice.ExecuteScalar();
                    Resolution = (resolution != DBNull.Value) ? (int) resolution : 0;
                    

                        /*
                        The Code was revised for read once above
                        MySqlDataReader resolutionReader = getdevice.ExecuteReader();

                        if (resolutionReader.HasRows)
                        {
                            while (resolutionReader.Read())
                            {
                                deviceresolution1.Add(resolutionReader.GetUInt16(0), resolutionReader.GetInt32(1));

                            }
                        }
                        resolutionReader.Close();
                        */
                }
                IsIntialzeDB = true;
                return true;

            }
            catch (Exception err)
            {
                DBError = "DB Error";
                throw;
            }
        }
     public void ReadDevice()
     {
            try
            {
                //checking and setting alarammode

                /*
                if (devicevalues1[6] != 60000)
                {
                    ushort[] alarm_value = new ushort[devicevalues1[7]];
                    mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[6], devicevalues1[7], ref alarm_value);
                    //loop thru the reoslution dictionary
                    foreach (var alarm in devicealarm1)
                    {
                        // if the key matchess the meter returned value
                        if (alarm.Key == alarm_value[0])
                        {
                            AlarmMode = alarm.Value.ToString();// get the value for the matched key

                        }
                    }
                    
                    Thread.Sleep(50);
                }
                */
                //reteriving units values
                //poll modbus if units are confgured by the user
                //string unit_value_db = "";
                //array postion 4 denotes unit value address
               /* if (devicevalues1[4] != 60000)
                {
                    //address 5 denotes the return address type of units, 16bit(integer in C, short in C#)or long.
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
*/
                //read alarm status
                
                
                
                //for value reteriving
                int intValue = 0;
                //value devicevalue1[3]  denotes meter value return datatype, 
                // if its ulong or int32 , modbus returns two 16 bit values
                //which needs to be bit shifted to create a 32 bit value
                //devicevalue1[2]= meter value start address
                if (devicevalues1[3] == 2)
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
                    else if (devicevalues1[10] == 1)
                    {
                        for (int i = 0; i < devicevalues1[3] / 2; i++)
                        {
                            intValue = values[2 * i + 1];
                            intValue <<= 16;
                            intValue += values[2 * i];//for big endian 
                        }

                    }
                    Thread.Sleep(50);
                }
                else if (devicevalues1[3] == 1)// if meter value return datatype is ushort or integer(C) no need shift it is only 16bit value
                {
                    ushort[] values = new ushort[devicevalues1[3]];
                    mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[2], devicevalues1[3], ref values);
                    intValue = (int)values[0];
                    Thread.Sleep(50);

                }
                //get resolution


                double dval = (double)intValue;

                string resolution_applied = "";
                // same like units only address begin and end value changes/see while loop(up) to know address
                if (devicevalues1[8] != 60000)
                {
                    //ushort[] resolution_value = new ushort[devicevalues1[9]];
                    //mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[8], devicevalues1[9], ref resolution_value);
                    ////loop thru the reoslution dictionary
                    //foreach (var resolution in deviceresolution1)
                    //{
                    //    // if the key matchess the meter returned value
                    //    if (resolution.Key == resolution_value[0])
                    //    {
                    //        // get the value for the matched key
                    //                                                    //to format for decimal places we have to give value like ex "0.00" for two decimals to ToSring("0.00")
                    //the db value for decimal places returns 1000,100,10 or 1, except for 1 all values
                    string resval = Resolution.ToString();                                            //will be formated for decimal places
                    if (Resolution != 1)
                    {
                        string decimalplaces = "0." + resval.Substring(1, (resval.Length - 1));
                        resolution_applied = (dval / Resolution).ToString(decimalplaces) + " " + Units;
                    }
                    else if (Resolution == 1)
                    {
                        resolution_applied = dval.ToString() + " " + Units;
                    }
                    //        }
                    //    }
                    //    Thread.Sleep(50);
                    //}
                }

                if (devicevalues1[11] != 60000)
                {
                    ushort[] alarm_status = new ushort[devicevalues1[12]];

                    //address 1 denotess slaveid,address4=units start address,address5=unints return datatypes
                    mb.SendFc3(Convert.ToByte(devicevalues1[1]), devicevalues1[11], devicevalues1[12], ref alarm_status);
                    Thread.Sleep(50);
                    AlarmStatus = (alarm_status[0] == 0) ? false : true;

                }
                if (resolution_applied == "")
                {
                    string unints = (Units != "") ? " " + Units : "";
                    value_resolution_units = intValue.ToString() + unints;
                    
                }
                else
                {
                    value_resolution_units = resolution_applied;
                }
                
            }
            catch (Exception err)
            {

                ModbusError = "MB Error" + err.Message;
                throw;
            }
            
        }
    }
}
