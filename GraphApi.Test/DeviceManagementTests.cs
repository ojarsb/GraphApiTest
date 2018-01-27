using System;
using FluentAssertions;
using GraphApi.Core.Helpers;
using GraphApi.Core.Models;
using GraphApi.Core.Services;
using NUnit.Framework;

namespace GraphApi.Test
{
    [TestFixture]
    public class DeviceManagementTests
    {

        [Test]
        public void GetDeviceManagementScripts(DeviceManagementService service)
        {
            var response = service.Get();
            response.Result.Should().NotBeNull();
            response.Result.Id.Should().NotBeEmpty();

            Console.WriteLine(response.Result.Id);
        }

        [Test]
        public void CreateDeviceManagementScript(DeviceManagementService service)
        {
            var encoder = new EncodingHelpers();

            var deviceScript = new DeviceManagementScript
            {
                DisplayName = $"Test {Guid.NewGuid()}",
                Datatype = "#microsoft.graph.deviceManagementScript",
                Description = "Test script",
                ScriptContent = encoder.Base64Encode("echo test"),
                EnforceSignatureCheck = false,
                FileName = "test.ps1",
                RunAsAccount = "system"
            };

            var response = service.Create(deviceScript);
            response.Should().NotBeNull();
            response.Result.Should().NotBeNull();
            response.Result.Id.Should().NotBeEmpty();

            Console.WriteLine(response.Result.Id);
        }

        [Test]
        public void AssignDeviceManagementScriptToGroup()
        {
            DeviceManagementService service = TestServiceLocator.GetDeviceManagementService();

            var script = service.Get().Result;

            service.AssignToGroup(script.Id);

        }
    }
}