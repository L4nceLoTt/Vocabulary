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
    public partial class Vocabulary : ContentPage
    {
        public IList<Word> voc { get; set; }
        Word selectedWord;

        public Vocabulary()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (voc.Count == 0)
            {
                BindingContext = this;
                Content = new StackLayout()
                {
                    BackgroundColor = Color.White,
                    Children =
                    {
                        new Label()
                        {
                            Text = "Словарь пуст",
                            TextColor = Color.Black,
                            FontSize = 30,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center
                        }
                    }
                };
            }
            else
            {
                BindingContext = this;
            }
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedWord = e.CurrentSelection[0] as Word;
            await Navigation.PushModalAsync(new WordEdit() { selectd = selectedWord, voc = this.voc});
        }

        //protected override void OnDisappearing()
        //{
        //    Navigation.PopAsync();
        //}
    }
}