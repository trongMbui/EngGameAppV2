using EngGameAppV2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EngGameAppV2.ViewModels
{
    public class HomeViewModel
    {
        public Command SentenceCommand { get; }
        public Command PairingCommand { get; }
        public Command PronounceCommand { get; }
        public HomeViewModel()
        {
            SentenceCommand = new Command(GoToSentencePage);
            PairingCommand = new Command(GoToPairingPage);
            PronounceCommand = new Command(GoToPronouncePage);
        }

        private async void GoToPronouncePage()
        {
            await Shell.Current.GoToAsync(nameof(PronouncePage));
        }

        private async void GoToPairingPage()
        {
            await Shell.Current.GoToAsync(nameof(PairingPage));
        }

        private async void GoToSentencePage()
        {
            await Shell.Current.GoToAsync(nameof(SentencePage));
        }
    }
}
