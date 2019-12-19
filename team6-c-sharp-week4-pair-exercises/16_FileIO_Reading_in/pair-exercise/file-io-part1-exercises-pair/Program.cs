using System;

namespace file_io_part1_exercises_pair
{
    class Program : CountWords
    {
        static void Main(string[] args)
        {
            CountWords.CountWordsInDocument();
            CountWords.CountSentencesInDocument();
        }
    }
}
