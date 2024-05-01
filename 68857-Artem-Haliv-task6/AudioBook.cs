using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _68857_Artem_Haliv_task6
{
   public class AudioBook : Book
    {
        public string Narrator { get; set; }
        public double Duration { get; set; }

        public AudioBook(string title, string author, string category, string type, string narrator, double duration)
            : base(title, author, category, type)
        {
            Narrator = narrator;
            Duration = duration;
        }
        public override void AddAudioBook(string title, string author, string category, string type, string narrator, double duration)
        {
            base.AddAudioBook(title, author, category, type, narrator, duration);
        }
    }
}
