using App1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tests : ContentPage
    {
        public Tests()
        {
            InitializeComponent();
            rus_jap.Clicked += Rus_jap_Clicked;
            jap_rus.Clicked += Jap_rus_Clicked;
            hira.Clicked += Hira_Clicked;
            kata.Clicked += Kata_Clicked;
            if (App.Vocab.Count == 0)
            {
                rus_jap.BackgroundColor = Color.LightGray;
                jap_rus.BackgroundColor = Color.LightGray;
            }
        }

        private async void Kata_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Katakana());
        }

        private async void Hira_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Hiragana());
        }

        private async void Jap_rus_Clicked(object sender, EventArgs e)
        {
            if (App.Vocab.Count != 0)
            {
                App.test = new Test(App.Vocab);
                App.test._init(true);
                await Navigation.PushModalAsync(new TestPage());
            }
        }

        private async void Rus_jap_Clicked(object sender, EventArgs e)
        {
            if (App.Vocab.Count != 0)
            {
                App.test = new Test(App.Vocab);
                App.test._init(false);
                await Navigation.PushModalAsync(new TestPage());
            }
        }
    }
}