using ScrabblistaPL.Domain.Core;

namespace ScrabblistaPL.Core
{
    public class LettersConverter : ILettersConverter
    {
        public string ConvertUpperToLowerCase(string input)
        {
            input = input.Replace('A', 'a');
            input = input.Replace('Ą', 'ą');
            input = input.Replace('B', 'b');
            input = input.Replace('C', 'c');
            input = input.Replace('Ć', 'ć');
            input = input.Replace('D', 'd');
            input = input.Replace('E', 'e');
            input = input.Replace('Ę', 'ę');
            input = input.Replace('F', 'f');
            input = input.Replace('G', 'g');
            input = input.Replace('H', 'h');
            input = input.Replace('I', 'i');
            input = input.Replace('J', 'j');
            input = input.Replace('K', 'k');
            input = input.Replace('L', 'l');
            input = input.Replace('Ł', 'ł');
            input = input.Replace('M', 'm');
            input = input.Replace('N', 'n');
            input = input.Replace('Ń', 'ń');
            input = input.Replace('O', 'o');
            input = input.Replace('Ó', 'ó');
            input = input.Replace('P', 'p');
            input = input.Replace('Q', 'q');
            input = input.Replace('R', 'r');
            input = input.Replace('S', 's');
            input = input.Replace('Ś', 'ś');
            input = input.Replace('T', 't');
            input = input.Replace('U', 'u');
            input = input.Replace('V', 'v');
            input = input.Replace('W', 'w');
            input = input.Replace('X', 'x');
            input = input.Replace('Y', 'y');
            input = input.Replace('Z', 'z');
            input = input.Replace('Ż', 'ż');
            input = input.Replace('Ź', 'ź');

            return input;
        }
    }
}
