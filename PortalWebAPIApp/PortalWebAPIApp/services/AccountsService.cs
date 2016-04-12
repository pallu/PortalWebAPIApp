using Newtonsoft.Json;
using PortalWebAPIApp.helpers;
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
using Xamarin.Forms;

namespace PortalWebAPIApp.services
{
    public class AccountsService
    {
        public async Task<TokenResponseModel> Login(string userName,string password)
        {
            if(!DependencyService.Get<IReachability>().IsConnectedToNetwork())
            {
                throw new WebException("Network not connected");
            }

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

                try
                {
                    var postResponse = await client.PostAsync(uri, formContent).ConfigureAwait(false);
                    //postResponse.EnsureSuccessStatusCode();
                    if (postResponse.IsSuccessStatusCode)
                    {
                        string response = await postResponse.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TokenResponseModel>(response);
                    }
                    else
                    {
                        throw new WebException(postResponse.ReasonPhrase);

                    }
                }
                catch (Exception ex)
                {

                    throw(ex);
                }
                
            }
            

        }
        public async Task<TokenResponseModel> RefreshToken(string refreshToken)
        {
            if (!DependencyService.Get<IReachability>().IsConnectedToNetwork())
            {
                throw new WebException("Network not connected");
            }
            Uri uri = new Uri(new Uri(Constants.BaseAddress), new Uri("/token", UriKind.Relative));
            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("grant_type","refresh_token"),
                    new KeyValuePair<string, string>("client_id",Constants.ClientID),
                    new KeyValuePair<string, string>("refresh_token",refreshToken)
                });
                try
                {
                    var postResponse = await client.PostAsync(uri, formContent).ConfigureAwait(false);
                    // postResponse.EnsureSuccessStatusCode();

                    if (postResponse.IsSuccessStatusCode)
                    {
                        string response = await postResponse.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TokenResponseModel>(response);
                    }
                    else
                    {
                        throw new WebException(postResponse.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {

                    throw(ex);
                }
                
            }
        }

        
    }
}
