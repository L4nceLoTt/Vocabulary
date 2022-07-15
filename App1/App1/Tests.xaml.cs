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
    public partial class Tests : ContentPage
    {
        public Tests()
        {
            InitializeComponent();
        }

        //protected override void OnDisappearing()
        //{
        //    Navigation.PopModalAsync();
        //}
    }
}