using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Note: the program only accepts lines from the console but could easily be adapted to parse files

            Console.WriteLine("Enter your string to be sorted");

            string input = Console.ReadLine();

            CustomSort(input);

        }

        //Strips string of all punctuation
        //Utilizes SortedDictionary inserts n times which each insert costing log(n)
        //This algorithm sacrifices space for efficiency 
        //
        //Note: bucket sort can also be used for O(n) but only in cases where n around the same number of buckets
        static void CustomSort(string input)
        {
            input = new string(input.Where(char.IsLetter).ToArray());

            //Utilize SortedDictionary to insert in a sorted fashion
            SortedDictionary<char, int> list = new SortedDictionary<char, int>();

            
            foreach (char c in input.ToLower())
            {
                if (!list.ContainsKey(c))
                {
                    list.Add(c, 1);
                }
                else
                {
                    list[c]++;
                }
            }

            CustomPrint(list);

        }


        //append each key n times where n is the keypair value
        static void CustomPrint(SortedDictionary<char, int> list)
        {
            string sortedKeys = "";
            var index = 0;

            var keyList = list.Keys.ToList();
            while (index <= list.Count - 1)
            {
                if (list.ElementAt(index).Value == 0)
                {
                    index++;
                }
                else
                {
                    list[list.ElementAt(index).Key]--;
                    sortedKeys += keyList[index];
                }
            }

            Console.WriteLine(sortedKeys);
        }
    }
}
