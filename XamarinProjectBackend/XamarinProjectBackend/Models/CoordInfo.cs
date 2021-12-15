using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinProjectBackend.Models
{
    public class CoordInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Type { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }

        //public CoordInfo(string name, string description, string type, double lat, double lon)
        //{
        //    this.name = name;
        //    this.description = description;
        //    this.type = type;
        //    this.lat = lat;
        //    this.lon = lon;
        //}
    }
}
