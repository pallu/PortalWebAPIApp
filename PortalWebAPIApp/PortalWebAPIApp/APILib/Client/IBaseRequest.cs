﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalWebAPIApp.APILib.Client
{
    public interface IBaseRequest
    {
        /// <summary>
        /// Refreshes the security token.
        /// </summary>
        /// <param name="securityToken"></param>
        void RefreshToken(string securityToken);
    }
}
