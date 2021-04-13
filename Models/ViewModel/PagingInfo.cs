using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYU_FEG.Models.ViewModel
{
    public class PagingInfo
    {
        // This class is used to contol paging for the Book database
        public int TotalNumItems { get; set; }
        
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage => (int) Math.Ceiling((decimal) TotalNumItems / ItemsPerPage);

        public BYUFEGContext context { get; set; }
    }
}
