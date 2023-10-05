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

using System.Diagnostics;

namespace SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var iterativeSort = new IterativeSort<int>();
            var recursiveSort = new RecursiveSort<int>();
            var dataLoader = new LoadData();
            var dataWriter = new WriteData();

            //Below is for Integersa
            //START ITERATIVE SORT
            string fileName = "RandomOrder_100.txt";

            List<int> intData = dataLoader.ParseIntDataFile(fileName);
            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            iterativeSort.Sort(intData);
            
            stopWatch.Stop();
            Console.WriteLine("RunTime " + stopWatch.ElapsedMilliseconds + " ms");

            dataWriter.WriteDataFile(fileName,"Integer", "CocktailSort", stopWatch.ElapsedMilliseconds);

            //START RECURSIVE SORT

            stopWatch.Restart();
            stopWatch.Start();

            recursiveSort.Sort(intData);

            stopWatch.Stop();
            Console.WriteLine("RunTime " + stopWatch.ElapsedMilliseconds + " ms");

            dataWriter.WriteDataFile(fileName, "Integer", "QuickSort", stopWatch.ElapsedMilliseconds);
            

            //Below is for Books
            List<Book> bookData = dataLoader.ParseBookDataFile("AlmostInOrder_100.table.txt");
            foreach (Book book in bookData)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}