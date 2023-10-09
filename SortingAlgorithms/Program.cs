///////////////////////////////////////////////////////////////////////////////
//
// Author: Nicholas Crump, CRUMPNA@etsu.edu
//         Nicholas Trahan, TRAHANN@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Sorting Algorithms
// Description: This project is designed to be an exploration of sorting algorithms. Students are to determine
// the effectiveness of different sorting algorithms depending on the data being sorted. Variables
// of concern are the number of elements to sort, reference type vs value type, and O(n2) vs
// O(Lg(n)) algorithmic runtimes.Additionally, students must demonstrate their ability to
// experiment with data, collaborate with others, and present their findings.
//
///////////////////////////////////////////////////////////////////////////////

using System.Diagnostics;

namespace SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //INTEGER SORTING BELOW
            string fileName = "";
            fileName = "AlmostInOrder_10.txt"; for(int i = 0; i < 6; i++) {IntegerSort(fileName);}
            fileName = "AlmostInOrder_100.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "AlmostInOrder_1000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "AlmostInOrder_10000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "AlmostInOrder_100000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "InOrder_10.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "InOrder_100.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "InOrder_1000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "InOrder_10000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "InOrder_100000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "RandomOrder_10.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "RandomOrder_100.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "RandomOrder_1000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "RandomOrder_10000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "RandomOrder_100000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "ReverseOrder_10.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "ReverseOrder_100.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "ReverseOrder_1000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "ReverseOrder_10000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            fileName = "ReverseOrder_100000.txt"; for (int i = 0; i < 6; i++) { IntegerSort(fileName); }
            //BOOK SORTING BELOW
            fileName = "AlmostInOrder_10.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "AlmostInOrder_100.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "AlmostInOrder_1000.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "AlmostInOrder_10000.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "InOrder_10.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "InOrder_100.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "InOrder_1000.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "InOrder_10000.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "RandomOrder_10.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "RandomOrder_100.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "RandomOrder_1000.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "RandomOrder_10000.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "ReverseOrder_10.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "ReverseOrder_100.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "ReverseOrder_1000.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            fileName = "ReverseOrder_10000.table.txt"; for (int i = 0; i < 6; i++) { BookSort(fileName); }
            
        }

        /// <summary>
        /// Runs both Iterative and Recursive algorithms for integers for loging/testing purposes
        /// </summary>
        /// <param name="fileName">file to be accessed to pull data from</param>
        static void IntegerSort(string fileName)
        {
            var intIterativeSort = new IterativeSort<int>();
            var intRecursiveSort = new RecursiveSort<int>();
            var dataLoader = new LoadData();
            var dataWriter = new WriteData();
            Stopwatch stopWatch = new Stopwatch();
            List<int> intData = dataLoader.ParseIntDataFile(fileName);

            //START INTEGER ITERATIVE SORT
            stopWatch.Restart();
            stopWatch.Start();

            intIterativeSort.Sort(intData);

            stopWatch.Stop();

            dataWriter.WriteDataFile(fileName, "Integer", "CocktailSort", stopWatch.ElapsedMilliseconds);

            //START INTEGER RECURSIVE SORT
            stopWatch.Restart();
            stopWatch.Start();

            intRecursiveSort.Sort(intData);

            stopWatch.Stop();

            dataWriter.WriteDataFile(fileName, "Integer", "QuickSort", stopWatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Runs both Iterative and Recursive algorithms for Books for loging/testing purposes
        /// </summary>
        /// <param name="fileName">file to be accessed to pull data from</param>
        static void BookSort(string fileName)
        {
            var bookIterativeSort = new IterativeSort<Book>();
            var bookRecursiveSort = new RecursiveSort<Book>();
            var dataLoader = new LoadData();
            var dataWriter = new WriteData();
            Stopwatch stopWatch = new Stopwatch();
            List<Book> bookData = dataLoader.ParseBookDataFile(fileName);

            //START BOOK ITERATIVE SORT
            stopWatch.Restart();
            stopWatch.Start();

            bookIterativeSort.Sort(bookData);

            stopWatch.Stop();

            dataWriter.WriteDataFile(fileName, "Book", "CocktailSort", stopWatch.ElapsedMilliseconds);

            //START BOOK RECURSIVE SORT
            stopWatch.Restart();
            stopWatch.Start();

            bookRecursiveSort.Sort(bookData);

            stopWatch.Stop();

            dataWriter.WriteDataFile(fileName, "Book", "QuickSort", stopWatch.ElapsedMilliseconds);
        }
    }
}