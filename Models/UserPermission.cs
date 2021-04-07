using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYU_FEG.Models
{
    public class UserPermission
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string[] Permissions { get; set; }
    }
}
