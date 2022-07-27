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
    public partial class Hiragana : ContentPage
    {
        Dictionary<string, CheckBox> checkBoxes;
        public Hiragana()
        {
            InitializeComponent();
            checkBoxes = new Dictionary<string, CheckBox>();
            checkBoxes.Add("h_a", h_a);
            checkBoxes.Add("h_ka", h_ka);
            checkBoxes.Add("h_sa", h_sa);
            checkBoxes.Add("h_ta", h_ta);
            checkBoxes.Add("h_na", h_na);
            checkBoxes.Add("h_ha", h_ha);
            checkBoxes.Add("h_ma", h_ma);
            checkBoxes.Add("h_ra", h_ra);
            checkBoxes.Add("h_yawan", h_yawan);
            checkBoxes.Add("h_ga", h_ga);
            checkBoxes.Add("h_za", h_za);
            checkBoxes.Add("h_da", h_da);
            checkBoxes.Add("h_ba", h_ba);
            checkBoxes.Add("h_pa", h_pa);

            accepth.Clicked += Accept_Clicked;
        }

        private async void Accept_Clicked(object sender, EventArgs e)
        {
            App.HK = new System.Collections.ObjectModel.ObservableCollection<Word>();
            foreach (var item in checkBoxes)
            {
                if (item.Value.IsChecked)
                {
                    foreach (var word in App.Dict[item.Key])
                    {
                        App.HK.Add(word);
                    }
                }
            }
            App.test = new Test(App.HK);
            App.test._init(true);
            await Task.WhenAll(Navigation.PopModalAsync(), Navigation.PushModalAsync(new TestPage()));
        }
    }
}