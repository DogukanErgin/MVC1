using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace _23haziran_web.Models.MetaDataTypes
{
    public class ProductMetaData
    {
          [Required(ErrorMessage = "Lütfen product name giriniz.")]
         [StringLength(100, ErrorMessage = "En fazla 100 karakter içermeli")]
        public String ProductName { get; set; }
    }
}
