using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _68857_Artem_Haliv_task6
{
    public class EBook : Book
    {
        public string Format { get; set; }
        public double FileSize { get; set; }

        public EBook(string title, string author, string category, string type, string format, double fileSize)
            : base(title, author, category, type)
        {
            Format = format;
            FileSize = fileSize;
        }
        public override void AddEBook(string title, string author, string category, string type, string format, double fileSize)
        {
            base.AddEBook(title, author, category, type, format, fileSize);
        }
    }


}

