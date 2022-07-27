using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        bool isVisible = false;

        public MainPage()
        {
            InitializeComponent();
            tests.Clicked += Tests_Clicked;
            voc.Clicked += Voc_Clicked;

            sett.Clicked += Sett_Clicked;
            settings.TranslationX = -290;
            sett.TranslationX = -290;
            sett.Rotation = 180;
        }

        private async void Sett_Clicked(object sender, EventArgs e)
        {
            if (isVisible)
            {
                await Task.WhenAll(settings.TranslateTo(-290, 0, 500, Easing.BounceOut), sett.TranslateTo(-290, 0, 500, Easing.BounceOut), sett.RelRotateTo(-180, 500, Easing.BounceOut));
            }
            else
            {
                await Task.WhenAll(settings.TranslateTo(-20, 0, 500, Easing.BounceOut), sett.TranslateTo(-20, 0, 500, Easing.BounceOut), sett.RelRotateTo(180, 500, Easing.BounceOut));
            }
            isVisible = !isVisible;
        }

        async void Tests_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Tests());
        }

        async void Voc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Vocabulary());
        }
    }
}
