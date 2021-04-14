﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Last updated: 4-13-2021

namespace BYU_FEG.Models.ViewModel
{
    // This class is used to create a view model for the Byufeg class / table
    public class ResultListViewModel
    {
        public IEnumerable<Burial> burials { get; set; }
        public IEnumerable<Byufeg> bodies { get; set; }
        public PagingInfo PagingInfo { get; set; }

        

       
    }
}
