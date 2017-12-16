using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GraphApiTest;
using Microsoft.Graph;

namespace GraphApiConsole
{
    public class IntuneService
    {
        private readonly IdentitiyHelper _identitiyHelper;
        public IntuneService()
        {
            _identitiyHelper = new IdentitiyHelper();
        }

        //public IEnumerable<ResultsItem> GetApplications(GraphServiceClient graphClient)
        //{
        //    List<ResultsItem> items = new List<ResultsItem>();

        //}


        public async Task<string> GetApplicationsById()
        {

        }


        public async Task<string> GetApplications()
        {
            var graphApiLink = "https://graph.microsoft.com/beta/deviceAppManagement/mobileApps";
            
            try
            {
                HttpClient client = new HttpClient();
                var token = await _identitiyHelper.GetToken();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                // Build contents of post body and convert to StringContent object.
                // Using line breaks for readability.
                //string postBody = "{'Message':{"
                //                  + "'Body':{ "
                //                  + "'Content': '" + bodyContentWithSharingLink + "',"
                //                  + "'ContentType':'HTML'},"
                //                  + "'Subject':'" + subject + "',"
                //                  + "'ToRecipients':[" + recipientsJSON + "],"
                //                  + "'Attachments':[" + attachments + "]},"
                //                  + "'SaveToSentItems':true}";

                //var emailBody = new StringContent(postBody, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.GetAsync(new Uri(graphApiLink));

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("We could not send the message: " + response.StatusCode);
                }


                return await response.Content.ReadAsStringAsync();
            }

            catch (Exception e)
            {
                throw new Exception("We could not send the message: " + e.Message);
            }
        }



    }
}
