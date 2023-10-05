
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SortingAlgorithms
{
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

        public Book(string title, string authorLastName, string authorFirstName, DateOnly date)
        {
            AuthorLastName = authorLastName;
            AuthorFirstName = authorFirstName;
            Title = title;
            Date = date;
        }

        private Book Parse(string str)
        {
            string[] bookString = str.Split("/");
            Book book = new Book(bookString[0], bookString[1], bookString[2], DateOnly.Parse(bookString[3]));
            return book;
        }

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

        public string ToString()
        {
            return $"{AuthorLastName}, {AuthorFirstName}, {Title}, {Date}";
        }

        public int CompareTo(Book other)
        {

            if (
                string.Compare(AuthorLastName, other.AuthorLastName) < 0 || 
                string.Compare(AuthorFirstName, other.AuthorFirstName) < 0 ||
                string.Compare(Title, other.Title) < 0 ||
                Date.CompareTo(other.Date) < 0
                )
            {
                return -1;
            }
            else if (
                string.Compare(AuthorLastName, other.AuthorLastName) > 0 ||
                string.Compare(AuthorFirstName, other.AuthorFirstName) > 0 ||
                string.Compare(Title, other.Title) > 0 ||
                Date.CompareTo(other.Date) > 0
                )
            {
                return 1;
            }
            return 0;
        }
    }
}