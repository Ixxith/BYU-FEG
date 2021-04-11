using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYU_FEG.Models
{
    public partial class Attachment
    {
        [Key]
        public int AttachmentId { get; set; }
        public int? ByufegId { get; set; }
        [StringLength(200)]
        public string AttachmentUrl { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        [ForeignKey(nameof(ByufegId))]
        [InverseProperty("Attachment")]
        public virtual Byufeg Byufeg { get; set; }
    }
}
