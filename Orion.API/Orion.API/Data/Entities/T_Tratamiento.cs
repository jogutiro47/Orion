using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Orion.API.Data.Entities
{
    public class T_Tratamiento
    {
        public int Id { get; set; }

        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        [Display(Name = "Tratamiento de Interes")]
        public string Desc_Tratamiento { get; set; }
        [JsonIgnore]
        public ICollection<T_Usuario> T_Usuario { get; set; }
    }
}
