﻿using Android.Widget;
using App1.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Word SelectedWord { get; set; }
        public WordEdit()
        {
            InitializeComponent();
            t.Clicked += T_Clicked;
            v.Clicked += V_Clicked;
            chooseTag.Clicked += ChooseTag_Clicked;
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

        protected override void OnAppearing()
        {
            japEntry.Text = SelectedWord.jap;
            rusEntry.Text = SelectedWord.rus;
            transEntry.Text = SelectedWord.trans;
            tagEntry.Text = SelectedWord.tag;
        }

        private async void V_Clicked(object sender, EventArgs e)
        {
            if (japEntry.Text == "" || rusEntry.Text == "" || transEntry.Text == "" || tagEntry.Text == "")
            {
                await Navigation.PushModalAsync(new CustomAlert("Внимание", "Заполните все поля!", "Понял"), false);
            }
            else
            {
                App.Update(SelectedWord, new Word() { jap = japEntry.Text, rus = rusEntry.Text, trans = transEntry.Text, tag = tagEntry.Text });
                App.SaveOrLoad(true);
                await Navigation.PopModalAsync();
            }
        }

        private async void T_Clicked(object sender, EventArgs e)
        {
            App.Vocab.Remove(SelectedWord);
            App.SaveOrLoad(true);
            await Navigation.PopModalAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Update(SelectedWord, new Word() { jap = SelectedWord.jap, rus = SelectedWord.rus, trans = SelectedWord.trans, tag = SelectedWord.tag });
            App.SaveOrLoad(true);
            return base.OnBackButtonPressed();
        }
    }
}