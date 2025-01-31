using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Services.Interfaces
{
    public interface IOrderServices
    {
        ResultViewModel<List<OrderItemViemModel>> GetAll(string search = "");
        ResultViewModel<OrderViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateOrderInputModel model);
        ResultViewModel Update(UpdateOrderInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel Complete(int id);
        ResultViewModel Cancel(int id);
        ResultViewModel SetPaymentPending(int id);
    }
}
