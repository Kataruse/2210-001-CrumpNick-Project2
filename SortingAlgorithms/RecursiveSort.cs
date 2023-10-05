﻿///////////////////////////////////////////////////////////////////////////////
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
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class RecursiveSort<T> : ISort<T> where T : IComparable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stuff"></param>
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
        public static void QuickSort(List<int> stuff)
        {
            QuickSort(stuff, 0, stuff.Count - 1);
        }

        static void QuickSort(List<int> stuff, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int num = stuff[left];

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

            foreach (var item in stuff)
            {
                Console.Write(stuff[item] + ", ");
            }
            Console.WriteLine();
        }

        public static void QuickSort(List<Book> stuff)
        {
            QuickSort(stuff, 0, stuff.Count - 1);
        }

        static void QuickSort(List<Book> stuff, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            Book bookNum = stuff[left];

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

            foreach (var item in stuff)
            {
                Console.WriteLine();
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        static void Swap(List<int> stuff, int i, int j)
        {
            if (i == j)
                return;

            int temp = stuff[i];
            stuff[i] = stuff[j];
            stuff[j] = temp;
        }

        static void Swap(List<Book> stuff, int i, int j)
        {
            if (i == j)
                return;

            //Console.WriteLine($"Book 1 PreSwap is :\n {stuff[i].ToString()}");
            //Console.WriteLine($"Book 2 PreSwap is :\n {stuff[j].ToString()}");

            Book temp = stuff[i];
            stuff[i] = stuff[j];
            stuff[j] = temp;

            //Console.WriteLine($"Book 1 PostSwap is :\n {stuff[i].ToString()}");
            //Console.WriteLine($"Book 2 PostSwap is :\n {stuff[j].ToString()}");
        }
    }
}
