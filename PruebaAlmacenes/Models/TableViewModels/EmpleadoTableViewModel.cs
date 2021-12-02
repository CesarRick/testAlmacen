using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAlmacenes.Models.TableViewModels
{
    public class EmpleadoTableViewModel
    {
        
        public int EmpleadoID { get; set; }
        public string DPI { get; set; }
        public string NombreCompleto { get; set; }
        public int CantidadHijos { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal BonoDecreto { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}