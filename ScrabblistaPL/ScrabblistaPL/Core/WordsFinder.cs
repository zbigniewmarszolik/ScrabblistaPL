using System.Collections.Generic;
using ScrabblistaPL.Domain.Core;
using ScrabblistaPL.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ScrabblistaPL.Core
{
    public class WordsFinder : IWordsFinder
    {
        private IScoreResolver _scoreResolver { get; set; }

        public WordsFinder()
        {
            _scoreResolver = new ScoreResolver();
        }

        public IList<Word> MatchingWords(IList<Word> operatingSet, string userInput)
        {
            var wildCardCount = 0;

            foreach (var item in userInput)
                if (item == '?') wildCardCount++;

            if (wildCardCount > 2)
                wildCardCount = 2;

            var input = userInput.Replace("?", "");

            Parallel.ForEach(operatingSet, (item) =>
            {
                var tempInput = input;

                var inputLength = tempInput.Length + wildCardCount;

                if (inputLength >= item.Content.Length)
                {
                    var iterator = item.Content.Length;

                    for (int i = 0; i < item.Content.Length; i++)
                    {
                        for (int j = 0; j < tempInput.Length; j++)
                        {
                            if (item.Content[i] == tempInput[j])
                            {
                                iterator--;
                                tempInput = tempInput.Remove(j, 1);
                                break;
                            }
                        }
                    }

                    if (iterator <= wildCardCount)
                    {
                        item.IsMatching = true;
                    }
                }
            });

            operatingSet = operatingSet.Where(x => x.IsMatching == true).ToList();

            foreach (var item in operatingSet)
            {
                item.Score = _scoreResolver.FixScore(item.Content, userInput);
            }

            return operatingSet;
        }
    }
}
