using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYU_FEG.Models.ViewModel
{
    // This class is used to create a view model for the Book class / table
    public class ResultListViewModel
    {
        public IEnumerable<Byufeg> bodies { get; set; }
        public PagingInfo PagingInfo { get; set; }

        

       
    }
}
