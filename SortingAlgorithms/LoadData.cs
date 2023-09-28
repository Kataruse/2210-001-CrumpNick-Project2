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
        public List<string> ParseBookDataFile(string fileName)
        {
            List<string> dataList = new List<string>();

            try
            {
                StreamReader rdr = new StreamReader($@"..\..\..\data\books\{fileName}");

                rdr.ReadLine();
                rdr.ReadLine();
                rdr.ReadLine();
                while (rdr.Peek() != -1)
                {
                    string nextLine = rdr.ReadLine();
                    string[] splitLine = nextLine.Split("|");
                    foreach (string data in splitLine)
                    {
                        if (
                            data != ""
                           )
                        dataList.Add(data.Trim());
                    }
                }
                dataList.RemoveAt(dataList.Count - 1);
                rdr.Close();

                return dataList;
            }
            catch
            {
                throw new FileLoadException();
            }
        }
    }
}
