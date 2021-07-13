using _23haziran_web.Models.MetaDataTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _23haziran_web.Models
{

    [ModelMetadataType(typeof(ProductMetaData))]
        
    public class Product //entity framework e yakışır şekilde   //validiation lar burada sağlanır attributes ler ile  data anotaciones
    {
        //validationların görevini farklı bir sınıfa vermek S prensibi için gereklidir
        //prop tab tab
       
      
      public int Id { get; set; }
      //  [Required(ErrorMessage = "Lütfen product name giriniz.")]
       // [StringLength(100, ErrorMessage = "En fazla 100 karakter içermeli")]
        public String ProductName { get; set; }
      public int Quantity{ get; set; }


        //email olursa 
        //[EmailAddress(ErrorMessage ="adam akıllı mail gir ")]
           
    }
   


    
}
