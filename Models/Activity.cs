using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYU_FEG.Models
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityToPerson = new HashSet<ActivityToPerson>();
            Byufeg = new HashSet<Byufeg>();
        }

        [StringLength(19)]
        public string Date { get; set; }
        [Key]
        public int ActivityId { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<ActivityToPerson> ActivityToPerson { get; set; }
        [InverseProperty("Activity")]
        public virtual ICollection<Byufeg> Byufeg { get; set; }
    }
}
