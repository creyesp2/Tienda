using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperTienda.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }
        [Display(Name="Nombres")]
        [Required(ErrorMessage="Campo Obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Apellido{get;set;}
        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString= "{0:yyyy/MM/dd}",ApplyFormatInEditMode=true)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Sueldo")]
        public decimal sueldo { get; set; }
       
        public int TipoDocumentoID { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        [NotMapped]
        public int edad { get { return DateTime.Now.Year - FechaNacimiento.Year; } }
    }
}