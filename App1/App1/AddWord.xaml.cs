using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWord : ContentPage
    {
        public AddWord()
        {
            InitializeComponent();
            v.Clicked += V_Clicked;
            x.Clicked += X_Clicked;
        }

        async void X_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void V_Clicked(object sender, EventArgs e)
        {
            App.Update(null, new Word() { jap = japEntry.Text, rus = rusEntry.Text, trans = transEntry.Text });
            await Navigation.PopModalAsync(); 
        }
    }
}