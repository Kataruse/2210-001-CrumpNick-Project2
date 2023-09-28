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
using System.Linq;
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
            //Cocktail Sort
        }
    }
}
