using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Widget;
using Xamarin.CommunityToolkit.ObjectModel;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vocabulary : ContentPage
    {
        Word selectedWord;
        public Vocabulary()
        {
            InitializeComponent();
            collection.EmptyView = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label()
                    {
                        Text = "Словарь пуст",
                        TextColor = Color.DarkGray,
                        FontSize = 40,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
            Add.Clicked += Add_Clicked;

        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddWord());
        }

        protected override void OnAppearing()
        {
            collection.ItemsSource = App.Vocab.GroupBy(x => x.tag).OrderBy(x => x.Key);
        }


        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedWord = e.CurrentSelection[0] as Word;
            await Navigation.PushModalAsync(new WordEdit() { SelectedWord = selectedWord });
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            collection.ItemsSource = App.Vocab.Where(x => x.jap.ToLower().Contains((sender as SearchBar).Text.ToLower()) ||
                                                            x.rus.ToLower().Contains((sender as SearchBar).Text.ToLower()) ||
                                                            x.tag.ToLower().Contains((sender as SearchBar).Text.ToLower())).GroupBy(x => x.tag).OrderBy(x => x.Key);
        }
    }
}