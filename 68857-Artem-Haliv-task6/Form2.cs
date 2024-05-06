using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _68857_Artem_Haliv_task6
{
    public partial class Form2 : Form
    {


        public Form2()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            this.Size = new Size(725, 700);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbtype.SelectedItem.ToString())
            {
                case "Paper book":
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false; break;
                case "e-book":
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = false; break;
                case "audio book":
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = true; break;

            }
        }

        private void buttonpaper_Click_1(object sender, EventArgs e)
        {
            PaperBook pb = new PaperBook(
                tbtitle.Text,
                tbauthor.Text,
                tbcategory.Text,
                cbtype.SelectedItem.ToString(),
                tbisbn.Text,
                int.Parse(tbpages.Text)
            );

            pb.AddPaperBook(pb.Title, pb.Author, pb.Category, pb.Type, pb.ISBN, pb.NumberOfPages);

            MessageBox.Show("PaperBook added successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void buttonebook_Click_1(object sender, EventArgs e)
        {
            EBook eb = new EBook(
                tbtitle.Text,
                tbauthor.Text,
                tbcategory.Text,
                cbtype.SelectedItem.ToString(),
                tbformat.Text,
                int.Parse(tbsize.Text)
            );

            eb.AddPaperBook(eb.Title, eb.Author, eb.Category, eb.Type, eb.Format, Convert.ToInt32(eb.FileSize));

            MessageBox.Show("E-Book added successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonaudio_Click_1(object sender, EventArgs e)
        {
            AudioBook ab = new AudioBook(
                tbtitle.Text,
                tbauthor.Text,
                tbcategory.Text,
                cbtype.SelectedItem.ToString(),
                tbnarrat.Text,
                int.Parse(tbdurat.Text)
            );
            ab.AddPaperBook(ab.Title, ab.Author, ab.Category, ab.Type, ab.Narrator, Convert.ToInt32(ab.Duration));

            MessageBox.Show("Audio Book added successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
