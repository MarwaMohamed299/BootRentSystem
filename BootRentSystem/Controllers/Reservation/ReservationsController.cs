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
        public ActionResult<List<ReservationReadDto>> GetAll()
        {
            var reservations = _reservationManager.GetAllReservations().ToList();
            return Ok(reservations);
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReservationReadDto> GetReservationById(Guid id)
        {
            var reservation = _reservationManager.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ReservationAddDto reservationDto)
        {
            var newId = _reservationManager.Add(reservationDto);
            return CreatedAtAction(nameof(GetReservationById), new { id = newId }, new GeneralResponse("Reservation has been added successfully!"));
        }

        [HttpPut]
        public ActionResult Update([FromBody] ReservationUpdateDto reservationDto)
        {
            var isUpdated = _reservationManager.Update(reservationDto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok("Reservation is updated successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var isDeleted = _reservationManager.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok("Reservation is deleted successfully");
        }
    }

}
