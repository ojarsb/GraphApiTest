using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace GraphApiTest
{
    public class FileService
    {
        // Get the drive items in the root directory of the current user's default drive.
        public async Task<List<ResultsItem>> GetMyFilesAndFolders(GraphServiceClient graphClient)
        {
            List<ResultsItem> items = new List<ResultsItem>();

            // Get the files and folders in the current user's drive.
            IDriveItemChildrenCollectionPage driveItems = await graphClient.Me.Drive.Root.Children.Request().GetAsync();

            if (driveItems?.Count > 0)
            {
                foreach (DriveItem fileOrFolder in driveItems)
                {

                    // Get file and folder properties.
                    string type = fileOrFolder.File?.ToString() ?? fileOrFolder.Folder?.ToString();
                    items.Add(new ResultsItem
                    {
                        Display = fileOrFolder.Name + " (" + type?.Replace("Microsoft.Graph.", "") + ")",
                        Id = fileOrFolder.Id
                    });
                }
            }
            return items;
        }
    }
}
