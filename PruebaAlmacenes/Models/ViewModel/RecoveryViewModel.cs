using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaAlmacenes.Models.ViewModel
{
    public class RecoveryViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        //[DataType(DataType.Date)]
        [Required]       
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]        
        public DateTime FechaNacimiento { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    }
}