using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Model.obj
{
    public class Cloud
    {
        [JsonProperty("all")]
        public int Percentage { get; set; }
    }
}
