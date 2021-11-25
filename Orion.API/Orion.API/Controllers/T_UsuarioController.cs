using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orion.API.Data;
using Orion.API.Data.Entities;
using Orion.API.Helpers;
using Orion.API.Models;
using System;
using System.Threading.Tasks;

namespace Orion.API.Controllers
{
    public class T_UsuarioController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public T_UsuarioController(DataContext context, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.T_Usuarios.ToListAsync());
        }


        public IActionResult Create()
        {
            UserViewModel model = new UserViewModel
            {
                DescripcionDocumento = _combosHelper.GetComboDocumentTypes(),
                DescripcionGenero = _combosHelper.GetComboGeneroTypes(),
                DescripcionEPS = _combosHelper.GetComboEPSTypes(),
                DescripcionTipoVinculacion = _combosHelper.GetComboTipoVinculacionTypes(),
                DescripcionTratamiento = _combosHelper.GetComboTratamientoTypes(),
                DescripcionFuenteContacto = _combosHelper.GetComboFuenteContactoTypes()

            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    T_Usuario t_Usuario = await _converterHelper.ToUserAsync(model, true);

                    _context.Add(t_Usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));


                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este usuario creado");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }


                return RedirectToAction(nameof(Index));
            }
            model.DescripcionDocumento = _combosHelper.GetComboDocumentTypes();
            model.DescripcionGenero = _combosHelper.GetComboGeneroTypes();
            model.DescripcionEPS = _combosHelper.GetComboEPSTypes();
            model.DescripcionTipoVinculacion = _combosHelper.GetComboTipoVinculacionTypes();
            model.DescripcionTratamiento = _combosHelper.GetComboTratamientoTypes();
            model.DescripcionFuenteContacto = _combosHelper.GetComboFuenteContactoTypes();
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            T_Usuario t_Usuario = await _context.T_Usuarios
            .Include(x => x.IdDocumento)
            .FirstOrDefaultAsync(x => x.Id == id);

            if (t_Usuario == null)
            {
                return NotFound();
            }

            UserViewModel model = _converterHelper.ToUserViewModel(t_Usuario);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    T_Usuario t_Usuario = await _converterHelper.ToUserAsync(userViewModel, false);
                    _context.T_Usuarios.Update(t_Usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { id = userViewModel.Id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un usuario con esta identificación");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            userViewModel.DescripcionDocumento = _combosHelper.GetComboDocumentTypes();

            return View(userViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            T_Usuario t_Usuario = await _context.T_Usuarios
               .FirstOrDefaultAsync(x => x.Id == id);
            if (t_Usuario == null)
            {
                return NotFound();
            }

            _context.T_Usuarios.Remove(t_Usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = t_Usuario.Id });
        }

        public async Task<IActionResult> IndexPaciente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            T_Usuario t_detalleusuario = await _context.T_Usuarios
                 .Include(x => x.T_Citas)
                 .ThenInclude(x => x.Id_Medico)
                 .Include(x => x.IdDocumento)
                 .Include(x => x.IdEps)
                 .Include(x => x.IdGenero)
                 .Include(x => x.IdTratamiento)
                 .Include(x => x.IdVinculacion)
                 .Include(x => x.IdFuenteContacto)
               .FirstOrDefaultAsync(x => x.Id == id);

            if (t_detalleusuario == null)
            {
                return NotFound();
            }


            return View(t_detalleusuario);
        }


        public async Task<IActionResult> AddCita(int? id)
        {
            CitaViewModel model = new CitaViewModel
            {
           
                DescripcionMedico = _combosHelper.GetComboMedicoTypes()

            };

            T_Usuario t_Usuario = await _context.T_Usuarios.FindAsync(id);
            if (t_Usuario == null)
            {
                return NotFound();
            }

            model.PacienteTypeId = t_Usuario.Id;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCita(CitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    T_Cita t_Cita = await _converterHelper.ToCitaAsync(model, true);
                    _context.Add(t_Cita);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexPaciente));
                }

                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe esta Cita regsitrada");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }


                return RedirectToAction(nameof(IndexPaciente));
            }
            model.DescripcionMedico = _combosHelper.GetComboMedicoTypes();

            return View(model);
        }

    }
}
