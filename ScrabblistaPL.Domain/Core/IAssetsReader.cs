using System.Collections.Generic;

namespace ScrabblistaPL.Domain.Core
{
    public interface IAssetsReader
    {
        IList<string> ReadDictionary();
    }
}
