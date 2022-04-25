using EngGameAppV2.ViewModels;
using EngGameAppV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EngGameAppV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PairingPage : ContentPage
    {
        public PairingPage()
        {
            InitializeComponent();
        }

        //private void PairingViewModel_PropertyChanged(object sender, PropertyChangingEventArgs e)
        //{
        //    if (e.PropertyName == nameof(PairingViewModel.State) &&
        //        BindingContext is PairingViewModel pairingViewModel &&
        //        pairingViewModel.State == Models.Levels.Complete)
        //    {
        //        TrophyAnimation.PlayAnimation;
        //    } 
        //}
    }
}