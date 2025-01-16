using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_OOP03.Part01
{
    internal class Book
    {
        //class is like a template or blueprint

        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public string BookAuthor { get; set; }

        //constructor
        public Book() //Paremeterless constructor: complier will not generate a constructor
        {

        }

        //constructor chaining
        public Book(int bookId)
        {
            BookId = bookId;
        }

        public Book(int bookId, string bookTitle) : this(bookId)
        {
            BookTitle = bookTitle;
        }

        public Book(int bookId, string bookTitle, string bookAuthor) : this(bookId,bookTitle)
        {
            BookAuthor = bookAuthor;
        }
    }
}
