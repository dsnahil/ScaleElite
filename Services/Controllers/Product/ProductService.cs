using Data.Models;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ProductService:IProductService
    {
        private readonly endel_weighbridgeContext _context;
        public ProductService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public int InsertProduct(Product product)
        {
            product.CreatedTime = DateTime.Now;
            product.IsActive = 1;
            product.ProductName = product.ProductName.Trim();
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.ProductId;
        }
        public int EditProduct(ProductVM productVM)
        {
            var prod = _context.Products.FirstOrDefault(p => p.ProductId == productVM.ProductId);
            if(prod == null)
                return 0;
            prod.ProductName = productVM.ProductName;
            prod.ProductCode = productVM.ProductCode;
            prod.Description = productVM.Description;
            prod.Notes = productVM.Notes;
            prod.IsActive = productVM.IsActive;
            prod.UpdateTime = productVM.UpdateTime;
            prod.UpdateBy = productVM.UpdateBy;

            _context.SaveChanges();
            return prod.ProductId;
        }
        public List<Product> GetProduct()
        {
            return _context.Products.ToList();
        }

        public List<Product> ProductSearch(string Productname)
        {
            if (!string.IsNullOrEmpty(Productname))
            {
                var product = _context.Products.Where(p => p.ProductName.Contains(Productname)).ToList();
                if (product.Count > 0)
                    return product;
                else 
                    return null;
            }
            return null;
        }
        public Product GetProduct_by_ProductId(int id)
        {
            if(id!=0)
            {
                var product = _context.Products.Where(p => p.ProductId == id).ToList();
                if (product.Count > 0)
                    return product.FirstOrDefault();
            }
                return null;
        }
        public Product ActivateProduct(int id)
        {
            var product = _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return null;
            }
            if (product.IsActive == 1)
            {
                product.IsActive = 0;
            }
            else
            {
                product.IsActive = 1;
            }
            _context.SaveChanges();
            return product;
        }
    }
}
