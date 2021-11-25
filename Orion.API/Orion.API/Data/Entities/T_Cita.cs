using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Orion.API.Data.Entities
{
    public class T_Cita
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Cita")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime Date { get; set; }

        [Display(Name = "Fecha_Hora")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime DateLocal => Date.ToLocalTime();

        [Display(Name = "Solicitante")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public T_Usuario Id_Usuario { get; set; }

        [Display(Name = "Medico")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public T_Medico Id_Medico { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }



    }
}
