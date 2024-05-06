using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace _68857_Artem_Haliv_task6
{
    public partial class Form3 : Form
    {
        private int rowindex = 0;
        private int totalLines = 0;
        private bool isFirstButtonClick=true;

        public Form3()
        {
            InitializeComponent();
            this.Height += 100;
            tbauthor.Enabled = false;
            tbcategory.Enabled = false;
            tbval1.Enabled = false;
            tbval2.Enabled = false;
            tbtitle.Enabled = false;
            tbtype.Enabled = false;
            string filePath = "library.txt";
            totalLines = File.ReadAllLines(filePath).Length;
            rowindex = 1;
            DisplayRow(rowindex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isFirstButtonClick)
            {
                button5.Text = "Apply";
                tbauthor.Enabled = true;
                tbcategory.Enabled = true;
                tbval1.Enabled = true;
                tbval2.Enabled = true;
                tbtitle.Enabled = true;
                isFirstButtonClick = false;
            }
            else
            {


                if (rowindex >= 1 && rowindex <= totalLines)
                {
                    string newTitle = tbtitle.Text;
                    string newAuthor = tbauthor.Text;
                    string newCategory = tbcategory.Text;
                    string newType = tbtype.Text;
                    string newVal1 = tbval1.Text;
                    string newVal2 = tbval2.Text;
                    string filePath = "library.txt";
                    string[] lines = File.ReadAllLines(filePath);
                    string currentLine = lines[rowindex - 1];
                    string[] words = currentLine.Split('$');
                    if (words.Length >= 6)
                    {
                        words[0] = newTitle;
                        words[1] = newAuthor;
                        words[2] = newCategory;
                        words[3] = newType;
                        words[4] = newVal1;
                        words[5] = newVal2;
                        lines[rowindex - 1] = string.Join("$", words);
                        File.WriteAllLines(filePath, lines);
                        MessageBox.Show("Row has been updated successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect index", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DisplayRow(int index)
        {
            if(rowindex == 1)
            {
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else if(rowindex == totalLines)
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else if(rowindex != 1 && rowindex != totalLines)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            string filePath = "library.txt";
            string[] lines = File.ReadAllLines(filePath);
            if (index >= 1 && index <= totalLines)
            {
                string currentLine = lines[index - 1];
                string[] words = currentLine.Split('$');
                if (words.Length >= 6)
                {
                    tbtitle.Text = words[0];
                    tbauthor.Text = words[1];
                    tbcategory.Text = words[2];
                    tbtype.Text = words[3];
                    tbval1.Text = words[4];
                    tbval2.Text = words[5];
                    lblindex.Text = $"{index}/{totalLines}";
                    if (words[3] == "Paper book")
                    {
                        lbval1.Text = "ISBN:";
                        lbval2.Text = "Pages:";
                    }
                    else if (words[3] == "e-book")
                    {
                        lbval1.Text = "Format:";
                        lbval2.Text = "Duration:";
                    }
                    else if (words[3] == "audio book")
                    {
                        lbval1.Text = "Narrator:";
                        lbval2.Text = "Duration:";
                    }
                }
                else
                {
                    MessageBox.Show("Invalid line format in the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rowindex < totalLines)
            {
                rowindex++;
                DisplayRow(rowindex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rowindex > 1)
            {
                rowindex--;
                DisplayRow(rowindex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int lineNumberToRemove = rowindex;
            string filePath = "library.txt";
            string tempFilePath = "Temp.txt";

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                using (StreamWriter sw = new StreamWriter(tempFilePath))
                {
                    string line;
                    int lineNumber = 1;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (lineNumber != lineNumberToRemove)
                        {
                            sw.WriteLine(line);
                        }
                        lineNumber++;
                    }
                }
                File.Delete(filePath);
                File.Move(tempFilePath, filePath);
                rowindex--;
                totalLines--;
                lblindex.Text = $"{rowindex}/{totalLines}";
                DisplayRow(rowindex);
                MessageBox.Show("Row has been deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


