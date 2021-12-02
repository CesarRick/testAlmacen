using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaAlmacenes.Models.ViewModel
{
    public class EmpleadoViewModel
    {
        [Required]        
        [Display(Name = "DPI")]
        public string DPI { get; set; }

        [Required]        
        [Display(Name = "Nombre")]
        public string NombreCompleto { get; set; }

        [Required]
        [Display(Name = "Cantidad Hijos")]
        public int CantidadHijos { get; set; }

        [Required]
        [Display(Name = "Salario Base")]
        public decimal SalarioBase { get; set; }

        [Required]
        [Display(Name = "Bono Decreto")]
        public decimal BonoDecreto { get; set; }

        public int UsuarioID { get; set; }

        public DateTime FechaCreacion { get; set; }
    }

    public class EditEmpleadoViewModel
    {
        public int EmpleadoID { get; set; }

        [Required]
        [Display(Name = "DPI")]
        public string DPI { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NombreCompleto { get; set; }

        [Required]
        [Display(Name = "Cantidad Hijos")]
        public int CantidadHijos { get; set; }

        [Required]
        [Display(Name = "Salario Base")]
        public decimal SalarioBase { get; set; }

        [Required]
        [Display(Name = "Bono Decreto")]
        public decimal BonoDecreto { get; set; }

        public int UsuarioID { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}