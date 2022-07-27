using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1
{
    public class Test
    {
        readonly Random rand = new Random();
        private List<Word> source;
        public Queue<Word> words;
        public List<Word> wrongWds;
        private Word tmp;
        public int counter;
        public int correct;
        public int incorrect;

        public delegate void GetWord(out string task, out string answer);
        public GetWord getWord;

        public Test(ObservableCollection<Word> _source)
        {
            source = new List<Word>(_source);
            words = new Queue<Word>();
            wrongWds = new List<Word>();
            counter = 0;
            correct = 0;
            incorrect = 0;
        }

        public void _init(bool isJap)
        {
            if (isJap)
            {
                getWord = GetRandomJap;
            }
            else
            {
                getWord = GetRandomRus;
            }
        }
        public string GetCorrectsPercentage()
        {
            if (counter == 0)
            {
                return "0%";
            }
            else
            {
                return (Math.Round((((double)correct / (double)counter) * (double)100))).ToString() + "%";
            }
        }
        private void GetRandomJap(out string task, out string answer)
        {
            if (words.Count == 0)
            {
                if (wrongWds.Count == 0)
                {
                    FisherYatesShuffle(" ");
                    foreach (var item in source)
                    {
                        words.Enqueue(item);
                    }
                }
                else if (wrongWds.Count > 0)
                {
                    FisherYatesShuffle("wrong");
                    foreach (var item in wrongWds)
                    {
                        words.Enqueue(item);
                    }
                    wrongWds.Clear();
                }

            }
            tmp = words.Dequeue();
            task = tmp.jap;
            answer = tmp.rus;
        }
        private void GetRandomRus(out string task, out string answer)
        {
            if (words.Count == 0)
            {
                if (wrongWds.Count == 0)
                {
                    FisherYatesShuffle(" ");
                    foreach (var item in source)
                    {
                        words.Enqueue(item);
                    }
                }
                else if (wrongWds.Count > 0)
                {
                    FisherYatesShuffle("wrong");
                    foreach (var item in wrongWds)
                    {
                        words.Enqueue(item);
                    }
                    wrongWds.Clear();
                }
                
            }
            tmp = words.Dequeue();
            task = tmp.rus;
            answer = tmp.jap;
        }
        public void Correct()
        {
            counter++;
            correct++;
        }
        public void Incorrect()
        {
            wrongWds.Add(tmp);
            counter++;
            incorrect++;
        }
        public void Reset()
        {
            counter = 0;
            correct = 0;
            incorrect = 0;
            tmp = null;
            words.Clear();
            wrongWds.Clear();
            source = null;
        }
        private void FisherYatesShuffle(string name)
        {
            if (name == "wrong")
            {
                int n = wrongWds.Count;
                while (n > 1)
                {
                    n--;
                    int k = rand.Next(n + 1);
                    var value = wrongWds[k];
                    wrongWds[k] = wrongWds[n];
                    wrongWds[n] = value;
                }
            }
            else
            {
                int n = source.Count;
                while (n > 1)
                {
                    n--;
                    int k = rand.Next(n + 1);
                    var value = source[k];
                    source[k] = source[n];
                    source[n] = value;
                }
            }
            
        }
    }
}
