using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYU_FEG.Models
{
    public partial class Person
    {
        public Person()
        {
            ActivityToPerson = new HashSet<ActivityToPerson>();
        }

        [Key]
        public int PersonId { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string MiddleName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string SiteRole { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<ActivityToPerson> ActivityToPerson { get; set; }
    }
}
