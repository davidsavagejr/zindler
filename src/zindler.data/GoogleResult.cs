using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zindler.data
{
    internal class GoogleResult
    {
        public string status { get; set; }
        public GoogleResultDetails[] results { get; set; }
    }

    internal class GoogleResultDetails
    {
        public GoogleResultGeometry geometry { get; set; }
    }

    internal class GoogleResultGeometry
    {
        public Geometry location { get; set; }
    }

    public class Geometry
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}
