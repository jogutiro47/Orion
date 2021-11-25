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
    public class T_CitaController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public T_CitaController(DataContext context, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.t_Citas
            .Include(x => x.Id_Medico)
             .ToListAsync());


        }

        public IActionResult Create()
        {
            CitaViewModel model = new CitaViewModel
            {
                DescripcionMedico = _combosHelper.GetComboMedicoTypes()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    T_Cita t_Cita = await _converterHelper.ToCitaAsync(model, true);

                    _context.Add(t_Cita);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));


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


                return RedirectToAction(nameof(Index));
            }
            model.DescripcionMedico = _combosHelper.GetComboMedicoTypes();
       
            return View(model);
        }




    }
}
