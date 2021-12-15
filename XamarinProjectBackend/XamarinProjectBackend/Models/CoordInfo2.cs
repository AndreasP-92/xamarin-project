using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinProjectBackend.Models
{
    public class CoordInfo2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }

        public string description { get; set; }
        public string type { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
