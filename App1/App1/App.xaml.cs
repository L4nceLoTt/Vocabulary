using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public ObservableCollection<Word> Vocab { get; set; }

        public App()
        {
            InitializeComponent();
        }

        protected override async void OnStart()
        {
            Vocab = new ObservableCollection<Word>();

            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
            Vocab.Add(new Word()
            {
                jap = "あいう",
                rus = "adfg",
                trans = "aiu"
            });
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
