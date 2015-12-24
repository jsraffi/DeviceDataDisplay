using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataDisplay.ViewModels
{
    public class Channel
    {
        public int channel_no { get; set; }
        public string display_name { get; set; }

        public string reference_name { get; set; }

        public string unitmesure { get; set; }

        public int minlevel { get; set; }

        public int maxlevel { get; set; }
        public int value { get; set; }
    }
}
