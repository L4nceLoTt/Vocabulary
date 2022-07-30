using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Pages;

namespace App1
{
    public partial class App : Application
    {
        static ObservableCollection<Word> Vocabulary;
        public static ObservableCollection<Word> Vocab
        {
            get
            {
                if (Vocabulary == null)
                {
                    Vocabulary = new ObservableCollection<Word>();
                }
                return Vocabulary;
            }
            set
            {
                Vocabulary = value;
            }
        }


        static Dictionary<string, ObservableCollection<Word>> _Dictionary;
        public static Dictionary<string, ObservableCollection<Word>> Dict
        {
            get
            {
                if (_Dictionary == null)
                {
                    _Dictionary = new Dictionary<string, ObservableCollection<Word>>();
                }
                return _Dictionary;
            }
            set
            {
                _Dictionary = value;
            }
        }


        static ObservableCollection<Word> HiraKata;
        public static ObservableCollection<Word> HK
        {
            get
            {
                if (HiraKata == null)
                {
                    HiraKata = new ObservableCollection<Word>();
                }
                return HiraKata;
            }
            set
            {
                HiraKata = value;
            }
        }

        public static bool _done { get; set; }
        public static Test test;
        private static int counter;

        public App()
        {
            InitializeComponent();
            HiraKataLoad();
            _done = false;
        }

        protected override void OnStart()
        {
            SaveOrLoad(false);
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new TestPage();
        }

        public static void SaveOrLoad(bool choice)
        {
            if (choice)
            {
                Application.Current.Properties["counter"] = Vocab.Count;
                for (int i = 0; i < Vocab.Count; i++)
                {
                    Application.Current.Properties["jap" + i.ToString()] = Vocab[i].jap;
                    Application.Current.Properties["rus" + i.ToString()] = Vocab[i].rus;
                    Application.Current.Properties["trans" + i.ToString()] = Vocab[i].trans;
                }
                Application.Current.SavePropertiesAsync();
            }
            else
            {
                object tmp;
                if (Application.Current.Properties.TryGetValue("counter", out tmp))
                {
                    counter = (int)tmp;

                    for(int i = 0; i < counter; i++)
                    {
                        Word tmpW = new Word() { jap = Application.Current.Properties["jap" + i.ToString()].ToString(), trans = Application.Current.Properties["trans" + i.ToString()].ToString(), rus = Application.Current.Properties["rus" + i.ToString()].ToString() };
                        Vocab.Add(tmpW);
                    }
                }
            }
        }
        public static void Update(Word _old, Word _new)
        {
            if (_old == null)
            {
                Vocab.Add(_new);
            }
            else
            {
                int index = Vocab.IndexOf(_old);
                Vocab[index] = _new;
            }
        }
        void HiraKataLoad()
        {
            Dict.Add("h_a", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "あ", rus = "a", trans = "" },
                                                                            new Word { jap = "い", rus = "i", trans = "" },
                                                                            new Word { jap = "う", rus = "u", trans = "" },
                                                                            new Word { jap = "え", rus = "e", trans = "" },
                                                                            new Word { jap = "お", rus = "o", trans = "" }}));
            Dict.Add("h_ka", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "か", rus = "ka", trans = "" },
                                                                            new Word { jap = "き", rus = "ki", trans = "" },
                                                                            new Word { jap = "く", rus = "ku", trans = "" },
                                                                            new Word { jap = "け", rus = "ke", trans = "" },
                                                                            new Word { jap = "こ", rus = "ko", trans = "" }}));
            Dict.Add("h_sa", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "さ", rus = "sa", trans = "" },
                                                                            new Word { jap = "し", rus = "shi", trans = "" },
                                                                            new Word { jap = "す", rus = "su", trans = "" },
                                                                            new Word { jap = "せ", rus = "se", trans = "" },
                                                                            new Word { jap = "そ", rus = "so", trans = "" }}));
            Dict.Add("h_ta", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "た", rus = "ta", trans = "" },
                                                                            new Word { jap = "ち", rus = "chi", trans = "" },
                                                                            new Word { jap = "つ", rus = "tsu", trans = "" },
                                                                            new Word { jap = "て", rus = "te", trans = "" },
                                                                            new Word { jap = "と", rus = "to", trans = "" }}));
            Dict.Add("h_na", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "な", rus = "na", trans = "" },
                                                                            new Word { jap = "に", rus = "ni", trans = "" },
                                                                            new Word { jap = "ぬ", rus = "nu", trans = "" },
                                                                            new Word { jap = "ね", rus = "ne", trans = "" },
                                                                            new Word { jap = "の", rus = "no", trans = "" }}));
            Dict.Add("h_ha", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "は", rus = "ha", trans = "" },
                                                                            new Word { jap = "ひ", rus = "hi", trans = "" },
                                                                            new Word { jap = "ふ", rus = "fu", trans = "" },
                                                                            new Word { jap = "へ", rus = "he", trans = "" },
                                                                            new Word { jap = "ほ", rus = "ho", trans = "" }}));
            Dict.Add("h_ma", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "ま", rus = "ma", trans = "" },
                                                                            new Word { jap = "み", rus = "mi", trans = "" },
                                                                            new Word { jap = "む", rus = "mu", trans = "" },
                                                                            new Word { jap = "め", rus = "me", trans = "" },
                                                                            new Word { jap = "も", rus = "mo", trans = "" }}));
            Dict.Add("h_yawan", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "や", rus = "ya", trans = "" },
                                                                            new Word { jap = "ゆ", rus = "yu", trans = "" },
                                                                            new Word { jap = "よ", rus = "yo", trans = "" },
                                                                            new Word { jap = "わ", rus = "wa", trans = "" },
                                                                            new Word { jap = "を", rus = "wo", trans = "" },
                                                                            new Word { jap = "ん", rus = "n", trans = "" }}));
            Dict.Add("h_ra", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "ら", rus = "ra", trans = "" },
                                                                            new Word { jap = "り", rus = "ri", trans = "" },
                                                                            new Word { jap = "る", rus = "ru", trans = "" },
                                                                            new Word { jap = "れ", rus = "re", trans = "" },
                                                                            new Word { jap = "ろ", rus = "ro", trans = "" }}));
            Dict.Add("h_ga", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "か゛", rus = "ga", trans = "" },
                                                                            new Word { jap = "き゛", rus = "gi", trans = "" },
                                                                            new Word { jap = "く゛", rus = "gu", trans = "" },
                                                                            new Word { jap = "け゛", rus = "ge", trans = "" },
                                                                            new Word { jap = "こ゛", rus = "go", trans = "" }}));
            Dict.Add("h_za", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "さ゛", rus = "za", trans = "" },
                                                                            new Word { jap = "し゛", rus = "ji", trans = "" },
                                                                            new Word { jap = "す゛", rus = "zu", trans = "" },
                                                                            new Word { jap = "せ゛", rus = "ze", trans = "" },
                                                                            new Word { jap = "そ゛", rus = "zo", trans = "" }}));
            Dict.Add("h_da", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "た゛", rus = "da", trans = "" },
                                                                            new Word { jap = "ち゛", rus = "ji", trans = "" },
                                                                            new Word { jap = "つ゛", rus = "zu", trans = "" },
                                                                            new Word { jap = "て゛", rus = "de", trans = "" },
                                                                            new Word { jap = "と゛", rus = "do", trans = "" }}));
            Dict.Add("h_ba", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "は゛", rus = "ba", trans = "" },
                                                                            new Word { jap = "ひ゛", rus = "bi", trans = "" },
                                                                            new Word { jap = "ふ゛", rus = "bu", trans = "" },
                                                                            new Word { jap = "へ゛", rus = "be", trans = "" },
                                                                            new Word { jap = "ほ゛", rus = "bo", trans = "" }}));
            Dict.Add("h_pa", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "は゜", rus = "pa", trans = "" },
                                                                            new Word { jap = "ひ゜", rus = "pi", trans = "" },
                                                                            new Word { jap = "ふ゜", rus = "pu", trans = "" },
                                                                            new Word { jap = "へ゜", rus = "pe", trans = "" },
                                                                            new Word { jap = "ほ゜", rus = "po", trans = "" }}));

            Dict.Add("k_a", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "ア", rus = "a", trans = "" },
                                                                            new Word { jap = "イ", rus = "i", trans = "" },
                                                                            new Word { jap = "ウ", rus = "u", trans = "" },
                                                                            new Word { jap = "エ", rus = "e", trans = "" },
                                                                            new Word { jap = "オ", rus = "o", trans = "" }}));
            Dict.Add("k_ka", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "カ", rus = "ka", trans = "" },
                                                                            new Word { jap = "キ", rus = "ki", trans = "" },
                                                                            new Word { jap = "ク", rus = "ku", trans = "" },
                                                                            new Word { jap = "ケ", rus = "ke", trans = "" },
                                                                            new Word { jap = "コ", rus = "ko", trans = "" }}));
            Dict.Add("k_sa", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "サ", rus = "sa", trans = "" },
                                                                            new Word { jap = "シ", rus = "shi", trans = "" },
                                                                            new Word { jap = "ス", rus = "su", trans = "" },
                                                                            new Word { jap = "セ", rus = "se", trans = "" },
                                                                            new Word { jap = "ソ", rus = "so", trans = "" }}));
            Dict.Add("k_ta", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "タ", rus = "ta", trans = "" },
                                                                            new Word { jap = "チ", rus = "chi", trans = "" },
                                                                            new Word { jap = "ツ", rus = "tsu", trans = "" },
                                                                            new Word { jap = "テ", rus = "te", trans = "" },
                                                                            new Word { jap = "ト", rus = "to", trans = "" }}));
            Dict.Add("k_na", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "ナ", rus = "na", trans = "" },
                                                                            new Word { jap = "ニ", rus = "ni", trans = "" },
                                                                            new Word { jap = "ヌ", rus = "nu", trans = "" },
                                                                            new Word { jap = "ネ", rus = "ne", trans = "" },
                                                                            new Word { jap = "ノ", rus = "no", trans = "" }}));
            Dict.Add("k_ha", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "ハ", rus = "ha", trans = "" },
                                                                            new Word { jap = "ヒ", rus = "hi", trans = "" },
                                                                            new Word { jap = "フ", rus = "fu", trans = "" },
                                                                            new Word { jap = "ヘ", rus = "he", trans = "" },
                                                                            new Word { jap = "ホ", rus = "ho", trans = "" }}));
            Dict.Add("k_ma", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "マ", rus = "ma", trans = "" },
                                                                            new Word { jap = "ミ", rus = "mi", trans = "" },
                                                                            new Word { jap = "ム", rus = "mu", trans = "" },
                                                                            new Word { jap = "メ", rus = "me", trans = "" },
                                                                            new Word { jap = "モ", rus = "mo", trans = "" }}));
            Dict.Add("k_yawan", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "ヤ", rus = "ya", trans = "" },
                                                                            new Word { jap = "ユ", rus = "yu", trans = "" },
                                                                            new Word { jap = "ヨ", rus = "yo", trans = "" },
                                                                            new Word { jap = "ワ", rus = "wa", trans = "" },
                                                                            new Word { jap = "ヲ", rus = "wo", trans = "" },
                                                                            new Word { jap = "ン", rus = "n", trans = "" }}));
            Dict.Add("k_ra", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "ラ", rus = "ra", trans = "" },
                                                                            new Word { jap = "リ", rus = "ri", trans = "" },
                                                                            new Word { jap = "ル", rus = "ru", trans = "" },
                                                                            new Word { jap = "ル", rus = "re", trans = "" },
                                                                            new Word { jap = "レ", rus = "ro", trans = "" }}));
            Dict.Add("k_ga", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "カ゛", rus = "ga", trans = "" },
                                                                            new Word { jap = "キ゛", rus = "gi", trans = "" },
                                                                            new Word { jap = "ク゛", rus = "gu", trans = "" },
                                                                            new Word { jap = "ケ゛", rus = "ge", trans = "" },
                                                                            new Word { jap = "コ゛", rus = "go", trans = "" }}));
            Dict.Add("k_za", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "サ゛", rus = "za", trans = "" },
                                                                            new Word { jap = "シ゛", rus = "ji", trans = "" },
                                                                            new Word { jap = "ス゛", rus = "zu", trans = "" },
                                                                            new Word { jap = "セ゛", rus = "ze", trans = "" },
                                                                            new Word { jap = "ソ゛", rus = "zo", trans = "" }}));
            Dict.Add("k_da", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "タ゛", rus = "da", trans = "" },
                                                                            new Word { jap = "チ゛", rus = "ji", trans = "" },
                                                                            new Word { jap = "ツ゛", rus = "zu", trans = "" },
                                                                            new Word { jap = "テ゛", rus = "de", trans = "" },
                                                                            new Word { jap = "ト゛", rus = "do", trans = "" }}));
            Dict.Add("k_ba", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "ハ゛", rus = "ba", trans = "" },
                                                                            new Word { jap = "ヒ゛", rus = "bi", trans = "" },
                                                                            new Word { jap = "フ゛", rus = "bu", trans = "" },
                                                                            new Word { jap = "ヘ゛", rus = "be", trans = "" },
                                                                            new Word { jap = "ホ゛", rus = "bo", trans = "" }}));
            Dict.Add("k_pa", new ObservableCollection<Word>(new List<Word>{ new Word { jap = "ハ゜", rus = "pa", trans = "" },
                                                                            new Word { jap = "ヒ゜", rus = "pi", trans = "" },
                                                                            new Word { jap = "フ゜", rus = "pu", trans = "" },
                                                                            new Word { jap = "ヘ゜", rus = "pe", trans = "" },
                                                                            new Word { jap = "ホ゜", rus = "po", trans = "" }}));
        }
    }
}
