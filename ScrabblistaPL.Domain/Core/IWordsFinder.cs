using ScrabblistaPL.Domain.Models;
using System.Collections.Generic;

namespace ScrabblistaPL.Domain.Core
{
    public interface IWordsFinder
    {
        IList<Word> MatchingWords(IList<Word> operatingSet, string userInput);
    }
}
