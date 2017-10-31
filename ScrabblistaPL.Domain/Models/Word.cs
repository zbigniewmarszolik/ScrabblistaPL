namespace ScrabblistaPL.Domain.Models
{
    public class Word
    {
        public string Content { get; set; }
        public bool IsMatching { get; set; }
        public int Score { get; set; }

        public string Presentation
        {
            get
            {
                return Content + " (" + Score.ToString() + ")";
            }
        }
    }
}
