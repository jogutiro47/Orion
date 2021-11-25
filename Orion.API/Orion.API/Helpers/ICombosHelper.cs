using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orion.API.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboDocumentTypes();

        IEnumerable<SelectListItem> GetComboGeneroTypes();
        IEnumerable<SelectListItem> GetComboEPSTypes();
        IEnumerable<SelectListItem> GetComboTipoVinculacionTypes();
        IEnumerable<SelectListItem> GetComboTratamientoTypes();
        IEnumerable<SelectListItem> GetComboFuenteContactoTypes();

        IEnumerable<SelectListItem> GetComboMedicoTypes();


    }
}
