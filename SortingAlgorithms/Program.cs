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

namespace SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var iterativeSort = new IterativeSort<int>();
            var dataLoader = new LoadData();
            List<int> intData = dataLoader.ParseIntDataFile("AlmostInOrder_100.txt");

            string dataString = "";

            foreach(int item in intData)
            {
                dataString += item + ", ";
            }

            Console.WriteLine(dataString + "\n");


            List<string> bookData = dataLoader.ParseBookDataFile("AlmostInOrder_100.table.txt");

            dataString = "";

            foreach (string item in bookData)
            {
                dataString += item + ", ";
            }

            Console.WriteLine(dataString);

            //iterativeSort.Sort(data);
            //recursiveSort.Sort(data);       
        }
    }
}