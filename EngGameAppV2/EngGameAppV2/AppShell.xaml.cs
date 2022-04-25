using EngGameAppV2.Models;
using EngGameAppV2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EngGameAppV2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PairingPage), typeof(PairingPage));
            Routing.RegisterRoute(nameof(PronouncePage), typeof(PronouncePage));
            Routing.RegisterRoute(nameof(SentencePage), typeof(SentencePage));
        }

    }
}
