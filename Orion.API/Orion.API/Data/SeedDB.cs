using System.Linq;
using System.Threading.Tasks;
using Orion.API.Data.Entities;

namespace Orion.API.Data
{
    public class SeedDB
    {

        private readonly DataContext _context;


        public SeedDB(DataContext context)
        {
            _context = context;

        }

        public async Task SeedAsync()
        {
            /*Si no existe la base de datos la crea o sincroniza*/
            await _context.Database.EnsureCreatedAsync();
            await CheckT_TipoDocumentoAsync();
            await CheckT_EstadoCitasAsync();
            await CheckT_GenerosAsync();
            await Checktt_EpsAsync();
            await Checkt_FuenteContactosAsync();
            await Checkt_TipoVinculationsAsync();
            await Checkt_TratamientosAsync();

        }

        private async Task CheckT_TipoDocumentoAsync()
        {
            if (!_context.T_TipoDocumentos.Any())
            {
                _context.T_TipoDocumentos.Add(new T_TipoDocumento { DescripcionDocumento = "Cédula", Abreviatura = "C.C" });
                _context.T_TipoDocumentos.Add(new T_TipoDocumento { DescripcionDocumento = "Tarjeta de Identidad", Abreviatura = "T.I" });
                _context.T_TipoDocumentos.Add(new T_TipoDocumento { DescripcionDocumento = "NIT", Abreviatura = "NIT" });
                _context.T_TipoDocumentos.Add(new T_TipoDocumento { DescripcionDocumento = "Pasaporte", Abreviatura = "P.TE" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckT_EstadoCitasAsync()
        {
            if (!_context.T_EstadoCitas.Any())
            {
                _context.T_EstadoCitas.Add( new T_EstadoCita { Desc_EstadoCita = "Pendiente"});
                _context.T_EstadoCitas.Add(new T_EstadoCita { Desc_EstadoCita = "Confirmada" });
                _context.T_EstadoCitas.Add(new T_EstadoCita { Desc_EstadoCita = "Reprogramada" });
                _context.T_EstadoCitas.Add(new T_EstadoCita { Desc_EstadoCita = "Cancelada" });
                _context.T_EstadoCitas.Add(new T_EstadoCita { Desc_EstadoCita = "Completada" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckT_GenerosAsync()
        {
            if (!_context.T_Generos.Any())
            {
                _context.T_Generos.Add(new T_Genero { DescGenero = "Femenino" });
                _context.T_Generos.Add(new T_Genero { DescGenero = "Masculino" });
                _context.T_Generos.Add(new T_Genero { DescGenero = "Otro" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task Checktt_EpsAsync()
        {
            if (!_context.t_Eps.Any())
            {
                _context.t_Eps.Add(new T_EPS { DescEPS = "Caja COPI" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Comparta" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Coomeva" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Coosalud" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Medicina Integral" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Medimas" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Mutual SER" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Nueva EPS" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Salud Total" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Sanidad Policia" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Sanitas" });
                _context.t_Eps.Add(new T_EPS { DescEPS = "Sura EPS" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task Checkt_FuenteContactosAsync()
        {
            if (!_context.t_FuenteContactos.Any())
            {
                _context.t_FuenteContactos.Add(new T_FuenteContacto { Desc_fuente_contacto = "Instagram" });
                _context.t_FuenteContactos.Add(new T_FuenteContacto { Desc_fuente_contacto = "Página Web" });
                _context.t_FuenteContactos.Add(new T_FuenteContacto { Desc_fuente_contacto = "WhatsApp" });
                _context.t_FuenteContactos.Add(new T_FuenteContacto { Desc_fuente_contacto = "Referido" });
                _context.t_FuenteContactos.Add(new T_FuenteContacto { Desc_fuente_contacto = "Valla" });
                _context.t_FuenteContactos.Add(new T_FuenteContacto { Desc_fuente_contacto = "Facebook" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task Checkt_TipoVinculationsAsync()
        {
            if (!_context.t_TipoVinculations.Any())
            {
                _context.t_TipoVinculations.Add(new T_TipoVinculation { DescTipoVinculacion = "Beneficiario" });
                _context.t_TipoVinculations.Add(new T_TipoVinculation { DescTipoVinculacion = "Cotizante" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task Checkt_TratamientosAsync()
        {
            if (!_context.t_Tratamientos.Any())
            {
                _context.t_Tratamientos.Add(new T_Tratamiento { Desc_Tratamiento = "Abdominoplastia" });
                _context.t_Tratamientos.Add(new T_Tratamiento { Desc_Tratamiento = "Bichectomia" });
                _context.t_Tratamientos.Add(new T_Tratamiento { Desc_Tratamiento = "Biolifting" });
                await _context.SaveChangesAsync();
            }
        }


    }
}
