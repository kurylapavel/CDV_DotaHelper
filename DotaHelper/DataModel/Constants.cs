using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public static class Constants
    {
        public static readonly string DefaulOpenDotaApi = "https://api.opendota.com/api/";
        public static readonly int Weight = 1;
        public static readonly double KDAWeight = 0.3;
        public static readonly int Reserve = 15;
        public static readonly int RequestsPerMinute = 60;
    }
}
