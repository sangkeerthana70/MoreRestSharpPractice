using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreRestSharpPractice
{
    class Weather
    {
        public string name { get; set; }
        public float temp { get; set; }
        public Dictionary<string, float> main { get; set; }
        public int visibility { get; set; }
        public Dictionary<string,float> wind { get; set; }
        public List<Dictionary<string,string>> weather { get; set; }

        
    }
}
