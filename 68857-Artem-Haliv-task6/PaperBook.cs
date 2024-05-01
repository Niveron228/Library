using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _68857_Artem_Haliv_task6
{
    public class PaperBook : Book
    {
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }

        public PaperBook(string title, string author, string category, string type, string isbn, int numberOfPages)
            : base(title, author, category, type)
        {
            ISBN = isbn;
            NumberOfPages = numberOfPages;
        }
        public override void AddPaperBook(string title, string author, string category, string type, string isbn, int numberOfPages)
        {
            base.AddPaperBook(title, author, category, type, isbn, numberOfPages);
        }
    }
}
