using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orion.API.Data;
using Orion.API.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Orion.API.Controllers
{
    public class T_TipoDocumentoController : Controller
    {
        private readonly DataContext _context;

        public T_TipoDocumentoController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.T_TipoDocumentos.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(T_TipoDocumento t_TipoDocumento)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(t_TipoDocumento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento.");
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



            return View(t_TipoDocumento);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            T_TipoDocumento t_TipoDocumento = await _context.T_TipoDocumentos.FindAsync(id);
            if (t_TipoDocumento == null)
            {
                return NotFound();
            }
            return View(t_TipoDocumento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, T_TipoDocumento t_TipoDocumento)
        {
            if (id != t_TipoDocumento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t_TipoDocumento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento.");
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
            return View(t_TipoDocumento);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            T_TipoDocumento DescripcionDocumento = await _context.T_TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (DescripcionDocumento == null)
            {
                return NotFound();
            }

            _context.T_TipoDocumentos.Remove(DescripcionDocumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
