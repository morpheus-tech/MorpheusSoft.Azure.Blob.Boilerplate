using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpheusSoft.Azure.Blob.Service.Models
{
    public class AzureBlobResponseModel
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public Stream FileStream { get; set; }
    }
}

