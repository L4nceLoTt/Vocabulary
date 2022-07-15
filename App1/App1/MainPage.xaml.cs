using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public IList<Word> vocab { get; set; }

        public MainPage()
        {
            InitializeComponent();
            tests.Clicked += Tests_Clicked;
            voc.Clicked += Voc_Clicked;
            add.Clicked += Add_Clicked;
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddWord() { WordList = vocab });
        }

        async void Tests_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Tests());
        }

        async void Voc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Vocabulary()
            {
                voc = vocab
            });
        }
    }
}
