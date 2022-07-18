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
        static ObservableCollection<Word> Vocabulary;
        public static ObservableCollection<Word> Vocab
        {
            get
            {
                if (Vocabulary == null)
                {
                    Vocabulary = new ObservableCollection<Word>();
                }
                return Vocabulary;
            }
            set
            {
                Vocabulary = value;
            }
        }
        public static int counter;
        public App()
        {
            InitializeComponent();
        }

        protected override async void OnStart()
        {
            SaveOrLoad(false);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static async void SaveOrLoad(bool choice)
        {
            if (choice)
            {
                Application.Current.Properties["counter"] = Vocab.Count;
                for (int i = 0; i < Vocab.Count; i++)
                {
                    Application.Current.Properties["jap" + i.ToString()] = Vocab[i].jap;
                    Application.Current.Properties["rus" + i.ToString()] = Vocab[i].rus;
                    Application.Current.Properties["trans" + i.ToString()] = Vocab[i].trans;
                }
                await Application.Current.SavePropertiesAsync();
            }
            else
            {
                object tmp;
                if (Application.Current.Properties.TryGetValue("counter", out tmp))
                {
                    counter = (int)tmp;

                    for(int i = 0; i < counter; i++)
                    {
                        Vocab.Add(new Word() { jap = Application.Current.Properties["jap" + i.ToString()].ToString(), trans = Application.Current.Properties["trans" + i.ToString()].ToString(), rus = Application.Current.Properties["rus" + i.ToString()].ToString() });
                    }
                }
            }
        }
        public static void Update(Word _old, Word _new)
        {
            if (_old == null)
            {
                Vocab.Add(_new);
            }
            else
            {
                int index = Vocab.IndexOf(_old);
                Vocab[index] = _new;
            }
            SaveOrLoad(true);
        }
    }
}
