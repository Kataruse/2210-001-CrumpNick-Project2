///////////////////////////////////////////////////////////////////////////////
//
// Author: Nicholas Crump, CRUMPNA@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Sorting Algorithms
// Description: This project is designed to be an exploration of sorting algorithms. Students are to determine
// the effectiveness of different sorting algorithms depending on the data being sorted. Variables
// of concern are the number of elements to sort, reference type vs value type, and O(n2) vs
// O(Lg(n)) algorithmic runtimes.Additionally, students must demonstrate their ability to
// experiment with data, collaborate with others, and present their findings.
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    /// <summary>
    /// Uses Cocktail Sort to sort a list of either books or integers to test the effectiveness of the algortihm
    /// </summary>
    /// <typeparam name="T">Book or Integer value</typeparam>
    internal class IterativeSort<T> : ISort<T> where T : IComparable<T>
    {
        /// <summary>
        /// checks for the correct variable type then sorts the list with cocktail sort
        /// </summary>
        /// <param name="stuff">List of Books or Integers to be sorted</param>
        public void Sort(List<T> stuff)
        {
            List<int> intDataSet = new List<int>();
            List<Book> BookDataSet = new List<Book>();

            try
            {
                for (int i = 0; i < stuff.Count; i++)
                {
                    intDataSet.Add(Convert.ToInt32(stuff[i]));
                }
                CocktailSort(intDataSet);
                return;
            }
            catch 
            {
                try
                {
                    foreach (var item in stuff)
                    {
                        if (item is Book bookItem)
                        {
                            BookDataSet.Add(bookItem);
                        }
                    }
                    CocktailSort(BookDataSet);
                }
                catch
                {
                    throw new InvalidCastException();
                }
                
            }
        }

        /// <summary>
        /// sorts the entire list using cocktail sort to test the effectiveness of the algorithm
        /// </summary>
        /// <param name="data">list of integers to be sorted</param>
        private void CocktailSort(List<int> data)
        {
            bool swapped = true;
            int start = 0;
            int end = data.Count;

            while (swapped == true)
            {
                string dataString = "";

                foreach (int item in data)
                {
                    dataString += item + "\n";
                }

                Console.WriteLine(dataString + "\n");

                swapped = false;
                for (int i = start; i < end - 1; ++i)
                {
                    if (data[i] > data[i + 1])
                    {
                        int temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
                swapped = false;
                end = end - 1;
                for (int i = end - 1; i >= start; i--)
                {
                    if (data[i] > data[i + 1])
                    {
                        int temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        swapped = true;
                    }
                }
                start = start + 1;
            }       
        }

        /// <summary>
        /// sorts the entire list using cocktail sort to test the effectiveness of the algorithm
        /// </summary>
        /// <param name="data">list of Books to be sorted</param>
        private void CocktailSort(List<Book> data)
        {
            bool swapped = true;
            int start = 0;
            int end = data.Count;

            while (swapped == true)
            {
                string dataString = "";

                foreach (Book item in data)
                {
                    dataString += item.ToString() + "\n";
                }

                Console.WriteLine(dataString + "\n");

                swapped = false;
                for (int i = start; i < end - 1; ++i)
                {
                    if (data[i].CompareTo(data[i+1]) == -1)
                    {
                        Book temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
                swapped = false;
                end = end - 1;
                for (int i = end - 1; i >= start; i--)
                {
                    if (data[i].CompareTo(data[i + 1]) == -1)
                    {
                        Book temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        swapped = true;
                    }
                }
                start = start + 1;
            }
        }
    }
}
