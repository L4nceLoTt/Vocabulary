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
        public MainPage()
        {
            InitializeComponent();
            tests.Clicked += Tests_Clicked;
            voc.Clicked += Voc_Clicked;
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
