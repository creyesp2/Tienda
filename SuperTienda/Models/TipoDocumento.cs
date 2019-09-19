using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperTienda.Models
{
    public class TipoDocumento
    {   [Key]
        public int TipoDocumentoID { get; set; }
         [Display(Name = "Tipo Documento")]
        public string Descricion { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}