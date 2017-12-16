using System;
using System.Threading.Tasks;
using GraphApi.Core.Helpers;
using GraphApi.Core.Models;

namespace GraphApi.Core.Services
{
    public class IntuneService
    {
        private const string BaseResource = "deviceAppManagement/mobileApps";

        private readonly ApiConnector _connector;
        private readonly SerializationHelper _serializationHelper;

        public IntuneService(ApiConnector connector, SerializationHelper serializationHelper)
        {
            _connector = connector;
            _serializationHelper = serializationHelper;
        }

        public async Task<string> GetJsonApplicationById(string appId)
        {
            return await _connector.SendGetRequest($"{BaseResource}/{appId}");
        }

        public async Task<IntuneApplicationList> GetApplications()

        {
            var result = await _connector.SendGetRequest(BaseResource);
            var appList = _serializationHelper.Deserialize<IntuneApplicationList>(result);
            return appList;
        }

        public async Task<IntuneApplication> GetApplicationById(string appId)
        {
            var result = await _connector.SendGetRequest($"{BaseResource}/{appId}");
            var application = _serializationHelper.Deserialize<IntuneApplication>(result);
            return application;
        }

        public async Task<IntuneApplication> CreateApplication(IntuneApplication application)
        {
            var request = _serializationHelper.Serialize(application);
            var response = await _connector.SendPostRequest(BaseResource, request);
            return _serializationHelper.Deserialize<IntuneApplication>(response);
        }

        public async Task<string> DeleteApplication(IntuneApplication application)
        {
            if (string.IsNullOrEmpty(application.Id))
                throw new ArgumentNullException(nameof(application.Id));

            return await _connector.SendDeleteRequest($"{BaseResource}/{application.Id}");

        }

        public async Task<string> CreateContent(string appId)
        {
            var postUrl =
                $"{BaseResource}/{appId}/microsoft.graph.windowsMobileMSI/contentVersions";

            var response = await _connector.SendPostRequest(postUrl,
                "{ \"@odata.type\": \"#microsoft.graph.mobileAppContent\" }");

            return response;
        }


        public async Task<string> CreateFile(string appId, string contentId, ContentFile contentfile)

        {
            //8c2109f4-31fd-4d86-9869-a141e3c77686/microsoft.graph.windowsMobileMSI/contentVersions/1/files 
            var postUrl = $"{BaseResource}/{appId}/microsoft.graph.windowsMobileMSI/contentVersions/1/files";
            var content = _serializationHelper.Serialize(contentfile);
            var response = await _connector.SendPostRequest(postUrl, content);

            return response;
        }

    }
}