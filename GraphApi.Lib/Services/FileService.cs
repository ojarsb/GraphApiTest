using System.Collections.Generic;
using System.Threading.Tasks;
using GraphApi.Core.Models;
using Microsoft.Graph;

namespace GraphApi.Core.Services
{
    public class FileService
    {
        // Get the drive items in the root directory of the current user's default drive.
        public async Task<List<ResultsItem>> GetMyFilesAndFolders(GraphServiceClient graphClient)
        {
            var items = new List<ResultsItem>();

            // Get the files and folders in the current user's drive.
            var driveItems = await graphClient.Me.Drive.Root.Children.Request().GetAsync();

            if (!(driveItems?.Count > 0)) return items;

            foreach (var fileOrFolder in driveItems)
            {
                // Get file and folder properties.
                var type = fileOrFolder.File?.ToString() ?? fileOrFolder.Folder?.ToString();
                items.Add(new ResultsItem
                {
                    Display = fileOrFolder.Name + " (" + type?.Replace("Microsoft.Graph.", "") + ")",
                    Id = fileOrFolder.Id
                });
            }

            return items;
        }
    }
}