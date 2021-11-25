using System.ComponentModel.DataAnnotations;

namespace Orion.API.Data.Entities
{
    public class T_EstadoCivil
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        /*[Required]*/
        [Display(Name = "Estado Civil")]
        public string DescEstadoCivil { get; set; }

    }
}
