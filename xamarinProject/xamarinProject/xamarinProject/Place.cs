using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace xamarinProject
{

    //class Places
    //{
    //    public IEnumerable<Place> features { get; set; }
    //}

    //class Place
    //{
    //    public int id { get; set; }

    //    public string name { get; set; }

    //    public string description  { get; set; }

    //    public string type { get; set; }

    //    public string lat { get; set; }

    //    public string lon { get; set; }
    //}


    public class Features
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
    }

    public class Root
    {
        public Features[] features { get; set; }
    }
}
