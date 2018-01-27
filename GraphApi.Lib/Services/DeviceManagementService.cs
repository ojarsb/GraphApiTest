using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GraphApi.Core.Helpers;
using GraphApi.Core.Models;

namespace GraphApi.Core.Services
{
    public class DeviceManagementService
    {
        private const string BaseResource = "deviceManagement/deviceManagementScripts";
        
        private readonly ApiConnector _connector;
        private readonly SerializationHelper _serializationHelper;

        public DeviceManagementService(ApiConnector connector, SerializationHelper serializationHelper)
        {
            _connector = connector;
            _serializationHelper = serializationHelper;
        }

        public async Task<DeviceManagementScript> Create(DeviceManagementScript deviceScript)
        {
            var request = _serializationHelper.Serialize(deviceScript);
            var response = await _connector.SendPostRequest(BaseResource, request);
            return _serializationHelper.Deserialize<DeviceManagementScript>(response);
        }

        public async Task<DeviceManagementScript> Get()
        {
            var result = await _connector.SendGetRequest(BaseResource);
            var response = _serializationHelper.Deserialize<DeviceManagementScript>(result);
            return response;
        }

        public async void AssignToGroup(string groupId)
        {
            var request = "{ \"deviceManagementScriptGroupAssignments\": [" +
                    "{" + "\"@odata.type\": \"#microsoft.graph.deviceManagementScriptGroupAssignment\"," +
                    "\"id\": \"ecd2357d-357d-ecd2-7d35-d2ec7d35d2ec\"," +
                    "\"targetGroupId\": \"f15e5f65-64f7-411c-a919-a50824d365c6\"}]}";

            var resource = BaseResource + groupId + "/assign";

            var response = await _connector.SendPostRequest(resource, request);

        }
    }
}