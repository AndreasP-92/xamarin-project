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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }

        public string description { get; set; }
        public string type { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }

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
