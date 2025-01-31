using Newpedidos.Application.Model;
using Newpedidos.Application.Services.Interfaces;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly AppDbContext _context;
        public ProductServices(AppDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var product = _context.Product.SingleOrDefault(p => p.Id == id);

            if (product is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            product.SetAsDeleted();

            _context.Product.Update(product);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<ProductItemViewModel>> GetAll(string search = "")
        {
            var products = _context.Product
            .Where(o => !o.IsDeleted && (search == "" || o.ProductName.Contains(search))).ToList();

            var model = products.Select(ProductItemViewModel.FromEntityProduct).ToList();

            return ResultViewModel<List<ProductItemViewModel>>.Sucess(model);
        }

        public ResultViewModel<ProductViewModel> GetById(int id)
        {
            var product = _context.Product.SingleOrDefault(p => p.Id == id);

            if (product is null)
            {
                return ResultViewModel<ProductViewModel>.Error("Produto não existe");
            }

            var model = ProductViewModel.FromEntityProduct(product);

            return ResultViewModel<ProductViewModel>.Sucess(model); ;
        }

        public ResultViewModel<int> Insert(CreateProductInputModel model)
        {
            var product = model.ToEntityProduct();

            _context.Product.Add(product);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(product.Id);
        }

        public ResultViewModel Update(UpdateProductInputModel model)
        {
            var product =_context.Product.SingleOrDefault(p => p.Id == model.IdProduct);

            if (product is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }
            product.UpdateProduct(model.ProductName, model.Quantity, model.Price, model.IdProduct);
            _context.Product.Update(product);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
