using EngGameAppV2.Models;
using System.ComponentModel;
using Xamarin.Forms;

namespace EngGameAppV2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}