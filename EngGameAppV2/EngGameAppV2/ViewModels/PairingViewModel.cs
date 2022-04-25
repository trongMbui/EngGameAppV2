using EngGameAppV2.Models;
using System;
using MvvmHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using EngGameAppV2.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using Android.Util;

namespace EngGameAppV2.ViewModels
{
    public class PairingViewModel : BaseViewModel
    {
        private Levels state;
        
        private CardViewModel card;
        
        private int guessedCount;
        
        public int test;
        public string Result { get; set; }

        private CancellationTokenSource cancelAnimationTokenSource;
        public Command EndCommand { get; }
        public ICommand PlayCommand { get; }
        public ICommand SelectTileCommand { get; }
        public MvvmHelpers.ObservableRangeCollection<WordModel> WordList { get; } = new MvvmHelpers.ObservableRangeCollection<WordModel>();
        public MvvmHelpers.ObservableRangeCollection<CardViewModel> CardViewModels { get; } = new MvvmHelpers.ObservableRangeCollection<CardViewModel>();
        public MvvmHelpers.ObservableRangeCollection<CardViewModel> GuessedCards { get; } = new MvvmHelpers.ObservableRangeCollection<CardViewModel>();
        public PairingViewModel()
        {
            PlayCommand = new AsyncCommand(PlayGameAsync, allowsMultipleExecutions: false);
            EndCommand = new Command(EndGame);
            SelectTileCommand = new AsyncCommand<CardViewModel>(OnSelectTile, allowsMultipleExecutions: true);
            //WordList = new ObservableCollection<Word>()
            //{
            //    new Word("hej"),
            //    new Word("Tjena")
            //};
        }

        private async Task OnSelectTile(CardViewModel cardModel)
        {
            cancelAnimationTokenSource?.Cancel();

            cardModel.IsSelected = !cardModel.IsSelected;

            if (this.card is not null)
            {
                if (this.card.Def == cardModel.Def &&
                    ReferenceEquals(this.card, cardModel) == false)
                {
                    this.card.IsGuessed = true;
                    cardModel.IsGuessed = true;
                }

                cancelAnimationTokenSource = new CancellationTokenSource();

                try
                {
                    await Task.Delay(500, cancelAnimationTokenSource.Token);
                }
                catch (OperationCanceledException)
                {

                }
                finally
                {
                    cancelAnimationTokenSource = null;
                }

                if (this.card.Def == cardModel.Def &&
                    ReferenceEquals(this.card, cardModel) == false)
                {
                    if (GuessedCards.Count < 5)
                    {
                        GuessedCards.Add(cardModel);
                    }

                    this.card.IsSelected = false;
                    this.card = null;

                    GuessedCount++;
                }
                else
                {
                    this.card.IsSelected = false;
                }

                cardModel.IsSelected = false;
            }

            this.card = cardModel.IsSelected ? cardModel : null;

            if (CardViewModels.All(s => s.IsGuessed))
            {
                Result = GuessedCount + " / " + CardViewModels.Count();
               // CardViewModels.Clear();
                State = Levels.Complete;
            }
        }

        public Levels State
        {
            get => state;
            set => SetProperty(ref state, value);
        }
        public int GuessedCount
        {
            get => guessedCount;
            set => SetProperty(ref guessedCount, value);
        }
        private async Task PlayGameAsync()
        {

            //var wordBankStorage = new WordBankStorage();

            WordList.AddRange(await WordService.GetWord());
            var allWords = WordList;

            var random = new Random();

            int gridSize = allWords.Count;
            var requiredWordCount = (gridSize / 2) ;

            var actualWords = new List<CardViewModel>(gridSize);

            for (int i = 0; i < gridSize; i++)
            {
                var wordIndex = random.Next(allWords.Count);
                var word = allWords[wordIndex];
                allWords.RemoveAt(wordIndex);
                actualWords.Add(new CardViewModel(word));
                //actualWords.Add(new CardViewModel(word));

            }

            int n = actualWords.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (actualWords[n], actualWords[k]) = (actualWords[k], actualWords[n]);
            }
            CardViewModels.Clear();
           
            CardViewModels.ReplaceRange(actualWords);

            Log.Info("my app",CardViewModels.Count + "");
            State = Levels.Playing;
            // GuessedCount = 0;
            // GuessedCards.Clear();
            //test = CardViewModels.Count;
        }

        private async void EndGame()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
