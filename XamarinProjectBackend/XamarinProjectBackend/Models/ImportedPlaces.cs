using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinProjectBackend.Models
{
    [Keyless]
    public class ImportedPlaces
    {

        public string name { get; set; }

        public string description { get; set; }
        public string type { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
