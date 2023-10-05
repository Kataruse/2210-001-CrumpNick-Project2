using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SortingAlgorithms
{
    internal class WriteData
    {
        /// <summary>
        /// Edits a csv file to create a log of all the data ran from this program
        /// </summary>
        /// <param name="fileName">name of the file ran by the sorting algorithm</param>
        /// <param name="dataType">data type of the file ran either Book or Integer</param>
        /// <param name="algorithm">type of algorithm ran either recursive or iterative</param>
        /// <param name="time">amount of time it took to finish sorting list</param>
        /// <exception cref="FileLoadException">file could not be read or isn't in the correct format to be written to</exception>
        public void WriteDataFile(string fileName, string dataType, string algorithm, long time)
        {
            try
            {
                StreamWriter rwr = new StreamWriter($@"..\..\..\data\output\spreadsheetData.csv", true);

                rwr.WriteLine($"{fileName}, {dataType}, {algorithm}, {time}");

                rwr.Flush();

                rwr.Close();
            }
            catch
            {
                throw new FileLoadException();
            }
        }
    }
}
