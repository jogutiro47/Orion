using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orion.API.Models
{
    public class UserViewModel
    {
        public int  Id { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Nro. Identificación")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string Address { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes introducir un email válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }


        [Display(Name = "Tipo de documento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de documento.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int DocumentTypeId { get; set; }

        public IEnumerable<SelectListItem> DescripcionDocumento { get; set; }



        [Display(Name = "Tipo de Genero")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar tipo de genero...")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int GeneroTypeId { get; set; }

        public IEnumerable<SelectListItem> DescripcionGenero { get; set; }


        [Display(Name = "EPS")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona una EPS...")]
        public int EPSTypeId { get; set; }

        public IEnumerable<SelectListItem> DescripcionEPS { get; set; }

        [Display(Name = "Tipo de Vinculación")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione tipo de vinculación...")]
        public int TipoVinculationTypeId { get; set; }

        public IEnumerable<SelectListItem> DescripcionTipoVinculacion { get; set; }

        [Display(Name = "Tratamiento")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione tratamineto...")]
        public int TratamientoTypeId { get; set; }

        public IEnumerable<SelectListItem> DescripcionTratamiento { get; set; }

        [Display(Name = "Fuente Contacto")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione fuente de contacto...")]
        public int FuenteContactoTypeId { get; set; }

        public IEnumerable<SelectListItem> DescripcionFuenteContacto { get; set; }



    }
}
