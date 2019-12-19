using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetInfo
{
    public class DataAccess
    {
        public bool WriteToFile(List<Pet> pets)
        {
            bool result = false;

            try
            {
                using (StreamWriter sw = new StreamWriter("data.txt"))
                {

                    foreach (Pet pet in pets)
                    {
                        string temp = $"{ pet.Name}|{pet.Type}|{pet.FamilyName}|{pet.AgeInMonths}";
                        sw.WriteLine(temp);
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public List<Pet> ReadFromFile()
        {
            List<Pet> result = new List<Pet>();

            try
            {


                using (StreamReader sr = new StreamReader("data.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split('|');

                        Pet item = new Pet();

                        item.Name = values[0];
                        item.Type = values[1];
                        item.FamilyName = values[2];
                        item.AgeInMonths = int.Parse(values[3]);

                        result.Add(item);
                    }
                }
            }

            catch (Exception ex)
            {
                result = new List<Pet>();
            }

            return result;
        }

    }
}
