using PortalWebAPIApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalWebAPIApp.services
{
    //http://shribits.blogspot.com/2015/10/using-xamarinforms-store-value-in.html
    public interface ILoginStoreService
    {
        void SaveLogin(TokenResponseModel trm);
        string GetUserName();
        //string GetPassword();
        bool LoginExists();
        TokenResponseModel GetToken();
    }
}
