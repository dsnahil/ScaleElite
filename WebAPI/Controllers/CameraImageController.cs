using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CameraImageController : ControllerBase
    {
        private readonly ICameraImageService _cameraImageService;
        public CameraImageController(ICameraImageService cameraImageService)
        {
            _cameraImageService = cameraImageService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var image = _cameraImageService.GetAllCamera();
            if (image == null)
            {
                return NotFound();
            }
            else
                return Ok(image);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var image = _cameraImageService.GetCameraById(id);
            if (image == null)
            {
                return NotFound();
            }
            else
                return Ok(image);
        }
        [HttpPost]
        public IActionResult AddCameraImage([FromBody] Cameraimage camera) 
        {
            if(camera == null)
            {
                return BadRequest("CameraImage fields are required");
            }
            try
            {
                var cam = _cameraImageService.AddCamera(camera);
                if (cam == null)
                {
                    return BadRequest();
                }
                else
                    return Ok(cam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var image = _cameraImageService.DeleteCamera(id);
            if (image == null)
            {
                return NotFound();
            }
            else
                return Ok(image);
        }
       /* [HttpPut]
        public IActionResult Put([FromBody] Cameraimage camera)
        {
            camera.CreatedBy = User.Identity.Name;
            var cam = _cameraService.UpdateCamera(camera);
            if (cam == null)
            {
                return BadRequest();
            }
            else
                return Ok(cam);
        }*/

    }
}
