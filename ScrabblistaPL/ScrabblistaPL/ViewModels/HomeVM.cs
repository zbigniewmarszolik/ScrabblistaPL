using ScrabblistaPL.Core;
using ScrabblistaPL.Domain.Core;
using ScrabblistaPL.Domain.Models;
using ScrabblistaPL.Domain.ViewComponents;
using ScrabblistaPL.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScrabblistaPL.ViewModels
{
    public class HomeVM : ViewModelBase
    {
        public Command SearchCommand { get; set; }
        public Action WrongInputAction { get; set; }
        public Action TooLongInputAction { get; set; }
        public BulkCollection<Word> WordsFound { get; set; }

        private IList<Word> _allWords { get; set; }
        private IAssetsReader _assetsReader { get; set; }
        private IWordsFinder _wordsFinder { get; set; }
        private ILettersConverter _lettersConverter { get; set; }

        private char[] _letters { get; set; }

        public string HelpAdvice { get; set; }

        private string _inputLetters;

        public string InputLetters
        {
            get { return _inputLetters; }
            set
            {
                _inputLetters = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        private bool _isCounterVisible;

        public bool IsCounterVisible
        {
            get { return _isCounterVisible; }
            set
            {
                _isCounterVisible = value;
                OnPropertyChanged();
            }
        }

        private string _wordsAmount;

        public string WordsAmount
        {
            get { return _wordsAmount; }
            set
            {
                _wordsAmount = value;
                OnPropertyChanged();
            }
        }



        public HomeVM()
        {
            _assetsReader = DependencyService.Get<IAssetsReader>();
            _wordsFinder = new WordsFinder();
            _lettersConverter = new LettersConverter();

            SearchCommand = new Command(Search);
            WordsFound = new BulkCollection<Word>();
            _allWords = new List<Word>();

            Word model;
            var assetResult = _assetsReader.ReadDictionary();

            foreach (var item in assetResult)
            {
                model = new Word();
                model.Content = item;
                model.IsMatching = false;
                _allWords.Add(model);
            }

            HelpAdvice = "Prosze wpisać litery i wcisnąć SZUKAJ. W celu wpisania dzikiej karty, prosze wpisać znak zapytania. " +
                "Maksymalna ilość dzikich kart to 2. " +
                "Maksymalna ilość wprowadzanych znaków to 16 włącznie z dzikimi kartami.";

            _letters = new char[] { '?', 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń',
                'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż' };
        }

        private void Search()
        {
            WordsFound.Clear();
            IsCounterVisible = false;

            if (InputLetters == null)
                return;

            if (InputLetters.Length > 16)
            {
                TooLongInputAction();
                return;
            }

            InputLetters = _lettersConverter.ConvertUpperToLowerCase(InputLetters);

            foreach (var item in InputLetters)
            {
                if (!_letters.Contains(item))
                {
                    WrongInputAction();
                    return;
                }
            }

            IsBusy = true;

            Task.Run(() =>
            {
                var resultFound = _wordsFinder.MatchingWords(_allWords, InputLetters);

                resultFound = resultFound.OrderByDescending(x => x.Score).ToList();

                foreach (var item in resultFound)
                {
                    item.IsMatching = false;
                }

                Device.BeginInvokeOnMainThread(() =>
                {
                    WordsFound.PushList(resultFound);

                    WordsAmount = WordsFound.Count.ToString();

                    IsBusy = false;
                    IsCounterVisible = true;
                });
            });
        }
    }
}