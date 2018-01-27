using GraphApi.Core.Helpers;
using GraphApi.Core.Identity;
using GraphApi.Core.Services;
using Newtonsoft.Json;

namespace GraphApi.Test
{
    public static class TestServiceLocator
    {
        public static GroupService GetGroupService()
        {
            return new GroupService(new ApiConnector(new IdentitiyHelper()),
                new SerializationHelper(new JsonSerializer()));
        }

        public static IntuneService GetIntuneService()
        {
            return new IntuneService(new ApiConnector(new IdentitiyHelper()),
                new SerializationHelper(new JsonSerializer()));
        }

        public static DeviceManagementService GetDeviceManagementService()
        {
            return new DeviceManagementService(new ApiConnector(new IdentitiyHelper()),
                new SerializationHelper(new JsonSerializer()));
        }
    }
}