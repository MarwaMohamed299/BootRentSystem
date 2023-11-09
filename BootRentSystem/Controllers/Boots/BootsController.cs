using BootRent.BL.Dtos.Boots;
using BootRent.BL.General_Response;
using BootRent.BL.Managers.Boos;
using BootRent.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootRentSystem.Controllers.Boots
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootsController : ControllerBase
    {
        private readonly IBootManager _bootManager;

        public BootsController(IBootManager bootManager)
        {
            _bootManager = bootManager;
            
        }
        [HttpGet]

        public ActionResult<List<BootReadDto>> GetAll()
        {
            return _bootManager.GetAllBoots().ToList();
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<BootReadDto> GetBootById(Guid id)
        {
           BootReadDto? boot = _bootManager.GetBootById(id);
            if (boot is null)
            {
                return NotFound();
            }
            return boot;
        }

        [HttpPost]
        public ActionResult Add(BootAddDto bootDto)
        {
            var newId = _bootManager.Add(bootDto);

            return CreatedAtAction(nameof(GetBootById),
                new { id = newId },
                new GeneralResponse("Boot Has Been Added Successfully!"));

        }

        [HttpPut]
        public ActionResult Update(BootUpdateDto bootDto)

        {
            var isFound = _bootManager.Update(bootDto);
            if (!isFound)
            {
                return NotFound();
            }
            return Ok("Boot is Updated Successfully");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            var isFound = _bootManager.Delete(id);
            if (!isFound)
            {
                return NotFound();

            }
            return Ok("Product is Deleted Successfully");

        }
    }
}
