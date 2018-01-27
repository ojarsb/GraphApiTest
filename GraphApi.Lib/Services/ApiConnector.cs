using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GraphApi.Core.Identity;

namespace GraphApi.Core.Services
{
    public class ApiConnector
    {
        private const string BaseGraphApiUri = "https://graph.microsoft.com/beta/";
        private readonly IdentitiyHelper _identitiyHelper;

        public ApiConnector(IdentitiyHelper identitiyHelper)
        {
            _identitiyHelper = identitiyHelper;
        }

        public async Task<string> SendGetRequest(string resource)
        {
            try
            {
                var client = new HttpClient();
                var token = await _identitiyHelper.GetToken();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var requestUri = $"{BaseGraphApiUri}{resource}";

                var response = await client.GetAsync(new Uri(requestUri));

                if (!response.IsSuccessStatusCode)
                    throw new Exception("We could not send the message. Status Code: " + response.StatusCode);
                
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                throw new Exception("We could not send the message: " + e.Message);
            }
        }


        public async Task<string> SendPostRequest(string resource, string requestBody)
        {

            try
            {
                var client = new HttpClient();
                var token = await _identitiyHelper.GetToken();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var requestUri = $"{BaseGraphApiUri}{resource}";

                //requestBody =
                //    "{\"@odata.type\":\"#microsoft.graph.windowsMobileMSI\",\"categories\":[],\"commandLine\":\"\",\"description\":\"asdfasdfasfd\",\"developer\":\"\",\"displayName\":\"Orca blablab\",\"fileName\":\"Orca.Msi\",\"identityVersion\":\"3.1.3790.0000\",\"informationUrl\":\"\",\"isFeatured\":false,\"notes\":\"\",\"owner\":\"\",\"privacyInformationUrl\":\"\",\"productCode\":\"{85F4CBCB-9BBC-4B50-A7D8-E1106771498D}\",\"publisher\":\"asdfasdfasdf\"}";
                 var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                
                var response = await client.PostAsync(new Uri(requestUri), content);

                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        $"We could not send the message. Status Code: {response.StatusCode} API Response: {responseContent}");
                }

                return responseContent;
            }
            catch (Exception e)
            {
                throw new Exception($"We could not send the message: {e.Message}");
            }
        }


        public async Task<string> SendDeleteRequest(string resource)
        {
            try
            {
                var client = new HttpClient();
                var token = await _identitiyHelper.GetToken();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var requestUri = $"{BaseGraphApiUri}{resource}";

                var response = await client.DeleteAsync(new Uri(requestUri));

                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        $"We could not send the message. Status Code: {response.StatusCode} API Response: {responseContent}");
                }

                return responseContent;
            }
            catch (Exception e)
            {
                throw new Exception($"We could not send the message: {e.Message}");
            }
        }


    }
}