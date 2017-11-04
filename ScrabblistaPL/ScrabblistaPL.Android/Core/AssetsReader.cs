using Android.Content.Res;
using ScrabblistaPL.Android.Helpers;
using ScrabblistaPL.Domain.Core;
using ScrabblistaPL.Android.Core;
using System.Collections.Generic;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AssetsReader))]
namespace ScrabblistaPL.Android.Core
{
    public class AssetsReader : IAssetsReader
    {
        public IList<string> ReadDictionary()
        {
            var assetContent = new List<string>();

            string line;
            AssetManager assets = AssetsHelper.StaticAssets;

            using (StreamReader stream = new StreamReader(assets.Open("PLdictionary.txt")))
            {
                while ((line = stream.ReadLine()) != null)
                {
                    assetContent.Add(line);
                }
            }

            return assetContent;
        }
    }
}