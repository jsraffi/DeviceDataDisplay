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
using DeviceDataDisplay.ViewModels;
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
            
            ShowChannels.Items.AddRange(channels);

            ChannelSetting();
        }

        private void PaintPanelBorder(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid);

        }

        private void ChannelSetting(int noOfChannels=32, int columns=8,int rows=4)
        {
            
            Font fontlessthan8 = new Font("Arial Unicode MS", 25, FontStyle.Bold);
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

            /*Creating DataTable onload once*/
            //string connectionstring = "SERVER=localhost;Database=datalogger;UID=root;Password=Raffi1971$";

            MySqlConnection Connection = new MySqlConnection(ConfigurationSettings.AppSettings["dbConnectionString"]);
            Connection.Open();
            string query = "Select channel_no,display_name,reference_name,um.units as unitsmesure,value,minlevel,maxlevel from channels ch inner join unitsofmesurement um on ch.units=um.unitID";
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
                    Label lbl = new Label();

                    if (noOfChannels == 1)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 100, FontStyle.Bold);
                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
                        Graphics g = CreateGraphics();
                        SizeF extent = g.MeasureString(lbl.Text, lbl.Font);

                        lbl.Height = Convert.ToInt32(extent.Height);
                        lbl.Width = Convert.ToInt32(extent.Width);
                        var x = (p.Width / 2) - (lbl.Width/2);
                        Point pointvalue = new Point(x, ((p.Height / 2) - (lbl.Height / 2)));
                        
                        lbl.Location = pointvalue;
                        
                        lbl.ForeColor = Color.White;
                        lbl.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lbl);

                        //Adding channel to panel
                        Font fontChannelminmax = new Font("Arial Unicode MS", 40, FontStyle.Bold);
                        
                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannelminmax;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();

                        
                        SizeF extentchannel = g.MeasureString(lblchannelname.Text, lblchannelname.Font);

                        lblchannelname.Height = Convert.ToInt32(extentchannel.Height);
                        lblchannelname.Width = Convert.ToInt32(extentchannel.Width);

                        var xchannelname = (p.Width / 2) - (lblchannelname.Width / 2);
                        Point pointvaluechannelname = new Point(xchannelname, (p.Height/6));

                        lblchannelname.Location = pointvaluechannelname;

                        lblchannelname.ForeColor = Color.White;
                        lblchannelname.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblchannelname);

                        //adding min level
                        
                        

                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height*.65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);
                    }
                    if (noOfChannels ==2)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 70, FontStyle.Bold);
                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
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
                        Font fontChannelminmax = new Font("Arial Unicode MS", 30, FontStyle.Bold);

                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannelminmax;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();


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



                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);
                    }
                    if (noOfChannels >=3 && noOfChannels <=4)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 60, FontStyle.Bold);
                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
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
                        Font fontChannelminmax = new Font("Arial Unicode MS", 25, FontStyle.Bold);

                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannelminmax;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();


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
                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);

                    }
                    if (noOfChannels >= 5 && noOfChannels <= 8)
                    {
                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 32, FontStyle.Bold);
                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
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
                        Font fontChannelminmax = new Font("Arial Unicode MS", 20, FontStyle.Bold);

                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannelminmax;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();


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
                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);
                    }

                    if (noOfChannels >= 9 && noOfChannels <= 12)
                    {

                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 28, FontStyle.Bold);
                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
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
                        Font fontChannelminmax = new Font("Arial Unicode MS", 18, FontStyle.Bold);

                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannelminmax;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();


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
                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);
                    }
                    if (noOfChannels >= 13 && noOfChannels <= 16)
                    {

                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 24, FontStyle.Bold);
                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
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
                        Font fontChannelminmax = new Font("Arial Unicode MS", 15, FontStyle.Bold);

                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannelminmax;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();


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
                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);
                    }

                    if (noOfChannels >= 17 && noOfChannels <= 20)
                    {

                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 20, FontStyle.Bold);
                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
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
                        Font fontChannelminmax = new Font("Arial Unicode MS", 12, FontStyle.Bold);

                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannelminmax;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();


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
                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);
                    }
                    if (noOfChannels >= 21 && noOfChannels <= 24)
                    {

                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 16, FontStyle.Bold);
                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
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
                        Font fontChannelminmax = new Font("Arial Unicode MS", 9, FontStyle.Bold);
                        Font fontChannel = new Font("Arial Unicode MS", 12, FontStyle.Bold);
                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannel;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();


                        SizeF extentchannel = g.MeasureString(lblchannelname.Text, lblchannelname.Font);

                        lblchannelname.Height = Convert.ToInt32(extentchannel.Height);
                        lblchannelname.Width = Convert.ToInt32(extentchannel.Width);

                        var xchannelname = (p.Width / 2) - (lblchannelname.Width / 2);
                        Point pointvaluechannelname = new Point(xchannelname, (p.Height / 6));

                        lblchannelname.Location = pointvaluechannelname;

                        lblchannelname.ForeColor = Color.White;
                        lblchannelname.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblchannelname);

                        //adding min level
                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);

                    }
                    if (noOfChannels >= 25 && noOfChannels <= 28)
                    {

                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 14, FontStyle.Bold);

                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
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
                        Font fontChannelminmax = new Font("Arial Unicode MS", 7, FontStyle.Bold);
                        Font fontChannel = new Font("Arial Unicode MS", 12, FontStyle.Bold);

                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannel;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();


                        SizeF extentchannel = g.MeasureString(lblchannelname.Text, lblchannelname.Font);

                        lblchannelname.Height = Convert.ToInt32(extentchannel.Height);
                        lblchannelname.Width = Convert.ToInt32(extentchannel.Width);

                        var xchannelname = (p.Width / 2) - (lblchannelname.Width / 2);
                        Point pointvaluechannelname = new Point(xchannelname, (p.Height / 6));

                        lblchannelname.Location = pointvaluechannelname;

                        lblchannelname.ForeColor = Color.White;
                        lblchannelname.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblchannelname);

                        //adding min level
                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);
                    }
                    if (noOfChannels >= 29 && noOfChannels <= 32)
                    {

                        DataRow drow = getchannel(tblChannel, channelid);
                        //Adding value to panel and units
                        Font fontChannel1 = new Font("Arial Unicode MS", 13, FontStyle.Bold);
                        lbl.Font = fontChannel1;
                        lbl.AutoSize = true;
                        lbl.Text = drow["value"].ToString() + "  " + drow["unitsmesure"].ToString();
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
                        Font fontChannelminmax = new Font("Arial Unicode MS", 6, FontStyle.Bold);
                        Font fontChannel = new Font("Arial Unicode MS", 12, FontStyle.Bold);
                        Label lblchannelname = new Label();
                        lblchannelname.Font = fontChannel;
                        lblchannelname.AutoSize = true;
                        lblchannelname.Text = drow["reference_name"].ToString();


                        SizeF extentchannel = g.MeasureString(lblchannelname.Text, lblchannelname.Font);

                        lblchannelname.Height = Convert.ToInt32(extentchannel.Height);
                        lblchannelname.Width = Convert.ToInt32(extentchannel.Width);

                        var xchannelname = (p.Width / 2) - (lblchannelname.Width / 2);
                        Point pointvaluechannelname = new Point(xchannelname, (p.Height / 6));

                        lblchannelname.Location = pointvaluechannelname;

                        lblchannelname.ForeColor = Color.White;
                        lblchannelname.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblchannelname);

                        //adding min level
                        Label lblmin = new Label();
                        lblmin.Font = fontChannelminmax;
                        lblmin.AutoSize = true;
                        lblmin.Text = "Min = " + drow["minlevel"].ToString();


                        SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

                        lblmin.Height = Convert.ToInt32(extentminlevel.Height);
                        lblmin.Width = Convert.ToInt32(extentminlevel.Width);

                        var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
                        Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

                        lblmin.Location = pointminlevel;

                        lblmin.ForeColor = Color.White;
                        lblmin.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmin);

                        //adding max level

                        Label lblmax = new Label();
                        lblmax.Font = fontChannelminmax;
                        lblmax.AutoSize = true;
                        lblmax.Text = "Max = " + drow["maxlevel"].ToString();


                        SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

                        lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
                        lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

                        var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
                        Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

                        lblmax.Location = pointmaxlevel;

                        lblmax.ForeColor = Color.White;
                        lblmax.BorderStyle = BorderStyle.FixedSingle;
                        p.Controls.Add(lblmax);

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
            int channelNo = Convert.ToInt32(ShowChannels.SelectedItem.ToString());
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i].Name != "mainmenuStrip")
                {
                    Controls[i].Dispose();
                }
            }
            
            ChannelSetting(channelNo, 3, 3);

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

        private Panel screenbuilder(Panel p, string valuewithunits, string channelname, int minlevel, int maxlevel, Font valuefont, Font minmaxchannel)
        {

            Label lbl = new Label();
            //Adding value to panel and units
            Font fontChannel1 = valuefont;
            Font fontChannelminmax = minmaxchannel;
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
            lblchannelname.Font = fontChannelminmax;
            lblchannelname.AutoSize = true;
            lblchannelname.Text = channelname;


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

            Label lblmin = new Label();
            lblmin.Font = fontChannelminmax;
            lblmin.AutoSize = true;
            lblmin.Text = "Min = " + minlevel.ToString();


            SizeF extentminlevel = g.MeasureString(lblmin.Text, lblmin.Font);

            lblmin.Height = Convert.ToInt32(extentminlevel.Height);
            lblmin.Width = Convert.ToInt32(extentminlevel.Width);

            var xminlevel = (p.Width / 2) - (lblmin.Width / 2);
            Point pointminlevel = new Point(xminlevel, Convert.ToInt32((p.Height * .65)));

            lblmin.Location = pointminlevel;

            lblmin.ForeColor = Color.White;
            lblmin.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(lblmin);

            //adding max level

            Label lblmax = new Label();
            lblmax.Font = fontChannelminmax;
            lblmax.AutoSize = true;
            lblmax.Text = "Max = " + maxlevel.ToString();


            SizeF extentmaxlevel = g.MeasureString(lblmax.Text, lblmax.Font);

            lblmax.Height = Convert.ToInt32(extentmaxlevel.Height);
            lblmax.Width = Convert.ToInt32(extentmaxlevel.Width);

            var xmaxlevel = (p.Width / 2) - (lblmax.Width / 2);
            Point pointmaxlevel = new Point(xmaxlevel, Convert.ToInt32((p.Height * .80)));

            lblmax.Location = pointmaxlevel;

            lblmax.ForeColor = Color.White;
            lblmax.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(lblmax);




            return p;
        }
    }
}
