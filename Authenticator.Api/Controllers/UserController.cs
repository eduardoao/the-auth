using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authenticator.Api.Dto;
using Authenticator.Core.Interface;
using Authenticator.Core.Models;
using Authenticator.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserAuthenticatorDto user)
        {
            var existingUser = _userService.Authenticate(user.Username, user.Password);
            if (existingUser == null)
            {
                return BadRequest(new { message = "Usuário e ou senha incorretos!" });
            }
            return Ok(existingUser);
        }

        [AllowAnonymous]
        [HttpPost("createuser", Name = "CreateUser")]
        [ProducesResponseType(201, Type = typeof(UserCreateDto))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] UserCreateDto user)
        {
            if (user == null) return BadRequest("The user is null");

            var useradded = _userService.CreateUser(user.Username, user.Password, user.Email);

            return Created("video", useradded);
        }

    }
}
