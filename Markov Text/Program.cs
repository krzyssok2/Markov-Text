using System;
using System.Collections.Generic;

namespace MarkovText
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"D:\Users\MasterUser\Desktop\Information theory\Ipsum.txt";
            var nGram = 5;

            Console.WriteLine("Ksystof Stanislav Sokolovski Prifs 18/5 Markov Text \n");

            HelperFunctions functionService = new();

            var readFile = functionService.ReadFile(file);

            var filteredString = functionService.Filter(readFile);

            var words = filteredString.Split(' ');

            functionService.ExecuteMarkovText(words, nGram);
        }        
    }
}
