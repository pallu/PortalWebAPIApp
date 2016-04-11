using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalWebAPIApp.models
{
    public class TokenLoginRequest
    {
        [JsonProperty("grant_type")]
        public string GrantType {
            get
            {
                return "password";
            }
        }
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("client_id")]
        public string ClientID { get; set; }

        public TokenLoginRequest(string username, string password, string client_id)
        {
            this.Username = username;
            this.Password = password;
            this.ClientID = client_id;
        }
    }
    public class TokenRefreshRequest
    {
        [JsonProperty("grant_type")]
        public string GrantType
        {
            get
            {
                return "refresh_token";
            }
        }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("client_id")]
        public string ClientID { get; set; }
        public TokenRefreshRequest(string refresh_token, string client_id)
        {
            this.RefreshToken = refresh_token;
            this.ClientID = client_id;
        }
    }
    public class TokenResponseModel
    {
        /*
        "access_token": "jjklsj8f83ojaewjlajsdjsf",
	"token_type": "bearer",
	"expires_in": 1799,
	"refresh_token": "asldjflas3j24jsljaf",
	"as:client_id": "suppliedClientID",
	"userName": "suppliedUserName",
	"fullName": "John Doe",
	"personID": "12345",
	"role": "userRole",
	".issued": "Thu, 07 Apr 2016 17:47:13 GMT", 
	".expires": "Thu, 07 Apr 2016 18:02:13 GMT"
    */
        [JsonProperty("access_token")]
        public string AccessToken{ get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("as:client_id")]
        public string ClientID { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("personID")]
        public int PersonID { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty(".issued")]
        public DateTime? IssuedUTC { get; set; }

        [JsonProperty(".expires")]
        public DateTime? ExpiresUTC { get; set; }

    }
}
