using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Pages;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWord : ContentPage
    {
        public AddWord()
        {
            InitializeComponent();
            v.Clicked += V_Clicked;
            chooseTag.Clicked += ChooseTag_Clicked;
            japEntry.Text = rusEntry.Text = transEntry.Text = tagEntry.Text = "";
        }

        private async void ChooseTag_Clicked(object sender, EventArgs e)
        {
            string[] tags = App.GetTags();
            if (tags.Length != 0)
            {
                string result = await DisplayActionSheet(null, null, null, tags);
                tagEntry.Text = result;
            }
        }

        async void V_Clicked(object sender, EventArgs e)
        {
            if (japEntry.Text == "" || rusEntry.Text == "" || transEntry.Text == "" || tagEntry.Text == "")
            {
                await Navigation.PushModalAsync(new CustomAlert("Внимание", "Заполните все поля!", "Понял"), false);
            }
            else
            {
                App.Update(null, new Word() { jap = japEntry.Text, rus = rusEntry.Text, trans = transEntry.Text, tag = tagEntry.Text });
                App.SaveOrLoad(true);
                await Navigation.PopModalAsync(); 
            }
        }
    }
}