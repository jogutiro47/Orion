using Orion.API.Data.Entities;
using Orion.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orion.API.Helpers
{
    public interface IConverterHelper

    {
        Task<T_Usuario> ToUserAsync(UserViewModel model, bool isNew);
        Task<T_Cita> ToCitaAsync(CitaViewModel model, bool isNew);

        UserViewModel ToUserViewModel(T_Usuario t_Usuario);


    }
}
