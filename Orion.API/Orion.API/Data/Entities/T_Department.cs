using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Orion.API.Data.Entities
{
    public class T_Department
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The filed {0} must contain less than {1} characteres.")]
        [Required]
        [Display(Name = "Department")]
        public string Name { get; set; }

        public ICollection<T_City> T_Cities { get; set; }

        [DisplayName("Cities Number")]
        public int CitiesNumber => T_Cities == null ? 0 : T_Cities.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdCountry { get; set; }

        [JsonIgnore]
        public T_Country Country { get; set; }
    }
}
