using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinProjectBackend.Models
{

    public class Places
    {
        public string type { get; set; }
        public string name { get; set; }
        public Crs crs { get; set; }
        public Feature[] features { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string name { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Properties1 properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Properties1
    {
        public string Name { get; set; }
        public string description { get; set; }
        public string timestamp { get; set; }
        public string accVert { get; set; }
        public object isVisibleOnMap { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }

}
