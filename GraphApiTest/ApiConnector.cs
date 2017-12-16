using System.Collections.Generic;
using System.Linq;


namespace GraphApiTest
{
    public class ApiConnector
    {

        public ApiConnector()
        {
            
        }

        public IEnumerable<string> Connect()
        {
            var graphApiHelper = new GraphApiHelper();
            var authenticatedClient = graphApiHelper.GetAuthenticatedClient();
            var fileService = new FileService();

            var fileItems = fileService.GetMyFilesAndFolders(authenticatedClient);

            return fileItems.Result.Select(x => x.Id + " " + x.Display);
        }
        
        

    }
}
