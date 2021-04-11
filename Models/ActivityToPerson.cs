using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYU_FEG.Models
{
    public partial class ActivityToPerson
    {
        public int? ActivityId { get; set; }
        public int? PersonId { get; set; }
        [Key]
        public int ActivityToPersonId { get; set; }

        [ForeignKey(nameof(ActivityId))]
        [InverseProperty("ActivityToPerson")]
        public virtual Activity Activity { get; set; }
        [ForeignKey(nameof(PersonId))]
        [InverseProperty("ActivityToPerson")]
        public virtual Person Person { get; set; }
    }
}
