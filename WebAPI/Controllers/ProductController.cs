using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Services;
using Microsoft.AspNetCore.Authorization;
using Data.ViewModel;


namespace WebAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _iproductservice;
        public ProductController(IProductService iproductservice)
        {
            _iproductservice = iproductservice;
        }

        [HttpGet]
        public ActionResult GetProduct()
        {
            var product = _iproductservice.GetProduct();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("GetProductDetails")]
        public ActionResult ProductSearch(string Productname)
        {
            var product1= _iproductservice.ProductSearch(Productname);
                if (product1 != null)
                {
                    return Ok(product1);
                }
                else
                    return BadRequest();
        }

        [HttpPost]
        public ActionResult AddProduct(Product Product)
        {
            Product.CreatedBy = User.Identity.Name;
            var add = _iproductservice.InsertProduct(Product);
            
            return Ok($"Product successfully created with id : {Product.ProductId}");
        }
        [HttpGet]
        [Route("GetProductbyID")]
        public ActionResult GetProduct(int id)
        {
            var Product = _iproductservice.GetProduct_by_ProductId(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }
        [HttpPut]
        public ActionResult EditProduct(ProductVM ProductVM)
        {
            ProductVM.UpdateBy = User.Identity.Name;
            ProductVM.UpdateTime = DateTime.Now;
            var Product1 = _iproductservice.EditProduct(ProductVM);
            if (Product1 == 0)
                return BadRequest();
            return Ok("Product info updated successfully");
        }
        [HttpPatch("{id}/activate")]
        public ActionResult ActivateProduct(int id)
        {
            var product = _iproductservice.ActivateProduct(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok();
        }
    }
}
