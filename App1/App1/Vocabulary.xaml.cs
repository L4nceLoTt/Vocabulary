using System;
using System.IO;
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
    public partial class Vocabulary : ContentPage
    {
        public ObservableCollection<Word> voc { get; set; }
        Word selectedWord;
        
        public Vocabulary()
        {
            InitializeComponent();

            
            Add.Clicked += Add_Clicked;
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddWord() { WordList = voc });
        }

        protected override async void OnAppearing()
        { 
            this.BindingContext = this;
        }


        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedWord = e.CurrentSelection[0] as Word;
            await Navigation.PushModalAsync(new WordEdit() { Voc = voc, SelectedWord = selectedWord });
        }
    }
}