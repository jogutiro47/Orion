﻿using Microsoft.AspNetCore.Mvc;
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

        // GET: T_Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.T_Usuarios.ToListAsync());
        }


        // GET: T_Usuario/Create
        public IActionResult Create()
        {
            UserViewModel model = new UserViewModel
            {
                DescripcionDocumento = _combosHelper.GetComboDocumentTypes()
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

                    /* _context.T_Usuarios.Add(t_Usuario);
                     _context.T_Usuarios.Update(t_Usuario);
                     await _context.SaveChangesAsync();*/


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
                    return RedirectToAction(nameof(Index), new { id = userViewModel.Id});
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




    }
}