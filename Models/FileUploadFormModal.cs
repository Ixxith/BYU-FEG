using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Last updated: 4-13-2021
//To upload files to S3

namespace BYU_FEG.Models
{
    public class FileUploadFormModal
    {
        [Required]
        [Display(Name="File")]
        public IFormFile FormFile { get; set; }
    }
}
