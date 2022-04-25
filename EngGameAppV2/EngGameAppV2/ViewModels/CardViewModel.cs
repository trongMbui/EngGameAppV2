using EngGameAppV2.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngGameAppV2.ViewModels
{
    public class CardViewModel : BaseViewModel
    {
        private bool isGuessed;
        private bool isSelected;
        private readonly WordModel cardWord;

        public string Word => cardWord.ActualWord;
       
        public string Def => cardWord.Definition;



        public bool IsGuessed
        {
            get => isGuessed;
            set => SetProperty(ref isGuessed, value);
        }

        public bool IsSelected
        {
            get => isSelected;
            set => SetProperty(ref isSelected, value);
        }

        public CardViewModel(WordModel word)
        {
            this.cardWord = word;
        }

    }
}
