using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalWebAPIApp
{
    public class LoginEventArgs: EventArgs
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
