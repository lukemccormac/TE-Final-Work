using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Dynamit_Question_1
{
    class SearchWords
    {
        //Generate a count of the occurrences of each word for the text found in the file Paragraph.txt.
        //Output a list of words and counts in descending count order(word with highest count listed first).
        //Do not hesitate to search google for syntax related questions.

        public static int CountWordsInDocument()
        {
            int total = 0;
            string directory = @"C:\Users\lukem\Downloads\Paragraph.txt";

            using (StreamReader sr = new StreamReader(directory))
            {
                while (!sr.EndOfStream)
                {
                    string words = sr.ReadLine();
                    string[] splitWords = words.Split(new char[] { '.', ',', ' ', '?', '!' });
                    foreach (string item in splitWords)
                    {
                        total++;
                    }
                    return total;
                }
            }
            return 0;
        }
    }
}

