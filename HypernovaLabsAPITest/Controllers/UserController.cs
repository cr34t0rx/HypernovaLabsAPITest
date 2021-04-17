using HypernovaLabsAPITest.Repository;
using HypernovaLabsAPITest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private ICarRentalRepository _carRentalRepository;

        public UserController(IConfiguration config, ICarRentalRepository carRentalRepository)
        {
            _config = config;
            _carRentalRepository = carRentalRepository;
        }

        [HttpPost("api/Register")]
        [ProducesResponseType(typeof(string), 200)]
        [SwaggerOperation("Registro de usuario", "Registra un usuario y devuelve un token JWT")]
        public async Task<IActionResult> Register([FromBody] UserViewModel user)
        {
            if (user != null)
            {
                var u = await _carRentalRepository.RegisterUser(user);
                if (u != -1)
                    return Ok(GenerateJWT(u));
                else
                    return new StatusCodeResult(406);
            }
            else
                return BadRequest();
        }

        [HttpPost("api/Login")]
        [ProducesResponseType(typeof(string), 200)]
        [SwaggerOperation("Login de usuario", "Valida email/pass y devuelve un token JWT")]
        public IActionResult Login([FromBody] UserViewModel user)
        {
            if (user != null)
            {
                var u = _carRentalRepository.Login(user);
                if (u != null)
                    return Ok(GenerateJWT(u.UserID));
                else
                    return new StatusCodeResult(406);
            }
            else
                return BadRequest();
        }

        [Authorize]
        [HttpGet("api/GetUserBookings")]
        [ProducesResponseType(typeof(List<UserBookingsViewModel>), 200)]
        [SwaggerOperation("Historial de vehiculos alquilados", "Devuelve una lista de los alquileres de vehiculos realizados por el usuario (requiere token JWT)")]
        public IActionResult GetUserBookings()
        {
            if (HttpContext.User.HasClaim(x => x.Type == "UserID"))
            {
                var userID = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserID").Value;
                if (!string.IsNullOrWhiteSpace(userID))
                {
                    return Ok(_carRentalRepository.UserBookings(int.Parse(userID)));
                }
                else
                    return new StatusCodeResult(406);
            }
            else
                return Unauthorized();
        }

        [Authorize]
        [HttpGet("api/GetUserInfo")]
        [ProducesResponseType(typeof(UserViewModel), 200)]
        [SwaggerOperation("Informacion del usuario", "Devuelve la informacion relacionada con el usuario (requiere token JWT)")]
        public IActionResult GetUserInfo()
        {
            if (HttpContext.User.HasClaim(x => x.Type == "UserID"))
            {
                var userID = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserID").Value;
                if (!string.IsNullOrWhiteSpace(userID))
                {
                    return Ok(_carRentalRepository.UserInfo(int.Parse(userID)));
                }
                else
                    return new StatusCodeResult(406);
            }
            else
                return Unauthorized();
        }

        [NonAction]
        private string GenerateJWT(int userID)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] { new Claim("UserID", userID.ToString()) };

            var token = new JwtSecurityToken("test.com", "test.com",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}