using EngGameAppV2.Models;
using EngGameAppV2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MvvmHelpers;
using Xamarin.Forms;
using System.Threading.Tasks;
using MvvmHelpers.Commands;
using System.Windows.Input;

namespace EngGameAppV2.ViewModels
{
    public class WordBankViewModel : BaseViewModel
    {
        public WordBankStorage wordBankStorage { get; }
        public ICommand GoToHomeCommand { get; }
        public WordModel Word { get; }
        public ICommand AddNewWordCommand { get; }
        public ICommand LoadWordCommand { get; }
        public ICommand RemoveCommand { get; }
        public ObservableRangeCollection<Sentence> SentenceList { get; }
        public ObservableRangeCollection<WordModel> WordList { get; } = new ObservableRangeCollection<WordModel>();

        public WordBankViewModel()
        {
            Word = new WordModel();
            AddNewWordCommand = new AsyncCommand(AddWord);
            RemoveCommand = new AsyncCommand<WordModel>(RemoveWord);
            LoadWordCommand = new AsyncCommand(Refresh);
            GoToHomeCommand = new AsyncCommand(GoBackHome);


        }

        

        private async Task GoBackHome()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }

        //private async void 

        //    private async Task ReadListWord()
        //    {
        //        IsBusy = true;
        //        try
        //        {
        //        WordList.ReplaceRange(await App.MyDatabase.ReadWords());

        //        }
        //        catch(Exception ex)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            IsBusy=false;
        //        }
        //        //var list = await App.MyDatabase.ReadWords();


        //    }

        private async Task AddWord()
        {
            var word = await App.Current.MainPage.DisplayPromptAsync("Word", "Write the word");
            var def = await App.Current.MainPage.DisplayPromptAsync("Defintion", "Write the defintion");

            await WordService.AddWord(word, def);
            //await Refresh();
        }
        private async Task RemoveWord(WordModel wordModel)
        {
            await WordService.RemoveWord(wordModel.Id);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1000);
            //WordList.Clear();
            var words = await WordService.GetWord();
            WordList.ReplaceRange(words);
            IsBusy = false;
        }
    }
}
