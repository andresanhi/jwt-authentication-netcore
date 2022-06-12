using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Authentication.Manager.Domain.Entities
{
    public class EncryptRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
