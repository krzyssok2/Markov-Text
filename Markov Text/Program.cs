using System;
using System.Collections.Generic;

namespace MarkovText
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"";
            var nGram = 50;

            HelperFunctions functionService = new();

            var readFile = functionService.ReadFile(file);

            var filteredString = functionService.Filter(readFile);

            var words = filteredString.Split(' ');

            var dictionary = functionService.BuildDictionary(words);

            functionService.ExecuteMarkovText(words, nGram, dictionary);
        }        
    }
}
