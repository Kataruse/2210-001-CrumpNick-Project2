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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    /// <summary>
    /// Reads data files and creates a list of data to be sorted
    /// </summary>
    internal class LoadData
    {
        /// <summary>
        /// Parses the data file and returns a list of integers to be sorted
        /// </summary>
        /// <param name="fileName">string of a fileName in the data file</param>
        /// <returns>list of integers created from parsing the individual string lines from the data file</returns>
        /// /// <exception cref="FileLoadException">file could not be read or isn't in the correct format to be read</exception>
        public List<int> ParseIntDataFile(string fileName)
        {
            List<int> dataList = new List<int>();

            try
            {
                StreamReader rdr = new StreamReader($@"..\..\..\data\integers\{fileName}");

                while (rdr.Peek() != -1)
                {
                    string nextLine = rdr.ReadLine();
                    string[] splitLine = nextLine.Split(",");
                    foreach (string data in splitLine)
                    {
                        try
                        {
                            dataList.Add(Convert.ToInt32(data));
                        }
                        catch
                        {
                            throw new ArithmeticException();
                        }
                    }
                }
                rdr.Close();

                return dataList;
            }
            catch
            {
                throw new FileLoadException();
            }
        }

        /// <summary>
        /// Parses the data file and returns a list of strings to be sorted
        /// </summary>
        /// <param name="fileName">string of a fileName in the data file</param>
        /// <returns>list of strings created from parsing the individual string lines from the data file</returns>
       public List<Book> ParseBookDataFile(string fileName)
        {
            List<Book> bookList = new List<Book>();

            try
            {
                StreamReader rdr = new StreamReader($@"..\..\..\data\books\{fileName}");

                rdr.ReadLine();
                rdr.ReadLine();
                rdr.ReadLine();
                while (rdr.Peek() == 124)
                {
                    var book = new Book();
                    string nextLine = rdr.ReadLine();
                    if (book.TryParse(nextLine, out book))
                    {
                        bookList.Add(book);
                    }

                }
                rdr.Close();
                return bookList;
            }
            catch
            {
                throw new FileLoadException();
            }
        }
    }
}
