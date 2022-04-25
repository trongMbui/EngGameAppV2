using EngGameAppV2.Services;
using EngGameAppV2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace EngGameAppV2
{
    public partial class App : Application
    {
        //private static SQLiteHelper db;

        //public static SQLiteHelper MyDatabase
        //{
        //    get
        //    {
        //        if (db == null)
        //        {
        //            db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        //                "MyStore.db3"));
        //        }
        //        return db;
        //    } 
        //}
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
