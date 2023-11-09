using BootRent.BL.Dtos.Reservations;
using BootRent.BL.General_Response;
using BootRent.BL.Managers.Reservations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootRentSystem.Controllers.Reservation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;

        public ReservationsController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }
        [HttpGet]
        [Authorize]

        public ActionResult<List<ReservationReadDto>> GetAll()
        {
            return _reservationManager.GetAllReservations().ToList();
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReservationReadDto> GetReservationById(Guid id)
        {
            ReservationReadDto? reservation = _reservationManager.GetReservationById(id);
            if (reservation is null)
            {
                return NotFound();
            }
            return reservation;
        }

        [HttpPost]
        public ActionResult Add(ReservationAddDto reservationDto)
        {
            var newId = _reservationManager.Add(reservationDto);

            return CreatedAtAction(nameof(GetReservationById),
                new { id = newId },
                new GeneralResponse("Reservation Has Been Added Successfully!"));

        }

        [HttpPut]
        public ActionResult Update(ReservationUpdateDto reservationDto)

        {
            var isFound = _reservationManager.Update(reservationDto);
            if (!isFound)
            {
                return NotFound();
            }
            return Ok("Reservation is Updated Successfully");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            var isFound = _reservationManager.Delete(id);
            if (!isFound)
            {
                return NotFound();

            }
            return Ok("Product is Deleted Successfully");

        }
    }
}
