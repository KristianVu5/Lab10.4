using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Lab10._4
{
    internal class Program
    {
         class WordCounter
        {
            private readonly SortedDictionary<string, int> wordCounter = new SortedDictionary<string, int>();

            public int UniqueWords
            {
                get { return wordCounter.Count; }
            }

            public bool CountStats(string text, out long numWords, out long numChars)
            {
                numWords = 0;
                numChars = 0;
                wordCounter.Clear();

                if (string.IsNullOrWhiteSpace(text))
                    return false;

                string[] words = text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                numWords = words.Length;

                foreach(string word in words)
                {
                    numChars += word.Length;

                    if (wordCounter.ContainsKey(word))
                        wordCounter[word]++;
                    else
                        wordCounter.Add(word, 1);
                }
                return true;
            }

            public IEnumerable<KeyValuePair<string,int>> GetWordsAlphabetically()
            {
                return wordCounter;
            }

        }


        public static int Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Въведете текст:");
            string text = Console.ReadLine();

            WordCounter wc = new WordCounter();

            if (!wc.CountStats(text, out long numWords, out long numChars))
            {
                Console.WriteLine("Не е въведен текст.");
                return 0;
            }

            Console.WriteLine("\nВъведен текст:");
            Console.WriteLine(text);

            Console.WriteLine("\nСтатистика:");
            Console.WriteLine("Думи: {0}\tСимволи в думите: {1}",
                numWords, numChars);

            Console.WriteLine("\nСъдържание на колекцията:");
            Console.WriteLine("Дума\t\tБрой");

            foreach (KeyValuePair<string, int> item
                     in wc.GetWordsAlphabetically())
            {
                Console.WriteLine("{0,-16}\t{1}", item.Key, item.Value);
            }

            Console.WriteLine("\nБрой различни думи: {0}", wc.UniqueWords);

            Console.ReadLine();
            return 0;
        }
    }
}
