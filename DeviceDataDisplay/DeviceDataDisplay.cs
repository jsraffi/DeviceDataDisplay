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
using System.Diagnostics;
using System.Threading;
using DeviceDataDisplay.Modbus;
using System.IO.Ports;

namespace DeviceDataDisplay
{
    public partial class DeviceDataDisplay : Form
    {
        modbus mb = new modbus();

        SerialPort sp = new SerialPort();
        string modbusStatus;

        System.Threading.Timer tmrChannel1;
        

        bool ConnectionStatus = false;

        //loading database values in list for the device
        List<ushort> devicevalues1 = new List<ushort>();
        Dictionary<ushort, int> deviceresolution1 = new Dictionary<ushort, int>();
        Dictionary<ushort, string> deviceunits1 = new Dictionary<ushort, string>();
        Dictionary<ushort, string> devicealarm1 = new Dictionary<ushort, string>();

        private Dictionary<string, string> colorsetting = new Dictionary<string, string>();

        string lastdisplayedvalue;
        string lastdisplayedvalue1;
        string lastdisplayedvalue2;

        bool firstcalltochannel1 = true;
        bool firstcalltochannel2 = true;

        bool firstcalltopolling = true;
        

        ModbusReader channel1reader;
        ModbusReader channel2reader;

        List<ModbusReader> ChannelReader = new List<ModbusReader>();
        int CurrentNoOfChannelSelected = 0;
        string PortSetting;
        int baudrate;
        int firstdisplayloadtimeMS;
        int timeintervalbetweencommandMS;
        private int logintervalinminutes;

        private DateTime ApplicationStartTimeForLog;
        private string LogChannelValues;
        private string LogChannelNames;

        private bool loaded = false;
        


        public DeviceDataDisplay()
        {
            InitializeComponent();
        }

        private void DeviceDataDisplay_Load(object sender, EventArgs e)
        {
            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());

            string[] channels = new string[] { "1", "2", "3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31","32"};
            
            ShowChannels.Items.AddRange(channels);

            getColorSetting();

            getPollSetting();

            //ChannelSetting();

            ChannelStartUp();

            ApplicationStartTimeForLog =DateTime.Now;

           AfterLoading();
        }

        private async void AfterLoading()
        {   
             await Task.Delay(20000);
            ShowChannels.SelectedIndex = 9;
            poller.PerformClick();

        }
        private void getColorSetting()
        {
            try
            {
                using (
                MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"])
                )
                {
                    Connection.Open();
                    string query = "Select * from coloursetting";

                    MySqlCommand command = new MySqlCommand(query, Connection);

                    MySqlDataReader reader = command.ExecuteReader();
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            colorsetting.Add("panelcolour",reader.GetString(1));
                            colorsetting.Add("panelbordercolour", reader.GetString(2));
                            colorsetting.Add("valuecolour", reader.GetString(3));
                            colorsetting.Add("channelnamecolour", reader.GetString(4));
                            colorsetting.Add("setpointcolour", reader.GetString(5));
                        }
                    }

                    


                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            

            
        }
        public void getPollSetting()
        {

            using (MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
            {
                Connection.Open();
                string query = "Select * from poll_setting";
                MySqlDataAdapter channeladapter = new MySqlDataAdapter(query, Connection);
                DataSet channelsdata = new DataSet();
                channeladapter.Fill(channelsdata, "poll_setting");

                DataTable tblpoll_setting = channelsdata.Tables["poll_setting"];

                PortSetting = tblpoll_setting.Rows[0].Field<string>("com_port");
                baudrate = tblpoll_setting.Rows[0].Field<int>("baud_rate");
                firstdisplayloadtimeMS = tblpoll_setting.Rows[0].Field<int>("poll_interval");
                timeintervalbetweencommandMS = tblpoll_setting.Rows[0].Field<int>("command_interval");
                logintervalinminutes = tblpoll_setting.Rows[0].Field<int>("log_interval");

            }
        }

        private void pollingCallBack(object state)
        {   
            
            if(firstcalltopolling)
            {
                for(var i=0;i<CurrentNoOfChannelSelected;i++)
                {
                    ChannelReader.Add(new ModbusReader(i + 1, sp,timeintervalbetweencommandMS));
                }
                firstcalltopolling = false;
            }
            LogChannelValues = "";
            LogChannelNames = "";
            for(var i=0;i<CurrentNoOfChannelSelected;i++)
            {
                UpdateChannel(ChannelReader[i], "Channel" + (i + 1));
            }

            if (ConnectionStatus == false)
            {
                firstcalltopolling = true;
                ChannelReader.Clear();
                ClosePort();
                this.Invoke((MethodInvoker)delegate
                {
                    ShowChannels.Enabled = true;
                    mainMenuToolStripMenuItem.Enabled = true;
                    poller.Text = "Connect";
                });
                //tmrChannel1.Change(Timeout.Infinite, Timeout.Infinite);
                tmrChannel1.Dispose();
            }
            else
            {
                TimeSpan oneminute = DateTime.Now.Subtract(ApplicationStartTimeForLog);
                
                Debug.WriteLine(oneminute.Seconds);
                if (oneminute.Minutes >= logintervalinminutes)
                {
                    string InsertSQL = "Insert into devicelog(LogDateTime," + LogChannelNames.TrimEnd(',') + ") Values('" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") +"',"+
                                       LogChannelValues.TrimEnd(',') + ")";
                    //Debug.WriteLine(InsertSQL);
                    try
                    {
                        using (MySqlConnection Connection =
                            new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
                        {
                            Connection.Open();
                            MySqlCommand loginsert = new MySqlCommand();
                            loginsert.CommandType = CommandType.Text;
                            loginsert.CommandText = InsertSQL;
                            loginsert.Connection = Connection;
                            loginsert.ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        
                        
                    }
             
                    ApplicationStartTimeForLog = DateTime.Now;
                }

                tmrChannel1.Change(TimeSpan.Zero,TimeSpan.FromMilliseconds(firstdisplayloadtimeMS));
            }

      }
        private void UpdateChannel(ModbusReader channelreader,string channelid)
        {
            string valuelabel = "lblvalue" + channelid;
            string alarmmodelabel = "lblalarmmode" + channelid;
            string alarmledlabel = "lblalarmled" + channelid;
            string channelnamelabel = "lblchname" + channelid;
            string minlevellabel = "lblmin" + channelid;
            string maxlevellabel = "lblmax" + channelid;
          
            try
            {   if (!(channelreader.IsIntialzeDB))
                {
                    if (!(channelreader.IntializeDB()))
                    {
                        throw new ApplicationException();
                    }
                    this.Invoke((MethodInvoker) delegate
                    {
                        var p = Controls.Find(channelid, false);
                        if (channelreader.ChannelName != "")
                        {
                            p[0].Controls.OfType<Label>().Single(l => l.Name == channelnamelabel).Text = channelreader.ChannelName;
                        }
                        if (channelreader.AlarmMode != "")
                        {
                            p[0].Controls.OfType<Label>().Single(l => l.Name == alarmmodelabel).Text = channelreader.AlarmMode;
                        }
                        if (channelreader.AlarmOn)
                        {
                            p[0].Controls.OfType<Label>().Single(l => l.Name == alarmledlabel).BackColor = (channelreader.AlarmStatus == false) ? Color.Red : Color.Green;
                        }
                        if (channelreader.MinLevelValue != 0)
                        {
                            p[0].Controls.OfType<Label>().Single(l => l.Name == minlevellabel).Text = "Min= " + channelreader.MinLevelValue.ToString();
                        }
                        if (channelreader.MaxLevelValue != 0)
                        {
                            p[0].Controls.OfType<Label>().Single(l => l.Name == maxlevellabel).Text = "Max= "+ channelreader.MaxLevelValue.ToString();
                        }
                    });
                    
                }
                else if(channelreader.DeviceNotFound)
                {
                    return;
                }
                
                channelreader.ReadDevice();
                lastdisplayedvalue1 = channelreader.value_resolution_units;
                LogChannelValues +=  "'" + channelreader.value_resolution_units +"',";
                LogChannelNames += channelid + "Value" + ",";
                this.Invoke((MethodInvoker)delegate
                {
                    var p = Controls.Find(channelid, false);
                    
                    p[0].Controls.OfType<Label>().Single(l => l.Name == valuelabel).Text = channelreader.value_resolution_units;
                    
                    
                });

            }
            catch (Exception err)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (channelreader.ModbusError != null)
                    {
                        var p = Controls.Find(channelid, false);
                        p[0].Controls.OfType<Label>().Single(l => l.Name == valuelabel).Text = "MB error";
                        //lblStatus.Text = channelreader.ModbusError;
                    }
                    else if (channelreader.DBError != null)
                    {
                        var p = Controls.Find(channelid, false);
                        p[0].Controls.OfType<Label>().Single(l => l.Name == valuelabel).Text = channelreader.DBError;
                        //lblStatus.Text = err.Message;
                    }
                    else
                    {
                        var p = Controls.Find(channelid, false);
                        p[0].Controls.OfType<Label>().Single(l => l.Name == valuelabel).Text = "Undefined error";
                        //lblStatus.Text = err.Message;
                    }

                });

            }

        }

        


        private void PaintPanelBorder(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle, ColorTranslator.FromHtml(colorsetting["panelbordercolour"]), ButtonBorderStyle.Solid);

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
            string query = "Select channel_no,display_name,channel_name,um.units as unitsmesure,value,minlevel,maxlevel,onlyminlevel,onlymaxlevel,alarmswitch,alarmstatus from channels ch inner join unitsofmesurement um on ch.units=um.unitID";
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
                    p.BackColor = ColorTranslator.FromHtml(colorsetting["panelcolour"]);
                    p.Paint += PaintPanelBorder;
                    
                    p.Location = new Point((panelwidth * j), (panelheight * i));
                    

                    if (noOfChannels == 1)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        
                        List<int> fontsetting = getFontSetting("ch1fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);
                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1restfontsize"]), FontStyle.Bold);

                        var value = drow["value"].ToString();

                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]), Convert.ToBoolean(drow["alarmstatus"]));
                       
                    }
                    if (noOfChannels ==2)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);

                        List<int> fontsetting = getFontSetting("ch2fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);

                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2restfontsize"]), FontStyle.Bold);
                        double onlyvalue = Convert.ToDouble(drow["value"]);
                        var value = onlyvalue.ToString();

                        
                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]), Convert.ToBoolean(drow["alarmstatus"]));

                    }
                    if (noOfChannels >=3 && noOfChannels <=4)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        List<int> fontsetting = getFontSetting("ch3-4fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);

                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch34valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch34restfontsize"]), FontStyle.Bold);
                        double onlyvalue = Convert.ToDouble(drow["value"]);
                        var value = onlyvalue.ToString();
                        
                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]), Convert.ToBoolean(drow["alarmstatus"]));
                    }
                    if (noOfChannels >= 5 && noOfChannels <= 8)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);

                        List<int> fontsetting = getFontSetting("ch5-8fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);


                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch58valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch58restfontsize"]), FontStyle.Bold);
                        double onlyvalue = Convert.ToDouble(drow["value"]);
                        var value = onlyvalue.ToString();
                        
                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]),Convert.ToBoolean(drow["alarmstatus"]));
                    }

                    if (noOfChannels >= 9 && noOfChannels <= 12)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        List<int> fontsetting = getFontSetting("ch9-12fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);


                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch912valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch912restfontsize"]), FontStyle.Bold);
                        double onlyvalue = Convert.ToDouble(drow["value"]);
                        var value = onlyvalue.ToString();

                        

                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]), Convert.ToBoolean(drow["alarmstatus"]));

                    }
                    if (noOfChannels >= 13 && noOfChannels <= 16)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);

                        List<int> fontsetting = getFontSetting("ch13-16fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);


                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1316valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1316restfontsize"]), FontStyle.Bold);
                        double onlyvalue = Convert.ToDouble(drow["value"]);
                        var value = onlyvalue.ToString();

                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]), Convert.ToBoolean(drow["alarmstatus"]));
                    }

                    if (noOfChannels >= 17 && noOfChannels <= 20)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        List<int> fontsetting = getFontSetting("ch17-20fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);



                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1720valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch1720restfontsize"]), FontStyle.Bold);
                        //Font fontChannel = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["chname1720fontsize"]), FontStyle.Bold);
                        double onlyvalue = Convert.ToDouble(drow["value"]);
                        var value = onlyvalue.ToString();

                        

                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]), Convert.ToBoolean(drow["alarmstatus"]));
                    }
                    if (noOfChannels >= 21 && noOfChannels <= 24)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        List<int> fontsetting = getFontSetting("ch21-24fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);



                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2124valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2124restfontsize"]), FontStyle.Bold);
                        //Font fontChannel = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["chnameafter20fontsize"]), FontStyle.Bold);
                        double onlyvalue = Convert.ToDouble(drow["value"]);
                        var value = onlyvalue.ToString();

                        
                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]), Convert.ToBoolean(drow["alarmstatus"]));

                    }
                    if (noOfChannels >= 25 && noOfChannels <= 28)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);

                        List<int> fontsetting = getFontSetting("ch25-28fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);

                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2528valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2528restfontsize"]), FontStyle.Bold);
                        //Font fontChannel = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["chnameafter20fontsize"]), FontStyle.Bold);
                        //double onlyvalue = Convert.ToDouble(drow["value"]);
                        var value = drow["value"].ToString();

                        

                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]), Convert.ToBoolean(drow["alarmstatus"]));

                    }
                    if (noOfChannels >= 29 && noOfChannels <= 32)
                    {

                        DataRow drow = getchannel(tblChannel, channelid);

                        List<int> fontsetting = getFontSetting("ch29-32fontsetting");
                        Font fontvalue = new Font("Arial Unicode MS", fontsetting[0], FontStyle.Bold);
                        Font fontChannelminmax = new Font("Arial Unicode MS", fontsetting[1], FontStyle.Bold);
                        Font fontChannelName = new Font("Arial Unicode MS", fontsetting[2], FontStyle.Bold);


                        //Font fontvalue = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2932valuefontsize"]), FontStyle.Bold);
                        //Font fontChannelminmax = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["ch2932restfontsize"]), FontStyle.Bold);
                        //Font fontChannel = new Font("Arial Unicode MS", float.Parse(ConfigurationSettings.AppSettings["chnameafter20fontsize"]), FontStyle.Bold);
                        double onlyvalue = Convert.ToDouble(drow["value"]);
                        var value = onlyvalue.ToString();

                        
                        p = screenbuilder(p, value, drow["channel_name"].ToString(), drow["minlevel"].ToString(), drow["maxlevel"].ToString(), fontvalue, fontChannelminmax, fontChannelName, Convert.ToBoolean(drow["alarmswitch"]), Convert.ToBoolean(drow["onlymaxlevel"]), Convert.ToBoolean(drow["onlyminlevel"]), Convert.ToBoolean(drow["alarmstatus"]));
                    }
                    Controls.Add(p);
                    
                }
            }

        }

        private List<int> getFontSetting(string channelrange)
        {
            try
            {
                List<int> fontsize = new List<int>();
                using (MySqlConnection connection =
                    new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
                {
                    string sql = "select * from displaysetting where channelrange = '" + channelrange + "'";
                    connection.Open();
                    MySqlCommand command =
                        new MySqlCommand(sql, connection);


                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        
                        while (reader.Read())
                        {
                            fontsize.Add(reader.GetInt32(2));
                            fontsize.Add(reader.GetInt32(3));
                            fontsize.Add(reader.GetInt32(4));
                        }
                    }

                }

                return fontsize;
            }
            catch (Exception ex)
            {
                 
                Debug.WriteLine(ex.Message);
                 
            }
            return null;
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

        private Panel screenbuilder(Panel p, string valuewithunits, string channelname, string minlevel, string maxlevel, Font valuefont, Font minmaxchannel, Font fontchannelname ,bool alarmsetting=false,bool metermax=false,bool metermin =false, bool alarmstatus=false)
        {

            Label lbl = new Label();
            //Adding value to panel and units
            Font fontChannel1 = valuefont;
            Font fontChannelminmax = minmaxchannel;
            lbl.Name = "lblvalue" + p.Name;
            
            lbl.Font = fontChannel1;
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = valuewithunits;
            Graphics g = CreateGraphics();
            SizeF extent = g.MeasureString(lbl.Text, lbl.Font);

            lbl.Height = Convert.ToInt32(extent.Height);
            lbl.Width = Convert.ToInt32(extent.Width);
            
            var x = (p.Width - lbl.Width )/2;
            Point pointvalue = new Point(x, ((p.Height / 2) - (lbl.Height / 2)));

            lbl.Location = pointvalue;

            lbl.ForeColor = ColorTranslator.FromHtml(colorsetting["valuecolour"]);
            lbl.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(lbl);

            //Adding channel to panel

            Label lblchannelname = new Label();
            /*
            if(channel21above == null)
            {
                lblchannelname.Font = fontChannelminmax;
            }
            else if(channel21above!=null)
            {*/
                lblchannelname.Font = fontchannelname;
            //}

            lblchannelname.AutoSize = false;
            lblchannelname.TextAlign = ContentAlignment.MiddleCenter;
            lblchannelname.Text = channelname;
            lblchannelname.Name = "lblchname" + p.Name;

            SizeF extentchannel = g.MeasureString(lblchannelname.Text, lblchannelname.Font);

            lblchannelname.Height = Convert.ToInt32(extentchannel.Height);
            lblchannelname.Width = Convert.ToInt32(extentchannel.Width + 20);

            var xchannelname = (p.Width / 2) - (lblchannelname.Width / 2);
            Point pointvaluechannelname = new Point(xchannelname, (p.Height / 8));

            lblchannelname.Location = pointvaluechannelname;

            lblchannelname.ForeColor = ColorTranslator.FromHtml(colorsetting["channelnamecolour"]);
            lblchannelname.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(lblchannelname);

            //adding min level

            if (minlevel != "0" || metermin)
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

                lblmin.ForeColor = ColorTranslator.FromHtml(colorsetting["setpointcolour"]);
                lblmin.BorderStyle = BorderStyle.FixedSingle;
                p.Controls.Add(lblmin);
            }
            //adding max level
            if(maxlevel != "0" || metermax )
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

                lblmax.ForeColor = ColorTranslator.FromHtml(colorsetting["setpointcolour"]);
                lblmax.BorderStyle = BorderStyle.FixedSingle;
                p.Controls.Add(lblmax);

            }
            // adding alarm led
            if (alarmstatus == true)
            {
                Label lblalarmled = new Label();
                lblalarmled.Name = "lblalarmled" + p.Name;
                int lblalarmHW = Convert.ToInt32(p.Height*0.1);
                lblalarmled.Height = lblalarmHW;
                lblalarmled.Width = lblalarmHW;
                lblalarmled.BackColor = Color.White;

                int lblalarmledxpos = Convert.ToInt32(p.Width*0.85);
                int lblalarmledypos = Convert.ToInt32(p.Height*0.88);
                Point lblalarmledpt = new Point(lblalarmledxpos, lblalarmledypos);
                lblalarmled.Location = lblalarmledpt;

                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, lblalarmled.Width, lblalarmled.Height);

                lblalarmled.Region = new Region(path);

                p.Controls.Add(lblalarmled);
            }

            if (alarmsetting == true)
            {
                Label lblalarmmode = new Label();
                lblalarmmode.Name = "lblalarmmode" + p.Name;
                lblalarmmode.Font = fontChannelminmax;
                lblalarmmode.AutoSize = true;
                lblalarmmode.Text = "Alarm Mode";
                lblalarmmode.ForeColor = ColorTranslator.FromHtml(colorsetting["setpointcolour"]);

                SizeF extentalarmlevel = g.MeasureString(lblalarmmode.Text, lblalarmmode.Font);

                lblalarmmode.Height = Convert.ToInt32(extentalarmlevel.Height);
                lblalarmmode.Width = Convert.ToInt32(extentalarmlevel.Width);

                int lblalarmmodexpos = Convert.ToInt32(p.Width*0.01);
                int lblalarmmodeypos = Convert.ToInt32(p.Height*0.88);

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
                if (ShowChannels.SelectedItem != null)
                {
                    if (OpenPort()) { 
                        ShowChannels.Enabled = false;
                        mainMenuToolStripMenuItem.Enabled = false;
                        ConnectionStatus = true;
                        //CallTimers(CurrentNoOfChannelSelected);
                        tmrChannel1 = new System.Threading.Timer(pollingCallBack, "", Timeout.Infinite, Timeout.Infinite);
                        tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(firstdisplayloadtimeMS));
                        btnpoller.Text = "Disconnect";
                    }
                }
                else
                {    
                        ShowChannels.Enabled = true;
                        mainMenuToolStripMenuItem.Enabled = true;
                        btnpoller.Text = "Connect";
                        lblStatus.Text = "Please select a channel";
                }

            }
            else if(btnpoller.Text=="Disconnect")
            {
                ConnectionStatus = false;
            }
        }

        private void ChannelStartUp()
        {
               using (MySqlConnection Connection =new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]))
                {
                    try
                    {
                        Connection.Open();
                        string query = "Select Count(*) from channels where deviceRefID !=0 ";

                        MySqlCommand command = new MySqlCommand(query,Connection);

                        object value = command.ExecuteScalar();
                        if(value != null)
                        {
                            ChannelSetting(Convert.ToInt32(value.ToString()));
                        
                        }
                        else
                        {
                            ChannelSetting();
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        
                        Debug.WriteLine(ex.Message);
                    }
                    

                }
            
            
        }

        private void AutoPolling()
        {
            try
            {
                if (OpenPort())
                {
                    ShowChannels.Enabled = false;
                    mainMenuToolStripMenuItem.Enabled = false;
                    ConnectionStatus = true;
                    //CallTimers(CurrentNoOfChannelSelected);
                    tmrChannel1 = new System.Threading.Timer(pollingCallBack, "", Timeout.Infinite, Timeout.Infinite);
                    tmrChannel1.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(firstdisplayloadtimeMS));
                    poller.Text = "Disconnect";
                }


            }
            catch (Exception ex)
            {
                
                Debug.WriteLine(ex.Message);
            }
        }
        public class
            CustomColorTable : ProfessionalColorTable
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

        

        

        private void DeviceDataDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Connection1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool OpenPort()
        {
            if (Open(PortSetting,baudrate, 8, Parity.None, StopBits.One))
            {
                lblStatus.Text = "Status: " + modbusStatus;
                return true;
            }

            lblStatus.Text = "Status: " + modbusStatus;
            return false;
        }
        private void ClosePort()
        {
            PortClose();
            this.Invoke((MethodInvoker)delegate
            {
                lblStatus.Text = "Polling stopped";
            });
        }
        public bool Open(string portName, int baudRate, int databits, Parity parity, StopBits stopBits)
        {
            //Ensure port isn't already opened:
            if (!sp.IsOpen)
            {
                //Assign desired settings to the serial port:
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.DataBits = databits;
                sp.Parity = parity;
                sp.StopBits = stopBits;
                //These timeouts are default and cannot be editted through the class at this point:
                sp.ReadTimeout = 1000;
                sp.WriteTimeout = 1000;

                try
                {
                    sp.Open();
                }
                catch (Exception err)
                {
                    modbusStatus = "Error opening " + portName + ": " + err.Message;
                    return false;
                }
                modbusStatus = "Connected thru " + portName + " Polling started";
                return true;
            }
            else
            {
                modbusStatus = portName + " already opened";
                return false;
            }
        }
        public bool PortClose()
        {
            //Ensure port is opened before attempting to close:
            if (sp.IsOpen)
            {
                try
                {
                    sp.Close();
                }
                catch (Exception err)
                {
                    modbusStatus = "Error closing " + sp.PortName + ": " + err.Message;
                    return false;
                }
                modbusStatus = sp.PortName + " closed successfully";
                return true;
            }
            else
            {
                modbusStatus = sp.PortName + " is not open";
                return false;
            }
        }
        private void deviceSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceDisplay devicedisplay = new DeviceDisplay();
            devicedisplay.ShowDialog();
        }

        private void mapDevicesToChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapDevicesToChannels mapdevices = new MapDevicesToChannels();
            mapdevices.ShowDialog();
        }

        private void addUnitsToDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDeviceUnits setdeviceunits = new SetDeviceUnits();
            setdeviceunits.ShowDialog();
        }

        private void addResolutionToDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDeviceResolution setdeviceresoultion = new SetDeviceResolution();
            setdeviceresoultion.ShowDialog();
        }

        private void addAlarmToDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDeviceAlarm devicealarm= new SetDeviceAlarm();
            devicealarm.ShowDialog();
        }

        private void networkSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkSetting networkSetting = new NetworkSetting();
            ;
            networkSetting.ShowDialog();
        }

        private void DeviceDataDisplay_Paint(object sender, PaintEventArgs e)
        {
            loaded = true;
        }
    }
}
