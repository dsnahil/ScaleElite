using Data.Models;
using Data.ViewModel;

namespace Services
{ 
    public interface IProductService
    {
        List<Product> GetProduct();
        int InsertProduct(Product Product);
        int EditProduct(ProductVM ProductVM);
        Product GetProduct_by_ProductId(int id);
        List<Product> ProductSearch(string Productname);
        Product ActivateProduct(int ProductId);

    }
}
