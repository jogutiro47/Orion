using Microsoft.AspNetCore.Mvc.Rendering;
using Orion.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orion.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetComboDocumentTypes()
        {
            List<SelectListItem> list = _context.T_TipoDocumentos.Select(x => new SelectListItem
            {
                Text = x.DescripcionDocumento,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();
            
            /*Inserta en la posición 0 - un texto */
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de documento...]",
                Value = "0"
            });

            return list;
        }
    }
}
