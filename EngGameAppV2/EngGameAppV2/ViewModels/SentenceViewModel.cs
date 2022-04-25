using EngGameAppV2.Models;
using EngGameAppV2.Services;
using EngGameAppV2.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EngGameAppV2.ViewModels
{
    public class SentenceViewModel : BaseViewModel
    {
        private int guessedCount = 0;
        private Levels state;
        private string result;
        private string wordSelected;
        //Random random = new Random();
        public ObservableCollection<Word> WordList { get; }
        public ObservableCollection<string> SentenceList { get; }
        public Command WordTapped { get; }

        private Command playCommand;

        public ICommand EndCommand { get; }

        public Command ValidateSentenceCommand { get; }
        public SentenceViewModel()
        {
            WordList = new ObservableCollection<Word>();

            SentenceList = new ObservableCollection<string>();

            WordTapped = new Command(PutWordInEntry);

            ValidateSentenceCommand = new Command(Validate);

            EndCommand = new Command(EndGame);
        }

        //async Task LoadListCommand()
        //{

        //}
        public string WordSelected
        {
            get => wordSelected;
            set => SetProperty(ref wordSelected, value);
           
        }

        public Levels State
        {
            get => state;
            set => SetProperty(ref state, value);

        }

        public string Result
        {
            get => result;
            set => SetProperty(ref result, value);
        }

        public int GuessedCount
        {
            get => guessedCount;
            set => SetProperty(ref guessedCount, value);
        }

        void PutWordInEntry(object o)
        {
            Word movedWord = o as Word;
            string[] subs = SentenceList[0].Split(' ');
            if (movedWord.word == subs.Last())
            {
                WordSelected += movedWord.word;
                WordList.Remove(movedWord);

            }
            else
            {
            WordSelected += movedWord.word + " ";
            WordList.Remove(movedWord);

            }


        }
        //void ResetBack()
        //{

        //}

        void Validate()
        {
            if (SentenceList.Contains(WordSelected))
            {

                if(GuessedCount < SentenceList.Count)
                {

                GuessedCount++;
                WordSelected = "";
                WordList.Clear();
                    WordList.Add(new Word("Gold"));
                    WordList.Add(new Word("Word"));
                    WordList.Add(new Word("Silver"));
                    WordList.Add(new Word("Bronze"));
                    WordList.Add(new Word("Diamond"));
                    WordList.Add(new Word("She"));
                }

                if(GuessedCount == SentenceList.Count)
                {
                    Result = GuessedCount + " / " + SentenceList.Count;
                    State = Levels.Complete;
                }
            }
            else
            {
                Result = GuessedCount + " / " + SentenceList.Count;
                WordSelected = "";
                //Console.WriteLine("Not correct sentence");
                State = Levels.Complete;
            }
        }

        public ICommand PlayCommand
        {
            get
            {
                if (playCommand == null)
                {
                    playCommand = new Command(Play);
                }

                return playCommand;
            }
        }

        private async void Play()
        {
            WordList.Clear();
            var wordBankStorage = new WordBankStorage();

            var allSentence = await wordBankStorage.SenListAsync();

            for (int i = 0; i < allSentence.Count; i++)
            {

            SentenceList.Add(allSentence[i].EnglishSentence);
            string[] subs = allSentence[i].EnglishSentence.Split(' '); 
            foreach(var sub in subs)
            {
                WordList.Add(new Word(sub));
            }
            }

            //WordList.Add(new Word("Drake"));
            //WordList.Add(new Word("Spegel"));
            //WordList.Add(new Word("Hus"));
            //WordList.Add(new Word("Mörker"));
            //WordList.Add(new Word("Flamma"));
            //WordList.Add(new Word("Svärd"));
            GuessedCount = 0;
            State = Levels.Playing;
        }

        private async void EndGame()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
