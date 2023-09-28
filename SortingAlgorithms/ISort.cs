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
    /// outline for a sorting method for use with implementing many sorting algorithms
    /// </summary>
    /// <typeparam name="T">restricts the use of this to only datatypes that work with the IComparable interface</typeparam>
    internal interface ISort<T> where T : IComparable<T>
    {
        /// <summary>
        /// method that takes in a list and sorts it with an appropriate algorthim
        /// </summary>
        /// <param name="stuff">List of presumably unordered items</param>
        public void Sort(List<T> stuff);
    }
}
