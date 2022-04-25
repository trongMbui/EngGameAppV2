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
    public partial class SentencePage : ContentPage
    {
        public SentencePage()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }
    }
}