using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphApi.Core.Helpers;
using GraphApi.Core.Identity;
using GraphApi.Core.Models;
using GraphApi.Core.Services;
using Newtonsoft.Json;

namespace GraphApiConsole
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var service = new IntuneService(new ApiConnector(new IdentitiyHelper()), new SerializationHelper(new JsonSerializer()));
            //var result = Task.Run(() => service.GetApplications());
            //var result = Task.Run(() => service.GetJsonApplicationById("05adbf99-04c7-44b9-9e4e-4d8f4939aea6"));

            var app = new IntuneApplication
            {
                //DataContext = "https://graph.microsoft.com/beta/$metadata#deviceAppManagement/mobileApps/$entity",
                //Id = "05adbse9-04c7-44b9-9e4e-4d8f4939aea6",
                Categories = new string[0],
                Datatype = "#microsoft.graph.windowsMobileMSI",
                DisplayName = "Test 3434",
                CommandLine = "install cmd",
                Description = "descripti dfdfsdfon 33434",
                Publisher = "publisher test test",
                IsFeatured = false,
                FileName = "orca.msi",
                ProductCode = "{566AD852-AD56-42AF-8854-12C11AC85586}",
                //CreatedDateTime = DateTime.UtcNow,
                //UploadState = 11,
                PrivacyInformationUrl = "",
                InformationUrl = "",
                Owner = "",
                Notes = "",
                Developer = "",
                IdentityVersion = "asdfasdf"
                //Size = 3
            };

            //var resultApp = service.CreateApplication(app).Result;
            //var result = service.CreateContent("b01337b2-a62e-470c-be16-f80c6b13cb1f").Result;


            //"{" +
            //    "\"name\":\"Orca.Msi\"," +
            //    "\"size\":1910272,"
            //    "sizeEncrypted":1910336,
            //    "manifest":"PE1vYmlsZU1zaURhdGEgTXNpRXhlY3V0aW9uQ29udGV4dD0iU3lzdGVtIiBNc2lSZXF1aXJlc1JlYm9vdD0iZmFsc2UiIE1zaVVwZ3JhZGVDb2RlPSJ7MUFBMDNFMTAtMkIxOS0xMUQyLUIyRUEtMDA2MDk3Qzk5ODYwfSIgTXNpSXNNYWNoaW5lSW5zdGFsbD0idHJ1ZSIgTXNpSXNVc2VySW5zdGFsbD0iZmFsc2UiIE1zaUluY2x1ZGVzU2VydmljZXM9ImZhbHNlIiBNc2lDb250YWluc1N5c3RlbVJlZ2lzdHJ5S2V5cz0iZmFsc2UiIE1zaUNvbnRhaW5zU3lzdGVtRm9sZGVycz0iZmFsc2UiPjwvTW9iaWxlTXNpRGF0YT4=",
            //    "@odata.type":"#microsoft.graph.mobileAppContentFile"
            //}

            var filePath = "C:\\TestPackages\\Orca\\Orca.Msi";

            var file = System.IO.File.ReadAllBytes(filePath);

            var fileContent = Convert.ToBase64String(file);

            //Console.WriteLine(fileContent);

            var contentFile = new ContentFile()
            {
                DataType = "#microsoft.graph.mobileAppContentFile",
                Manifest = fileContent,
                Name = "Orca.msi",
                Size = file.Length,
                SizeEncrypted = file.Length
            };
            var contentId = "8c2109f4-31fd-4d86-9869-a141e3c77686";
            var appId = "b01337b2-a62e-470c-be16-f80c6b13cb1f";
            var result = service.CreateFile(appId, contentId, contentFile).Result;

            Console.WriteLine(result);



            //Console.WriteLine(resultApp.Id);

            //System.Threading.Thread.Sleep(5000);

            //var result = service.DeleteApplication(resultApp).Result;

            //Console.WriteLine(result);

            //var app = result.Result;

            //var intuneApplications = app.List as IEnumerable<IntuneApplication>;
            //if (intuneApplications != null)
            //    foreach (var intuneApplication in intuneApplications)
            //    {
            //        Console.WriteLine(intuneApplication.DisplayName);
            //    }

            //Console.WriteLine(app.DisplayName);



            //var apiConnect = new ApiConnector();

            //var list = apiConnect.Connect();

            //foreach (var file in list)
            //{
            //    Console.WriteLine(file);
            //}
        }
    }
}