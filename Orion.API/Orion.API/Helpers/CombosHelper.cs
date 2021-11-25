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

        public IEnumerable<SelectListItem> GetComboEPSTypes()
        {
            List<SelectListItem> list = _context.t_Eps.Select(x => new SelectListItem
            {
                Text = x.DescEPS,
                Value = $"{x.Id}"
            })
               .OrderBy(x => x.Text)
               .ToList();

            /*Inserta en la posición 0 - un texto */
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione EPS...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboFuenteContactoTypes()
        {
            List<SelectListItem> list = _context.t_FuenteContactos.Select(x => new SelectListItem
            {
                Text = x.Desc_fuente_contacto,
                Value = $"{x.Id}"
            })
              .OrderBy(x => x.Text)
              .ToList();

            /*Inserta en la posición 0 - un texto */
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione Fuente de Contacto...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboGeneroTypes()
        {
            List<SelectListItem> list = _context.T_Generos.Select(x => new SelectListItem
            {
                Text = x.DescGenero,
                Value = $"{x.Id}"
            })
                 .OrderBy(x => x.Text)
                 .ToList();

            /*Inserta en la posición 0 - un texto */
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione género...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboMedicoTypes()
        {
            List<SelectListItem> list = _context.t_Medicos.Select(x => new SelectListItem
            {
                Text = x.NombreMedico,
                Value = $"{x.Id}"
            })
                 .OrderBy(x => x.Text)
                 .ToList();

            /*Inserta en la posición 0 - un texto */
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Médico...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboTipoVinculacionTypes()
        {
            List<SelectListItem> list = _context.t_TipoVinculations.Select(x => new SelectListItem
            {
                Text = x.DescTipoVinculacion,
                Value = $"{x.Id}"
            })
                  .OrderBy(x => x.Text)
                  .ToList();

            /*Inserta en la posición 0 - un texto */
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione Tipo Vinculación...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboTratamientoTypes()
        {
            List<SelectListItem> list = _context.t_Tratamientos.Select(x => new SelectListItem
            {
                Text = x.Desc_Tratamiento,
                Value = $"{x.Id}"
            })
                  .OrderBy(x => x.Text)
                  .ToList();

            /*Inserta en la posición 0 - un texto */
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione Tramiento...]",
                Value = "0"
            });

            return list;
        }
    }

}
