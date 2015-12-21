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

namespace DeviceDataDisplay
{
    public partial class DeviceDataDisplay : Form
    {
        
        public DeviceDataDisplay()
        {
            InitializeComponent();
        }

        private void DeviceDataDisplay_Load(object sender, EventArgs e)
        {
            string[] channels = new string[] { "1", "2", "3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31","32"};


            ShowNoOfChannels.Items.AddRange(channels);

            ChannelSetting();
        }

        private void PaintPanelBorder(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid);

        }

        private void ChannelSetting(int noOfChannels=32, int columns=8,int rows=4)
        {
            int channelrows = 0;
            int channelcol = 0;
            Font fontlessthan8 = new Font("Vaerdana", 25, FontStyle.Bold);
            Point pointlessthan8 = new Point(100, 200);
            Point pointbetween9and12 = new Point(75, 125);
            Point pointbetween13and16 = new Point(75, 100);
            Point pointbetween17and20 = new Point(50, 75);
            Point pointbetween20and24 = new Point(50, 75);
            Point pointbetween24and28 = new Point(35, 75);
            Font fontless2024 = new Font("Vaerdana", 20, FontStyle.Bold);
            Font fontless2528 = new Font("Vaerdana", 18, FontStyle.Bold);
            Font fontless2932 = new Font("Vaerdana", 15, FontStyle.Bold);
            if (noOfChannels >= 1 && noOfChannels <= 4)
            {
                rows = 2;
                columns = 4;

                if (noOfChannels == 1)
                {
                    channelcol = 1;
                    channelrows = 1;
                    rows = 1;
                    columns = 1;

                }
                else if (noOfChannels == 2)
                {
                    channelcol = 2;
                    channelrows = 1;
                    rows = 1;
                    columns = 2;
                }
                else if (noOfChannels == 3)
                {
                    channelcol = 2;
                    channelrows = 2;
                    rows = 2;
                    columns = 2;
                }
                else if (noOfChannels == 4)
                {
                    channelcol = 2;
                    channelrows = 2;
                    rows = 2;
                    columns = 2;
                }
            }
            else if (noOfChannels >= 5 && noOfChannels <= 8)
            {
                channelcol = 4;
                channelrows = 2;
                rows = 2;
                columns = 4;

            }
            else if (noOfChannels >= 9 && noOfChannels <= 12)
            {
                rows = 3;
                columns = 4;
                channelcol = 4;
                channelrows = 3;
            }
            else if (noOfChannels >= 13 && noOfChannels <= 16)
            {
                rows = 4;
                columns = 4;
                channelrows = 4;
                channelcol = 4;
            }
            else if (noOfChannels >= 13 && noOfChannels <= 16)
            {
                rows = 4;
                columns = 4;
                channelrows = 4;
                channelcol = 4;
            }
            else if (noOfChannels >= 17 && noOfChannels <= 20)
            {
                rows = 4;
                columns = 5;
                channelrows = 4;
                channelcol = 5;
            }
            else if (noOfChannels >= 21 && noOfChannels <= 24)
            {
                rows = 4;
                columns = 6;
                channelrows = 4;
                channelcol = 6;
            }
            else if (noOfChannels >= 25 && noOfChannels <= 28)
            {
                rows = 4;
                columns = 7;
                channelrows = 4;
                channelcol = 7;
            }
            else if (noOfChannels >= 29 && noOfChannels <= 32)
            {
                rows = 4;
                columns = 8;
                channelrows = 4;
                channelcol = 8;
            }



            int width = Screen.PrimaryScreen.WorkingArea.Width;
            int height = Screen.PrimaryScreen.WorkingArea.Height - 22;
            int panelheight = (height / rows);
            int panelwidth = (width / columns);

            /*Creating DataTable onload once*/
            string connectionstring = "SERVER=localhost;Database=datalogger;UID=root;Password=Raffi1971$";

            MySqlConnection Connection = new MySqlConnection(connectionstring);
            Connection.Open();
            string query = "Select * from channels";
            MySqlDataAdapter channeladapter = new MySqlDataAdapter(query, Connection);
            DataSet channelsdata = new DataSet();
            channeladapter.Fill(channelsdata, "channels");

            DataTable tblChannel = channelsdata.Tables["channels"];
            int channelid = 0;
            for (var i = 0; i < channelrows; i++)
            {
                
                for (var j = 0; j < channelcol; j++)
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
                    Label lbl = new Label();
                        
                    if (noOfChannels >= 1 && noOfChannels <= 8)
                    {

                        lbl.Text = getchannel(tblChannel, "Channel " + channelid.ToString());
                        lbl.Location = pointlessthan8;
                        lbl.Font = fontlessthan8;
                        lbl.Height =50;
                        lbl.Width =250;
                        lbl.ForeColor = Color.White;
                        p.Controls.Add(lbl);
                        
                    }

                    if (noOfChannels >= 9 && noOfChannels <= 12)
                    {
                        
                        lbl.Text = getchannel(tblChannel, "Channel " + channelid.ToString());
                        lbl.Location = pointbetween9and12;
                        lbl.Font = fontlessthan8;
                        lbl.Height = 50;
                        lbl.Width = 250;
                        lbl.ForeColor = Color.White;
                        p.Controls.Add(lbl);

                    }
                    if (noOfChannels >= 13 && noOfChannels <= 16)
                    {
                        
                        lbl.Text = getchannel(tblChannel, "Channel " + channelid.ToString());
                        lbl.Location = pointbetween13and16;
                        lbl.Font = fontlessthan8;
                        lbl.Height = 50;
                        lbl.Width = 250;
                        lbl.ForeColor = Color.White;
                        p.Controls.Add(lbl);
                    }

                    if (noOfChannels >= 17 && noOfChannels <= 20)
                    {
                        
                        lbl.Text = getchannel(tblChannel, "Channel " + channelid.ToString());
                        lbl.Location = pointbetween17and20;
                        lbl.Font = fontlessthan8;
                        lbl.Height = 50;
                        lbl.Width = 250;
                        lbl.ForeColor = Color.White;
                        p.Controls.Add(lbl);
                    }
                    if (noOfChannels >= 21 && noOfChannels <= 24)
                    {
                        
                        lbl.Text = getchannel(tblChannel, "Channel " + channelid.ToString());
                        lbl.Location = pointbetween20and24;
                        lbl.Font = fontless2024;
                        lbl.Height = 50;
                        lbl.Width = 200;
                        lbl.ForeColor = Color.White;
                        p.Controls.Add(lbl);
                    }
                    if (noOfChannels >= 25 && noOfChannels <= 28)
                    {
                        
                        lbl.Text = getchannel(tblChannel, "Channel " + channelid.ToString());
                        lbl.Location = pointbetween20and24;
                        lbl.Font = fontless2528;
                        lbl.Height = 50;
                        lbl.Width = 160;
                        lbl.ForeColor = Color.White;
                        p.Controls.Add(lbl);
                    }
                    if (noOfChannels >= 29 && noOfChannels <= 32)
                    {
                        
                        lbl.Text = getchannel(tblChannel, "Channel " + channelid.ToString());
                        lbl.Location = pointbetween20and24;
                        lbl.Font = fontless2932;
                        lbl.Height = 50;
                        lbl.Width = 130;
                        lbl.ForeColor = Color.White;
                        p.Controls.Add(lbl);
                    }
                    Controls.Add(p);
                    
                }
            }

        }

        private string getFromDB(string channelname)
        {
            string connectionstring = "SERVER=localhost;Database=datalogger;UID=root;Password=Raffi1971$";

            MySqlConnection Connection = new MySqlConnection(connectionstring);
            Connection.Open();
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "Select display_name from channels where reference_name ='" + channelname + "'";
            object result = cmd.ExecuteScalar();
            return result.ToString();
        }

        private string getchannel(DataTable memchannel,string channelno)
        {
            var result = (from channel in memchannel.AsEnumerable()
                         where channel.Field<string>("reference_name") == channelno
                         select channel.Field<string>("display_name")).First<string>();

            return result.ToString();
            
        }

        private void ShowNoOfChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int channelNo = Convert.ToInt32(ShowNoOfChannels.SelectedItem.ToString());
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i].Name != "toolstripmenu" )
                {
                    Controls[i].Dispose();
                }
            }
            int channelRows = 0;
            channelRows = (channelNo == 1) ? 1 : channelRows + 1;

            ChannelSetting(channelNo, 3, 3);
        }
            
            
            

        

    }
}
