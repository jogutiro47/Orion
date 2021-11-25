using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Orion.API.Data.Entities
{
    public class T_EstadoCita
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        [Display(Name = "Estado Cita")]
        public string Desc_EstadoCita { get; set; }

        [JsonIgnore]
        public ICollection<T_Cita> T_Citas { get; set; }
    }
}
