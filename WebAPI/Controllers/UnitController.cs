using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Services;
using Microsoft.AspNetCore.Authorization;
using Data.ViewModel;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private IUnitService _iuniteservice;
        public UnitController(IUnitService iuniteservice)
        {
            _iuniteservice = iuniteservice;
        }

        [HttpGet]
        public ActionResult GetUnit()
        {
            var unit=_iuniteservice.GetUnit();
            if(unit==null)
            {
                return NotFound();
            }   
            return Ok(unit);
        }

        [HttpGet("UnitName")]
        public ActionResult GetUnit(string name)
        {
            if(!string.IsNullOrEmpty(name))
            {
                List<Unit> unitname=_iuniteservice.SearchUnit(name);
                if(name!=null)
                {
                    return Ok(unitname);
                }
                return BadRequest();
            }
            else
                return BadRequest();
        }
        [HttpPost]
        public ActionResult AddUnit(Unit unit)
        {
            if(unit==null)
                return BadRequest("Enter Unit");
            else
            {
                unit.CreatedBy = User.Identity.Name;
                var add = _iuniteservice.InsertUnit(unit);
                return Ok($"Unit added successfully with id:{add}");
            }
        }

        [HttpPut]
        public IActionResult UpdateAllInformationById(UnitVM unitVM)
        {
            if(unitVM == null) return NotFound();
            unitVM.UpdateBy = User.Identity.Name;
            var unit1 = _iuniteservice.EditUnit(unitVM);
            if (unit1 == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpGet]
        [Route("GetUnitbyID")]
        public ActionResult GetUnit(int id)
        {
            var unit = _iuniteservice.GetUnit_by_UnitId(id);
            if (unit == null)
            {
                return NotFound();
            }
            return Ok(unit);
        }
    }
}
