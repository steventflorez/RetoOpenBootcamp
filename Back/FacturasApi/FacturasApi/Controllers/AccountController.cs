using FacturasApi.Context;
using FacturasApi.Helpers;
using FacturasApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using FacturasApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FacturasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly FacturasApiDBContext _context;
        private readonly JwtSettings _jwtSettings;


        public AccountController(FacturasApiDBContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;

        }


      




        [HttpPost]
        public    IActionResult GetToken(LoginUserCreacionDTO loginUserCreacionDTO)
        {
            

            try
            {
                var token = new UserTokens();






                var searchUser = (from user in _context.Usuarios
                                 where user.Name == loginUserCreacionDTO.Name && user.Password == loginUserCreacionDTO.password
                                 select user).FirstOrDefault();


                if (searchUser != null)
                {
                    

                    token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.UserName,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Worng Password");
                }
                return Ok(token);
            }
            catch (Exception exception)
            {
                throw new Exception("GetToken Error", exception);

            }

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok();
        }

    }
}
