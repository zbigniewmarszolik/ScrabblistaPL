using ScrabblistaPL.Domain.Core;
using System.Collections.Generic;
using System.Linq;

namespace ScrabblistaPL.Core
{
    public class ScoreResolver : IScoreResolver
    {
        private IDictionary<char, int> _scoresTable { get; set; }

        public ScoreResolver()
        {
            _scoresTable = new Dictionary<char, int>();

            FillTable();
        }

        public int FixScore(string word, string input)
        {
            var score = 0;
            var iter = 0;
            var localInput = input;
            var count = 0;

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < localInput.Length; j++)
                {
                    if (word[i] == localInput[j])
                    {
                        count++;
                        score += _scoresTable.Where(x => x.Key == word[i]).Select(y => y.Value).Single();
                        localInput = localInput.Remove(j, 1);
                        break;
                    }
                }
            }

            if (count < word.Length)
            {
                var cond = word.Length - count;

                if (cond > 2)
                    cond = 2;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '?')
                    {
                        iter++;
                        score++;
                    }

                    if (iter >= cond)
                        break;
                }
            }

            return score;
        }

        private void FillTable()
        {
            _scoresTable.Add('a', 1);
            _scoresTable.Add('ą', 5);
            _scoresTable.Add('b', 3);
            _scoresTable.Add('c', 2);
            _scoresTable.Add('ć', 6);
            _scoresTable.Add('d', 2);
            _scoresTable.Add('e', 1);
            _scoresTable.Add('ę', 5);
            _scoresTable.Add('f', 5);
            _scoresTable.Add('g', 3);
            _scoresTable.Add('h', 3);
            _scoresTable.Add('i', 1);
            _scoresTable.Add('j', 3);
            _scoresTable.Add('k', 2);
            _scoresTable.Add('l', 2);
            _scoresTable.Add('ł', 3);
            _scoresTable.Add('m', 2);
            _scoresTable.Add('n', 1);
            _scoresTable.Add('ń', 7);
            _scoresTable.Add('o', 1);
            _scoresTable.Add('ó', 5);
            _scoresTable.Add('p', 2);
            _scoresTable.Add('q', 1);
            _scoresTable.Add('r', 1);
            _scoresTable.Add('s', 1);
            _scoresTable.Add('ś', 5);
            _scoresTable.Add('t', 2);
            _scoresTable.Add('u', 3);
            _scoresTable.Add('v', 1);
            _scoresTable.Add('w', 1);
            _scoresTable.Add('x', 1);
            _scoresTable.Add('y', 2);
            _scoresTable.Add('z', 1);
            _scoresTable.Add('ż', 5);
            _scoresTable.Add('ź', 9);
        }
    }
}
