using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperTienda.Models
{
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }
        public string Descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public string comentario { get; set; }
    }
}