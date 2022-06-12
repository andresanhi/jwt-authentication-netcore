using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Authentication.Manager.Domain.Entities
{
    public class AuthResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
