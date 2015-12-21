using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataDisplay.Model
{
    public class Channels
    {
        public int sno { get; set; }
        public int channel_no { get; set; }
        public string status { get; set; }
        public string reference_name { get; set; }

        public string display_name { get; set; }
    }
}
