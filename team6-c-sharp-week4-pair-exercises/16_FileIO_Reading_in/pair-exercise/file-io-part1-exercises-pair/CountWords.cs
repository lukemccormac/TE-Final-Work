using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace file_io_part1_exercises_pair
{
    class CountWords
    {
        public static void CountWordsInDocument()
        {
            string directory = @"c:\\goodplace";
            string filename = "alice.txt";
            string fullPath = Path.Combine(directory, filename);
            List<string> allWords = new List<string>();
            int wordCount = 0;
            int num = 0;
            int voidCount = 0;

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine().Trim();
                        line.Replace('_', ' ');
                        line.Replace('-', ' ');
                        line.Replace('[', '(');
                        line.Replace(']', ')');
                        string[] result = line.Split(' ');
                        foreach (string n in result)
                        {
                            if (int.TryParse(n, out num))
                                if (num == int.Parse(n))
                                {
                                    voidCount++;
                                }
                        }
                        if (line == "")
                        {
                            voidCount++;
                        }
                        allWords.AddRange(result);
                        wordCount = allWords.Count;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Number of words in document: {0}", wordCount - voidCount);
        }
        public static void CountSentencesInDocument()
        {
            string directory = @"c:\\goodplace";
            string filename = "alice.txt";
            string fullPath = Path.Combine(directory, filename);
            List<string> allWords = new List<string>();
            int sentenceCount = 0;
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        line.Replace('_', ' ');
                        line.Replace('-', ' ');
                        line.Replace('[', '(');
                        line.Replace(']', ')');
                        for (int i = 2; i < line.Length; i++)
                        {
                            if ((char.IsWhiteSpace(line[i]) == true || line[i] == '"' || line[i] == ')') && (line[i-1] == '!' || line[i-1] == '?' || line[i-1] == '.') && char.IsLetter(line[i - 2]))
                            {
                                sentenceCount++;
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        Console.WriteLine("Number of sentences in document: {0}", sentenceCount);
            Console.ReadLine();
       } 
    }
}

