using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Authentication.Manager.Domain.Entities
{
    public class AuthRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EncryptedPassword { get; set; }
        public object Claims { get; set; }
    }
}
