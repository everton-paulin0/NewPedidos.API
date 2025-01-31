using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Services.Interfaces
{
    public interface IProductServices
    {
        ResultViewModel<List<ProductItemViewModel>> GetAll(string search = "");
        ResultViewModel<ProductViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateProductInputModel model);
        ResultViewModel Update(UpdateProductInputModel model);
        ResultViewModel Delete(int id);
    }
}
