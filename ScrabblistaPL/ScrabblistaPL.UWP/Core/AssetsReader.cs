using System.Collections.Generic;
using ScrabblistaPL.Domain.Core;
using ScrabblistaPL.UWP.Core;
using System.IO;
using Windows.Storage;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(AssetsReader))]
namespace ScrabblistaPL.UWP.Core
{
    public class AssetsReader : IAssetsReader
    {
        private string _path { get; set; }

        public IList<string> ReadDictionary()
        {
            GetFile();

            var assetContent = new List<string>();

            var path = _path;

            if (!File.Exists(path))
                return null;

            string line;

            using (var stream = new StreamReader(File.OpenRead(path)))
            {
                while ((line = stream.ReadLine()) != null)
                {
                    assetContent.Add(line);
                }
            }

            return assetContent;
        }

        public async void GetFile()
        {
            string dictionaryFile = @"Assets\PLdictionary.txt";
            StorageFolder installationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await installationFolder.GetFileAsync(dictionaryFile);

            _path = file.Path;
        }
    }
}
