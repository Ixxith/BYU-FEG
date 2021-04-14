using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Last updated: 4-13-2021
//Model for the burial table in the database. PK = BurialId

namespace BYU_FEG.Models
{
    public partial class Burial
    {
        public Burial()
        {
            Byufeg = new HashSet<Byufeg>();
        }

        [Column("burial_concat")]
        [StringLength(30)]
        public string BurialConcat { get; set; }
        [Key]
        [Column("burial_ID")]
        public int BurialId { get; set; }
        [Column("burial_location_NS")]
        [StringLength(1)]
        public string BurialLocationNs { get; set; }
        [Column("burial_location_EW")]
        [StringLength(1)]
        public string BurialLocationEw { get; set; }
        [Column("low_pair_NS")]
        public int? LowPairNs { get; set; }
        [Column("high_pair_NS")]
        public int? HighPairNs { get; set; }
        [Column("low_pair_EW")]
        public int? LowPairEw { get; set; }
        [Column("high_pair_EW")]
        public int? HighPairEw { get; set; }
        [Column("burial_subplot")]
        [StringLength(2)]
        public string BurialSubplot { get; set; }

        [InverseProperty("Burial")]
        public virtual ICollection<Byufeg> Byufeg { get; set; }
    }
}
