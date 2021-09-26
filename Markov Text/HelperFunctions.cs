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

        public void ExecuteMarkovText(string[] words, int nGram)
        {
            if(nGram==0)
            {
                Console.WriteLine("Ngram can't more less than 1");
                return;
            }
            if(words.Length <= nGram)
            {
                Console.WriteLine("Amount of words can't be less or equal to nGram");
                return;
            }

            Random random = new((int)DateTime.UtcNow.Ticks);

            while (true)
            {
                var randomInt = random.Next(0, words.Length - 1 - nGram);

                for(int i=randomInt;i<randomInt+nGram;i++)
                {
                    Console.Write(words[i] + " ");
                }

                Thread.Sleep(1000);
            }
        }
    }
}
