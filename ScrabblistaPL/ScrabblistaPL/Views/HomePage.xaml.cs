using ScrabblistaPL.ViewModels;
using Xamarin.Forms;

namespace ScrabblistaPL.Views
{
    public partial class HomePage : ContentPage
    {
        private HomeVM _vm { get; set; }

        public HomePage()
        {
            InitializeComponent();
            _vm = new HomeVM();
            BindingContext = _vm;

            _vm.TooLongInputAction = ShowLengthError;
            _vm.WrongInputAction = ShowInputError;

            HelpButton.Clicked += HelpButton_Clicked;

            LettersEntryBox.Unfocused += LettersEntryBox_Unfocused;

            WordsSet.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

            WordsSet.ItemTapped += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
        }

        private void ShowLengthError()
        {
            DisplayAlert("", "Maksymalna ilość wprowadzanych znaków to 16 włącznie z dzikimi kartami.", "OK");
        }

        private void ShowInputError()
        {
            DisplayAlert("", "Wprowadzono nieprawidłowe znaki. Proszę użyć liter polskiego alfabetu lub znaku zapytania w celu wpisania dzikiej karty.", "OK");
        }

        private void HelpButton_Clicked(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Pomoc", _vm.HelpAdvice, "OK");
            });
        }

        private void LettersEntryBox_Unfocused(object sender, FocusEventArgs e)
        {
            LettersEntryBox.Placeholder = "Moje litery...";
            LettersEntryBox.Text = LettersEntryBox.Text;
        }
    }
}