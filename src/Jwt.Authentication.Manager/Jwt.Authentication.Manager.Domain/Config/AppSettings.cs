using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Authentication.Manager.Domain.Config
{

    public class Settings
    {
        public AppSettings AppSettings { get; set; }
    }
    public class AppSettings
    {
        public string SecretKey { get; set; }
    }
}
