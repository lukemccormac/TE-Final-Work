using System;
using System.Collections.Generic;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //

            // Creating lists of integers
            List<int> nums = new List<int>();


            // Creating lists of strings
            List<string> strings = new List<string>();



            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////
            ///




            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            nums.Add(7);
            strings.Add(7.ToString());
            strings.Add("My Name");


            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////
            int[] values = { 34, 1, 4, 1, 5, 9, 2, 6 };
            nums.AddRange(values);


            //////////////////
            // ACCESSING BY INDEX
            //////////////////

            Console.WriteLine(nums[0]);


            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////
            ///
            foreach(int item in nums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////


            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////

            nums.Sort();
            foreach (int item in nums)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();


            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.


            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            ///

            Queue<int> numbers = new Queue<int>();
            numbers.Enqueue(3);
            numbers.Enqueue(1);
            numbers.Enqueue(4);

            while (numbers.Count > 0)
            {
                int temp = numbers.Dequeue();
                Console.WriteLine(temp);
            }





            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 


            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 
            Stack<string> names = new Stack<string>();

            names.Push("Primrose");
            names.Push("Penny");
            names.Push("Gabe");


            ////////////////////
            // POPPING THE STACK
            ////////////////////

            while(names.Count > 0)
            {
                Console.WriteLine(names.Pop());
            }

            Console.ReadLine();

        }
    }
}
