using System.Data.Entity;
using Newpedidos.Application.Model;
using Newpedidos.Application.Services.Interfaces;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly AppDbContext _context;
        public OrderServices(AppDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Cancel(int id)
        {
            var order = _context.Order.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }
            order.Cancel();

            _context.Order.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Complete(int id)
        {
            var order = _context.Order.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.Complete();

            _context.Order.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var order = _context.Order.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.SetAsDeleted();
            _context.Order.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<OrderItemViemModel>> GetAll(string search = "")
        {
            var orders = _context.Order
                .Include(p => p.ClientName)
                .Where(o => !o.IsDeleted && (search == "" || o.ClientName.Contains(search)))
                .ToList();

            var model = orders.Select(OrderItemViemModel.FromEntityOrder).ToList();


            return ResultViewModel<List<OrderItemViemModel>>.Sucess(model);
        }

        public ResultViewModel<OrderViewModel> GetById(int id)
        {
            var order = _context.Order.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            var model = OrderViewModel.FromEntityOrder(order);

            return ResultViewModel<OrderViewModel>.Sucess(model);
        }

        public ResultViewModel<int> Insert(CreateOrderInputModel model)
        {
            var order = model.ToEntityOrder();

            _context.Order.Add(order);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(order.Id);
        }

        public ResultViewModel SetPaymentPending(int id)
        {
            var order = _context.Order.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }
            order.SetPaymentPending();

            _context.Order.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Update(UpdateOrderInputModel model)
        {
            var order = _context.Order.SingleOrDefault(p => p.Id == model.IdOrder);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.Update(model.ClientDoc, model.ClientName);

            _context.Order.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
