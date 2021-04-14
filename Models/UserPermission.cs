using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Last updated: 4-13-2021
//Model for table about users and there permissions

namespace BYU_FEG.Models
{
    public class UserPermission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public bool IsResearcher { get; set; }
        public bool IsAdmin { get; set; }
    }
}
