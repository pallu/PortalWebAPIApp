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
            //var client = new RestSharp.Portable.HttpClient.RestClient(Constants.BaseAddress);
            //client.Authenticator = new RestSharp.Portable.Authenticators.HttpBasicAuthenticator(userName, password);

            //var request = new RestSharp.Portable.RestRequest("/token", RestSharp.Portable.Method.POST);
            //request.Parameters.Add(new RestSharp.Portable.Parameter() { Name = "grant_type", Value = "password" });
            //request.Parameters.Add(new RestSharp.Portable.Parameter() { Name = "Username", Value = userName });
            //request.Parameters.Add(new RestSharp.Portable.Parameter() { Name = "Password", Value = password });
            //request.Parameters.Add(new RestSharp.Portable.Parameter() { Name = "client_id", Value = Constants.ClientID });

            //var postResponse = await client.Execute<TokenResponseModel>(request).ConfigureAwait(false);
            //return postResponse.Data;


        }


        
    }
}
