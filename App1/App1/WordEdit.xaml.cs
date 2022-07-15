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
    public partial class WordEdit : ContentPage
    {

        public Word selectd { get; set; }
        public IList<Word> voc { get; set; } 

        Word backup = new Word();
        public WordEdit()
        {
            InitializeComponent();
            x.Clicked += X_Clicked;
            v.Clicked += V_Clicked;
            t.Clicked += T_Clicked;
        }

        async void T_Clicked(object sender, EventArgs e)
        {
            voc.Remove(selectd);

            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            backup.jap = selectd.jap;
            backup.trans = selectd.trans;
            backup.rus = selectd.rus;

            _jap.Text = backup.jap;
            _trans.Text = backup.trans;

            japEntry.Text = backup.jap;
            transEntry.Text = backup.trans;
            rusEntry.Text = backup.rus;
        }

        async void V_Clicked(object sender, EventArgs e)
        {
            selectd.jap = japEntry.Text;
            selectd.rus = rusEntry.Text;
            selectd.trans = transEntry.Text;
            await Navigation.PopModalAsync();
        }

        async void X_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        //protected override void OnDisappearing()
        //{
        //    Navigation.PopAsync();
        //}
    }
}