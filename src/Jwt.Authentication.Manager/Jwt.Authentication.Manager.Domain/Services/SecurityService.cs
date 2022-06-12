using Jwt.Authentication.Manager.Domain.Config;
using Jwt.Authentication.Manager.Domain.Entities;
using Jwt.Authentication.Manager.Domain.Interfaces.Services;
using Jwt.Authentication.Manager.Domain.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jwt.Authentication.Manager.Domain.Services
{
    public class SecurityService : ISecurityService
    {
        #region Properties
        private readonly AppSettings _settings;
        #endregion

        #region Constructor
        public SecurityService(IOptions<Settings> settings)
        {
            _settings = settings.Value.AppSettings;
        }
        #endregion

        #region Public Members
        public AuthResponse Authenticate(AuthRequest request)
        {
            try
            {
                AuthResponse authResponse = new AuthResponse();
                var encryptedPassword = Security.Encrypt(request.Password);
                if (encryptedPassword != request.EncryptedPassword)
                {
                    return null;
                }

                authResponse.UserName = request.UserName;
                authResponse.Token = GetToken(request);

                return authResponse;
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        public EncryptResponse Encrypt(EncryptRequest request)
        {
            try
            {
                EncryptResponse encryptResponse= new EncryptResponse();
                string encryptedPassword = Security.Encrypt(request.Password);
                encryptResponse.UserName = request.UserName;
                encryptResponse.EncryptedPassword = encryptedPassword;
                return encryptResponse;
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        #endregion

        #region Private Members
        private string GetToken(AuthRequest authRequest)
        {
            JwtSecurityTokenHandler tokenHanlder = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_settings.SecretKey);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, authRequest.UserName));
            if (authRequest.Claims != null)
                claims.Add(new Claim(type: "CustomClaims", value: authRequest.Claims.ToString()));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken securityToken = tokenHanlder.CreateToken(tokenDescriptor);
            string token = tokenHanlder.WriteToken(securityToken);
            return token;
        }
        #endregion
    }
}
