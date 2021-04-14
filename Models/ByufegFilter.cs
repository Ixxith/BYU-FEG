using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Last updated: 4-13-2021
//Model to filter the data entries on the data view

namespace BYU_FEG.Models
{
    public class ByufegFilter
    {
        public int ?burial { get; set; }
        public int ?burialdepth { get; set; }

        public string burialsituation { get; set; }
        public int ?lengthofremains { get; set; }
        public string gender { get; set; }
        public string haircolor { get; set; }
        public string itemtaken { get; set; }
        public string hasartifact { get; set; }
        public string headdirection { get; set; }
        public int ?estimatedage { get; set; }
        public int ?estimatedheight { get; set; }
        [DataType(DataType.Date)]
        public DateTime datefoundbegin { get; set; } = DateTime.Now.AddYears(-100);
        [DataType(DataType.Date)]
        public DateTime datefoundend { get; set; } = DateTime.Now;
    }
}
