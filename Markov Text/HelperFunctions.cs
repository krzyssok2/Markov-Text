using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarkovText
{
    class HelperFunctions
    {
        public string ReadFile(string path)
        {
            return System.IO.File.ReadAllText(path).ToLower();
        }

        public string Filter(string str)
        {
            var charsToRemove = new List<char>()
            {
                '.', '?', '!', ',', ':', ':', '-','\r' ,'\n'
            };

            str = str.Replace("\r\n", " ");

            foreach (char c in charsToRemove)
            {
                if (c == '\n'|| c=='\r') 
                {
                    str = str.Replace(c.ToString(), " ");
                    continue;
                }
                str = str.Replace(c.ToString(), String.Empty);
            }

            return str;
        }

        public Dictionary<string, List<string>> BuildDictionary(string[] words)
        {
            var keyValuePairs = new Dictionary<string, List<string>>();

            for(int i=0;i<words.Length;i++)
            {
                if(i==words.Length-1)
                {
                    if (keyValuePairs.ContainsKey(words[i])) break;
                    keyValuePairs.Add(words[i], new List<string> { words[0] });
                    break;
                }
                if(!keyValuePairs.ContainsKey(words[i]))
                {
                    keyValuePairs.Add(words[i], new List<string> { words[i + 1] });
                }
                else
                {
                    var list = keyValuePairs[words[i]];
                    list.Add(words[i + 1]);
                    keyValuePairs[words[i]] = list;
                }
            }

            return keyValuePairs;
        }

        public void ExecuteMarkovText(string[] words, int nGram, Dictionary<string, List<string>> keyValuePairs)
        {
            if (nGram == 0)
            {
                Console.WriteLine("Ngram can't more less than 1");
                return;
            }
            if (words.Length <= nGram)
            {
                Console.WriteLine("Amount of words can't be less or equal to nGram");
                return;
            }

            Random random = new((int)DateTime.UtcNow.Ticks);

            while (true)
            {
                var randomInt = random.Next(0, words.Length - 1 - nGram);

                var word = words[randomInt];
                Console.Write(word + " ");
                for (int i = 0; i < nGram-1; i++)
                {
                    var nextWord = RandomWordFromTheList(keyValuePairs[word]);
                    Console.Write(nextWord + " ");
                    word = nextWord;
                }

                Thread.Sleep(100);
            }
        }

        private string RandomWordFromTheList(List<string> list)
        {
            var random = new Random((int)DateTime.Now.Ticks);

            var lenght = list.Count;

            var index = random.Next(0, lenght);

            return list[index];
            
        }
    }
}
