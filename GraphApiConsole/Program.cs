using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            //var service = new IntuneService(new ApiConnector(new IdentitiyHelper()), new SerializationHelper(new JsonSerializer()));
            //var result = Task.Run(() => service.GetApplications());
            //var result = Task.Run(() => service.GetJsonApplicationById("05adbf99-04c7-44b9-9e4e-4d8f4939aea6"));
            //var service = new DeviceManagementService(new ApiConnector(new IdentitiyHelper()), new SerializationHelper(new JsonSerializer()));
            var service = new GroupService(new ApiConnector(new IdentitiyHelper()), new SerializationHelper(new JsonSerializer()));
            var apps = service.GetGroups();

            Console.WriteLine(apps.Result);
        }
    }
}