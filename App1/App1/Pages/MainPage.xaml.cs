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
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void Tests_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Tests());
        }

        async void Voc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Vocabulary());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            Application.Current.SavePropertiesAsync();
            App.Vocab = new ObservableCollection<Word>();
        }
    }
}
