using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        IList<Word> Vocab { get; set; }
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            Vocab = new List<Word>();

            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });

            MainPage = new NavigationPage(new MainPage() { vocab = Vocab });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
