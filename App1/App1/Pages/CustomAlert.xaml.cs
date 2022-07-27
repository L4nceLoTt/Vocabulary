using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomAlert : ContentPage
    {
        public CustomAlert(string header, string description, string cancelButton)
        {
            InitializeComponent();
            Header.Text = header;
            Description.Text = description;
            CancelButton.Text = cancelButton;
            CancelButton.Clicked += CancelButton_Clicked;
            this.Content.Scale = 0;
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Animation(0);
        }

        protected override void OnAppearing()
        {
            Animation(1);
        }

        void Animation(double scaleTo)
        {
            if (scaleTo == 1)
            {
                this.Content.ScaleTo(scaleTo, 300, Easing.SpringOut);
            }
            else if (scaleTo == 0)
            {
                Task.Run(() =>
                {
                    Task.WaitAny(this.Content.ScaleTo(scaleTo, 200, Easing.SpringIn));
                    Navigation.PopModalAsync();
                });
            }
        }
    }
}