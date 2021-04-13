using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYU_FEG.Models.ViewModel
{
    public class DetailsViewModel
    {
        public Byufeg byufeg { get; set; }
        public Burial burial { get; set; }
        public IEnumerable<Attachment> attachment { get; set; }
    }
}
