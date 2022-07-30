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
    public partial class TestPage : ContentPage
    {
        string _answer;
        string _task;
        public TestPage()
        {
            InitializeComponent();;
            check.Clicked += Check_Clicked;
            App.test.getWord(out _task, out _answer);
            word.Text = _task;
            corr.Text = App.test.correct.ToString();
            incorr.Text = App.test.incorrect.ToString();
            percent.Text = App.test.GetCorrectsPercentage();
            answer.Text = "";
            NavigationPage.SetIconColor(this, Color.Aqua);
        }

        private async void Check_Clicked(object sender, EventArgs e)
        {
            if (answer.Text != "")
            {
                if (answer.Text.ToLower() == _answer || (_answer + " ") == answer.Text.ToLower())
                {
                    App.test.Correct();
                    await Task.WhenAll(Navigation.PopModalAsync(), Navigation.PushModalAsync(new TestPage()));
                }
                else
                {
                    App.test.Incorrect();
                    await Task.WhenAll(Navigation.PopModalAsync(), Navigation.PushModalAsync(new TestPage()), Navigation.PushModalAsync(new CustomAlert("Неверно!", "Правильный ответ: " + _answer, "Ок"), false));
                }
            }   
        }

        protected override bool OnBackButtonPressed()
        {
            App.test.Reset();
            return base.OnBackButtonPressed();
        }
    }
}