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
    public partial class Katakana : ContentPage
    {
        Dictionary<string, CheckBox> checkBoxes;
        public Katakana()
        {
            InitializeComponent();
            checkBoxes = new Dictionary<string, CheckBox>();
            checkBoxes.Add("k_a", k_a);
            checkBoxes.Add("k_ka", k_ka);
            checkBoxes.Add("k_sa", k_sa);
            checkBoxes.Add("k_ta", k_ta);
            checkBoxes.Add("k_na", k_na);
            checkBoxes.Add("k_ha", k_ha);
            checkBoxes.Add("k_ma", k_ma);
            checkBoxes.Add("k_ra", k_ra);
            checkBoxes.Add("k_yawan", k_yawan);
            checkBoxes.Add("k_ga", k_ga);
            checkBoxes.Add("k_za", k_za);
            checkBoxes.Add("k_da", k_da);
            checkBoxes.Add("k_ba", k_ba);
            checkBoxes.Add("k_pa", k_pa);

            acceptk.Clicked += Acceptk_Clicked;
        }

        private async void Acceptk_Clicked(object sender, EventArgs e)
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