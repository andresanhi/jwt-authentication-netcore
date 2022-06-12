using AutoMapper;
using Jwt.Authentication.Manager.Api.Dtos;
using Jwt.Authentication.Manager.Domain.Entities;
using Jwt.Authentication.Manager.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Jwt.Authentication.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class SecurityController : ControllerBase
    {
        #region Properties
        private readonly ISecurityService _authenticationService;
        private readonly IMapper _mapper;
        #endregion
        public SecurityController(ISecurityService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Method to encrypt a password
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] EncryptRequestDto encryptDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                EncryptRequest encryptRequest = _mapper.Map<EncryptRequest>(encryptDto);
                EncryptResponse result = _authenticationService.Encrypt(encryptRequest);
                EncryptResponseDto encryptResponse = _mapper.Map<EncryptResponseDto>(result);
                return Ok(encryptResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Method to generate token
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthRequestDto authRequestDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                AuthRequest authRequest = _mapper.Map<AuthRequest>(authRequestDto);
                AuthResponse result = _authenticationService.Authenticate(authRequest);

                if (result != null)
                {
                    AuthResponseDto authResponseDto = _mapper.Map<AuthResponseDto>(result);
                    return Ok(authResponseDto);
                } else
                {
                    return StatusCode(StatusCodes.Status409Conflict, "User or password are incorrect");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
