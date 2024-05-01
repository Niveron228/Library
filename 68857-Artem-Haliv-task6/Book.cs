using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _68857_Artem_Haliv_task6
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }

        public Book(string title, string author, string category, string type)
        {
            Title = title;
            Author = author;
            Category = category;
            Type = type;
        }
        //btw i removed library class because it was useless.I hope it won't be a mistake)
  
            public virtual  void AddPaperBook(string title, string author, string category, string type, string isbn, int numberOfPages)
            {
                PaperBook paperBook = new PaperBook(title, author, category, type, isbn, numberOfPages);
                WriteToFile(paperBook);
            }

            public virtual void AddEBook(string title, string author, string category, string type, string format, double fileSize)
            {
                EBook eBook = new EBook(title, author, category, type, format, fileSize);
                WriteToFile(eBook);
            }

            public virtual void  AddAudioBook(string title, string author, string category, string type, string narrator, double duration)
            {
                AudioBook audioBook = new AudioBook(title, author, category, type, narrator, duration);
                WriteToFile(audioBook);
            }
        
        private void WriteToFile(Book book)
        {
            string filePath = "Library.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (book is PaperBook)
                {
                    PaperBook paperBook = (PaperBook)book;
                    writer.WriteLine($"{book.Title}${book.Author}${book.Category}${book.Type}${paperBook.ISBN}${paperBook.NumberOfPages}");
                }
                else if (book is EBook)
                {
                    EBook eBook = (EBook)book;
                    writer.WriteLine($"{book.Title}${book.Author}${book.Category}${book.Type}${eBook.Format}${eBook.FileSize}");
                }
                else if (book is AudioBook)
                {
                    AudioBook audioBook = (AudioBook)book;
                    writer.WriteLine($"{book.Title}${book.Author}${book.Category}${book.Type}${audioBook.Narrator}${audioBook.Duration}");
                }
            }
        }
    }
}
