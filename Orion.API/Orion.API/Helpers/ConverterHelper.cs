using Orion.API.Data;
using Orion.API.Data.Entities;
using Orion.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orion.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<T_Cita> ToCitaAsync(CitaViewModel model, bool isNew)
        {
            return new T_Cita
            {
                Id = isNew ? 0 : model.Id,
                Date = model.Date,
                Id_Medico = await _context.t_Medicos.FindAsync(model.MedicoTypeId),
                Observacion = model.Observacion
            };
        }

        public async Task<T_Usuario> ToUserAsync(UserViewModel model, bool isNew)
        {
            return new T_Usuario
            {
                Id = isNew ? 0 : model.Id,
                Nombres = model.FirstName,
                Apellidos = model.LastName,
                IdDocumento = await _context.T_TipoDocumentos.FindAsync(model.DocumentTypeId),
                IdGenero = await _context.T_Generos.FindAsync(model.GeneroTypeId),
                IdEps = await _context.t_Eps.FindAsync(model.EPSTypeId),
                IdVinculacion = await _context.t_TipoVinculations.FindAsync(model.TipoVinculationTypeId),
                IdTratamiento = await _context.t_Tratamientos.FindAsync(model.TratamientoTypeId),
                IdFuenteContacto = await _context.t_FuenteContactos.FindAsync(model.FuenteContactoTypeId),
                Nro_Documento = model.Document,
                Direccion = model.Address,
                Telefono = model.PhoneNumber,
                Email = model.Email
            };
        }

        public UserViewModel ToUserViewModel(T_Usuario t_Usuario)
        {
            return new UserViewModel
            {
                Id = t_Usuario.Id,
                FirstName = t_Usuario.Nombres,
                LastName = t_Usuario.Apellidos,
                DocumentTypeId= t_Usuario.IdDocumento.Id,
                DescripcionDocumento = _combosHelper.GetComboDocumentTypes(),
                DescripcionGenero = _combosHelper.GetComboGeneroTypes(),
                DescripcionEPS = _combosHelper.GetComboEPSTypes(),
                DescripcionTipoVinculacion = _combosHelper.GetComboTipoVinculacionTypes(),
                DescripcionTratamiento = _combosHelper.GetComboTratamientoTypes(),
                DescripcionFuenteContacto = _combosHelper.GetComboFuenteContactoTypes(),
                Document = t_Usuario.Nro_Documento,
                Address = t_Usuario.Direccion,
                Email = t_Usuario.Email,
                PhoneNumber = t_Usuario.Telefono
             };
         }
    }
 
}
