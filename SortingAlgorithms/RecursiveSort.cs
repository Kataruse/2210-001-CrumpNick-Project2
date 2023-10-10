///////////////////////////////////////////////////////////////////////////////
//
// Author: Nicholas Trahan, TRAHANN@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Sorting Algorithms
// Description: This project is designed to be an exploration of sorting algorithms. Students are to determine
// the effectiveness of different sorting algorithms deprighting on the data being sorted. Variables
// of concern are the number of elements to sort, reference type vs value type, and O(n2) vs
// O(Lg(n)) algorithmic runtimes.Additionally, students must demonstrate their ability to
// experiment with data, collaborate with others, and present their findings.
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    /// <summary>
    /// Sorts the test data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class RecursiveSort<T> : ISort<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts by calling QuickSort
        /// </summary>
        /// <param name="stuff">List of T</param>
        public void Sort(List<T> stuff)
        {
            List<int> listInt = new List<int>();
            List<Book> listBook = new List<Book>();

            try
            {
                for (int i = 0; i < stuff.Count; i++)
                {
                    listInt.Add(Convert.ToInt32(stuff[i]));
                }
                QuickSort(listInt, 0, listInt.Count - 1);
                return;
            }
            catch
            {
                try
                {
                    foreach (var i in stuff)
                    {
                        if (i is Book bookItem)
                        {
                            listBook.Add(bookItem);
                        }
                    }
                    QuickSort(listBook, 0, listBook.Count() - 1);
                }
                catch
                {
                    throw new InvalidCastException();
                }
            }
        }



        //https://codereview.stackexchange.com/questions/142808/quick-sort-algorithm

        /// <summary>
        /// Sets up QuickSort (INT) to be used Recursivly
        /// </summary>
        /// <param name="stuff">Int List</param>
        public static void QuickSort(List<int> stuff)
        {
            QuickSort(stuff, 0, stuff.Count - 1);
        }

        /// <summary>
        /// Quickly Sorts the Int Data by iterating through it by different pivot points
        /// </summary>
        /// <param name="stuff">Int List</param>
        /// <param name="left">Left Pivot Point</param>
        /// <param name="right">Pivot Point</param>
        static void QuickSort(List<int> stuff, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int num = stuff[left + (right - left) / 2];

            int i = left - 1;
            int j = right + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (stuff[i] < num);

                do
                {
                    j--;
                } while (stuff[j] > num);

                if (i >= j)
                    break;

                Swap(stuff, i, j);
            }

            //a[i] = num;
            QuickSort(stuff, left, j);
            QuickSort(stuff, j + 1, right);

        }

        public static void QuickSort(List<Book> stuff)
        {
            QuickSort(stuff, 0, stuff.Count - 1);
        }

        /// <summary>
        /// Quickly Sorts the Book Data by iterating through it by different pivot points
        /// </summary>
        /// <param name="stuff">Book List</param>
        /// <param name="left">Left Pivot Point</param>
        /// <param name="right">Pivot Point</param>
        static void QuickSort(List<Book> stuff, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            Book bookNum = stuff[left + (right - left) / 2];

            int i = left - 1;
            int j = right + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (stuff[i].CompareTo(bookNum) < 0);

                do
                {
                    j--;
                } while (stuff[j].CompareTo(bookNum) > 0);


                if (i >= j)
                    break;

                //Swap(stuff, i, j);
                (stuff[i], stuff[j]) = (stuff[j], stuff[i]);
            }

            QuickSort(stuff, left, j);
            QuickSort(stuff, j + 1, right);

        }

        /// <summary>
        /// Swaps the two data points
        /// </summary>
        /// <param name="stuff">Int List</param>
        /// <param name="i">First Item</param>
        /// <param name="j">Second Item</param>
        static void Swap(List<int> stuff, int i, int j)
        {
            if (i == j)
                return;

            int temp = stuff[i];
            stuff[i] = stuff[j];
            stuff[j] = temp;
        }


        /// <summary>
        /// Swaps the two data points
        /// </summary>
        /// <param name="stuff">Book List</param>
        /// <param name="i">First Item</param>
        /// <param name="j">Second Item</param>
        static void Swap(List<Book> stuff, int i, int j)
        {
            if (i == j)
                return;

            Book temp = stuff[i];
            stuff[i] = stuff[j];
            stuff[j] = temp;

        }
    }
}
