using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService _cameraService;
        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }
        [HttpGet]
        public IActionResult GetAllCamera()
        {
            var camera = _cameraService.GetAllCamera();
            if (camera == null)
            {
                return NotFound();
            }
            else
                return Ok(camera);
        }
        [HttpGet("{id}")]
        public IActionResult GetCameraById(int id)
        {
            var camera = _cameraService.GetCameraById(id);
            if (camera == null)
            {
                return NotFound();
            }
            else
                return Ok(camera);
        }
        [HttpPost]
        public IActionResult AddCamera([FromBody] Camera camera)
        {
            if (camera == null)
            {
                return BadRequest("Camera fields are required");
            }
            else
            {
                camera.CreatedBy = User.Identity.Name;
                var cam = _cameraService.AddCamera(camera);
                if (cam == null)
                {
                    return BadRequest();
                }
                else
                    return Ok(cam);
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCamera(int id)
        {
            var camera = _cameraService.DeleteCamera(id);
            if (camera == null)
            {
                return NotFound();
            }
            else
                return Ok(camera);
        }
        [HttpPut]
        public IActionResult UpdateCamera([FromBody] CameraVM camera)
        {
            var cam = _cameraService.UpdateCamera(camera);
            if (cam == null)
            {
                return BadRequest();
            }
            else
                return Ok(cam);
        }
        [HttpPatch]
        public IActionResult ActivateCamera(int id)
        {
            if(id == 0)
                return BadRequest("Camera Id is required");
            else
            {
                var cam = _cameraService.ActivateCamera(id);
                if (cam != null)
                {
                    return Ok(cam);
                }
                else
                    return BadRequest("Camera Not Found");
            }
        }
    }
}
