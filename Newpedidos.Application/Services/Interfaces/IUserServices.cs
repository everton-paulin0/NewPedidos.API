﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Services.Interfaces
{
    public interface IUserServices
    {
        ResultViewModel<List<UserItemViewModel>> GetAll(string search = "");
        ResultViewModel<UserViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateUserInputModel model);
        ResultViewModel Update(UpdateUserInputModel model);
        ResultViewModel Delete(int id);
    }
}
