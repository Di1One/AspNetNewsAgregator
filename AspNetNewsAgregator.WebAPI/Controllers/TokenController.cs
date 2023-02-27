﻿using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.WebAPI.Models.Requests;
using AspNetNewsAgregator.WebAPI.Models.Responces;
using AspNetNewsAgregator.WebAPI.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AspNetNewsAgregator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IJwtUtil _jwtUtil;

        public TokenController(IUserService userService, IMapper mapper, IJwtUtil jwtUtil)
        {
            _userService = userService;
            _mapper = mapper;
            _jwtUtil = jwtUtil;
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateJwtToken([FromBody] LoginUserRequestModel request)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(request.Email);

                if (user == null)
                {
                    return BadRequest();
                }

                var isPassCorrect = await _userService.CheckUserPassword(request.Email, request.Password);

                if (!isPassCorrect)
                {
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Passwor is incorrect"
                    });
                }

                var response = _jwtUtil.GenerateToken(user);

                return Ok(response);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500);
            }
        }
    }
}