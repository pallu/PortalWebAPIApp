using Newtonsoft.Json;
using PortalWebAPIApp.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
namespace PortalWebAPIApp.services
{
    public class AccountsService
    {
        public async Task<TokenResponseModel> Login(string userName,string password)
        {
            Uri uri = new Uri(new Uri(Constants.BaseAddress), new Uri("/token", UriKind.Relative));
            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", userName),
                    new KeyValuePair<string, string>("Password", password),
                    new KeyValuePair<string, string>("client_id",Constants.ClientID),
                    new KeyValuePair<string, string>("grant_type","password")
                });

                var postResponse = await client.PostAsync(uri, formContent).ConfigureAwait(false);
                postResponse.EnsureSuccessStatusCode();

                string response = await postResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenResponseModel>(response);
            }
            

        }
        public async Task<TokenResponseModel> RefreshToken(string refreshToken)
        {
            Uri uri = new Uri(new Uri(Constants.BaseAddress), new Uri("/token", UriKind.Relative));
            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("grant_type","refresh_token"),
                    new KeyValuePair<string, string>("client_id",Constants.ClientID),
                    new KeyValuePair<string, string>("refresh_token",refreshToken)
                });
                var postResponse = await client.PostAsync(uri, formContent).ConfigureAwait(false);
                postResponse.EnsureSuccessStatusCode();

                string response = await postResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenResponseModel>(response);
            }
        }

        
    }
}
