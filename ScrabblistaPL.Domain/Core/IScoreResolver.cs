namespace ScrabblistaPL.Domain.Core
{
    public interface IScoreResolver
    {
        int FixScore(string word, string input);
    }
}
