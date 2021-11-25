using Microsoft.AspNetCore.Mvc.Rendering;
using Orion.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orion.API.Models
{
    public class CitaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Cita")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime Date { get; set; }

        [Display(Name = "Fecha_Hora")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime DateLocal => Date.ToLocalTime();

        [Display(Name = "Medico")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un HP Medico")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int MedicoTypeId { get; set; }

        public IEnumerable<SelectListItem> DescripcionMedico { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }
    }
}
