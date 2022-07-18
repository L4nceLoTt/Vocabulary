using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordEdit : ContentPage
    {
        public Word SelectedWord { get; set; }
        public WordEdit()
        {
            InitializeComponent();
            x.Clicked += X_Clicked;
            t.Clicked += T_Clicked;
            v.Clicked += V_Clicked;
        }

        protected override void OnAppearing()
        {
            _jap.Text = SelectedWord.jap;
            _trans.Text = SelectedWord.trans;
            japEntry.Text = SelectedWord.jap;
            rusEntry.Text = SelectedWord.rus;
            transEntry.Text = SelectedWord.trans;
        }

        private async void V_Clicked(object sender, EventArgs e)
        {
            App.Update(SelectedWord, new Word() { jap = japEntry.Text, rus = rusEntry.Text, trans = transEntry.Text });
            await Navigation.PopModalAsync();
        }

        private async void T_Clicked(object sender, EventArgs e)
        {
            App.Vocab.Remove(SelectedWord);
            await Navigation.PopModalAsync();
        }

        private async void X_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}