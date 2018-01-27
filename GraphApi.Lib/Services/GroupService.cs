using System.Threading.Tasks;
using GraphApi.Core.Helpers;
using GraphApi.Core.Models;

namespace GraphApi.Core.Services
{
    public class GroupService
    {
        private const string BaseResource = "groups";

        private readonly ApiConnector _connector;
        private readonly SerializationHelper _serializationHelper;

        public GroupService(ApiConnector connector, SerializationHelper serializationHelper)
        {
            _connector = connector;
            _serializationHelper = serializationHelper;
        }

        public async Task<GroupList> GetGroups()
        {
            var response = await _connector.SendGetRequest(BaseResource);
            return _serializationHelper.Deserialize<GroupList>(response);
        }
    }
}