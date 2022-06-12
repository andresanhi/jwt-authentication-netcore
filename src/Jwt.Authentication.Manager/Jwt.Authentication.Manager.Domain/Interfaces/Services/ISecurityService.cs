using Jwt.Authentication.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Authentication.Manager.Domain.Interfaces.Services
{
    public interface ISecurityService
    {
        EncryptResponse Encrypt (EncryptRequest request);
        AuthResponse Authenticate (AuthRequest request);
    }
}
