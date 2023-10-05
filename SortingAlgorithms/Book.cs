
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SortingAlgorithms
{
    /// <summary>
    /// Creates Books to be added to a list to be sorted iteratively and recursively
    /// </summary>
    public class Book : IComparable<Book>
    {
        
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public string Title { get; set; }
        public DateOnly Date { get; set; }

        public Book()
        {
            AuthorLastName = "Gillenwater";
            AuthorFirstName = "Jacob";
            Title = "I Got A Haircut";
            Date = new DateOnly(1997, 6, 22);
        }

        /// <summary>
        /// creates a book object from a split data string to be added to a list to be sorted by a iterative and recursive algorithm
        /// </summary>
        /// <param name="authorLastName">Book's authors last name from data string</param>
        /// <param name="authorFirstName">Book's authors first name from data string</param>
        /// <param name="title">Book's title from data string</param>
        /// <param name="date">Book's release date from data string</param>
        public Book(string authorLastName, string authorFirstName, string title, DateOnly date)
        {
            AuthorLastName = authorLastName;
            AuthorFirstName = authorFirstName;
            Title = title;
            Date = date;
        }

        /// <summary>
        /// converts a string to a book to be added to a list of books
        /// </summary>
        /// <param name="str">a datastring containing all a books data</param>
        /// <returns>new Book object</returns>
        private Book Parse(string str)
        {
            string[] bookString = str.Split("/");
            Book book = new Book(bookString[0], bookString[1], bookString[2], DateOnly.Parse(bookString[3]));
            return book;
        }

        /// <summary>
        /// checks to make sure a data string can be converted to a Book then calls Parse() to create a Book for the Book List
        /// </summary>
        /// <param name="str">a datastring containing all a books data</param>
        /// <param name="book">Book object created from data string</param>
        /// <returns>true or false if the book can be parsed</returns>
        public bool TryParse(string str, out Book book)
        {
            try
            {
                string[] bookStringArray = new string[4];
                string[] splitLine = str.Split("|");
                int count = 0;
                for (int i = 0; i < splitLine.Length - 1; i++)
                {
                    if (splitLine[i] != "")
                    { 
                        if (count < 4)
                        {
                            bookStringArray[count] = splitLine[i].Trim();
                            count++;
                        }
                    }
                }
                string bookString = $"{bookStringArray[0]}/{bookStringArray[1]}/{bookStringArray[2]}/{bookStringArray[3]}";
                book = Parse(bookString);
                return true;
            }
            catch
            {
                book = null;
                return false;
            }
        }

        /// <summary>
        /// converts a book to a string to be displayed for testing purposes
        /// </summary>
        /// <returns>string of book's data</returns>
        public string ToString()
        {
            return $"{AuthorLastName}, {AuthorFirstName}, {Title}, {Date}";
        }

        /// <summary>
        /// compares the current book in the list to the next book in the list for sorting purposes
        /// </summary>
        /// <param name="other">Next book in list</param>
        /// <returns>-1 if the book needs to be ordered or 1 if the book is in the correct spot</returns>
        public int CompareTo(Book other)
        {

            if (string.Compare(AuthorLastName, other.AuthorLastName) > 0)
            {
                return -1;
            }
            else if (
                string.Compare(AuthorLastName, other.AuthorLastName) == 0 &&
                string.Compare(AuthorFirstName, other.AuthorFirstName) > 0
                )
            {
                return -1;
            }
            else if (
                string.Compare(AuthorLastName, other.AuthorLastName) == 0 &&
                string.Compare(AuthorFirstName, other.AuthorFirstName) == 0 &&
                string.Compare(Title, other.Title) > 0
                )
            {
                return -1;
            }
            else if (
                string.Compare(AuthorLastName, other.AuthorLastName) == 0 &&
                string.Compare(AuthorFirstName, other.AuthorFirstName) == 0 &&
                string.Compare(Title, other.Title) == 0 &&
                Date.CompareTo(other.Date) > 0
                )
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}