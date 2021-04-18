using HypernovaLabsAPITest.Models;
using HypernovaLabsAPITest.Repository;
using HypernovaLabsAPITest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Controllers
{
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private ICarRentalRepository _carRentalRepository;
        public CarRentalController(ICarRentalRepository carRentalRepository) => _carRentalRepository = carRentalRepository;

        [HttpGet("api/GetAvailableInventory")]
        [ProducesResponseType(typeof(List<InventoryViewModel>), 200)]
        [SwaggerOperation("Listado de vehiculos disponibles", "Devuelve una lista de vehiculos disponibles para alquilar, hace un calculo sencillo entre el total de vehiculos en el inventarios menos los vehiculos presentes en la tabla de alquiler para filtrar la informacion")]
        public IActionResult GetAvailableInventory()
        {
            return Ok(_carRentalRepository.GetAvailableInventory());
        }

        [HttpPost("api/CreateBooking")]
        [ProducesResponseType(typeof(string), 200)]
        [SwaggerOperation("Rentar vehiculo", "Agrega un registro de renta de vehiculo, si el usuario esta autenticado con token JWT se utlizan los datos registrados en la base de datos, "
            + "en caso contrario, se debera enviar el nombre, apellido y email de la persona que desea rentar el vehiculo")]
        public IActionResult CreateBooking([FromBody] CreateBookingViewModel data)
        {
            var userID = -1;
            if (HttpContext.User != null && HttpContext.User.HasClaim(x => x.Type == "UserID"))
                userID = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserID").Value);
            data.UserID = userID;

            if (userID == -1 && (string.IsNullOrWhiteSpace(data.FirstName) || string.IsNullOrWhiteSpace(data.LastName) || string.IsNullOrWhiteSpace(data.Email)))
                return NotFound("Debe ingresar su nombre, apellido y correo electronico");

            if (data.BookingDateFrom.Date > data.BookingDateTo.Date)
                return NotFound("La fecha final no debe ser inferior a la fecha de inicio");

            if (data.BookingDateFrom.Date < DateTime.Now.Date || data.BookingDateTo.Date < DateTime.Now.Date)
                return NotFound("Fechas invalidas");

            if (data.BookingDateFrom.Date == data.BookingDateTo.Date)
                return NotFound("Fechas invalidas");

            if (data.BookingDateFrom == DateTime.MinValue || data.BookingDateTo == DateTime.MinValue || data.ModelID <= 0)
                return NotFound("Debe ingresar todos los datos");

            _carRentalRepository.CreateBooking(data);

            return Ok();
        }
    }
}