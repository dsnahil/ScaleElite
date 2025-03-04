using Data.ViewModel;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly IBarcodeService _ibarcodeService;
        public BarcodeController(IBarcodeService ibarcodeService)
        {
            _ibarcodeService = ibarcodeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var barcode = _ibarcodeService.GenerateBarcode();
            if (barcode == null)
                return NotFound();
            else
                return Ok(barcode);
        }
        [HttpPut]
        public IActionResult UpdateBarcode(List<BarcodesettingVM> appsetting)
        {
            string name = User.Identity.Name;
            var barcode = _ibarcodeService.UpdateBarcode(appsetting, name);
            if (barcode == null)
                return NotFound();
            else
                return Ok(barcode);
        }


    }
}
