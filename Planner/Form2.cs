using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Planner
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            CultureInfo english = new CultureInfo("en-US");
            int week = CalculateWeek(DateTime.Now);
            label1.Text = DateTime.Now.ToString($"Week {week}, dddd, MMMM d, yyyy", english);
        }

        private void Planner(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }
        private int CalculateWeek(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int week = (date.Day + (int)firstDayOfMonth.DayOfWeek - 1) / 7 + 1;
            return week;
        }

        private void SaveAndLoad(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(form1, this);
            form3.Show();
        }

        public RichTextBox GetNotes()
        {
            return richTextBox1;
        }
        public void setNotes(string input)
        {
            richTextBox1.Text = input;
        }

        private void Right(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(form1.folderPath);

            if (form1.currentIndex < files.Length - 1)
            {
                form1.currentIndex++;
            }
            string content = File.ReadAllText(files[form1.currentIndex]);
            string[] parts = content.Split(new[] { "Notes: ", "Study: ", "Gain: " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3)
            {
                string notes = parts[0];
                string study = parts[1];
                string gain = parts[2];
                // removes the white space
                notes = notes.Trim();
                study = study.Trim();
                gain = gain.Trim();

                // formatting study and gain strings into arrays of each string
                string[] studyStrings = study.Split('\n');
                string[] gainStrings = gain.Split('\n');


                // updating each element
                form1.setDaysStudy(studyStrings);
                form1.setDaysGain(gainStrings);
                setNotes(notes);
            }

        }

        private void Left(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(form1.folderPath);
            if (form1.currentIndex > 0)
            {
                form1.currentIndex--;
            }
            else
            {
                form1.currentIndex = 0;
            }
            string content = File.ReadAllText(files[form1.currentIndex]);
            string[] parts = content.Split(new[] { "Notes: ", "Study: ", "Gain: " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3)
            {
                string notes = parts[0];
                string study = parts[1];
                string gain = parts[2];
                // removes the white space
                notes = notes.Trim();
                study = study.Trim();
                gain = gain.Trim();

                // formatting study and gain strings into arrays of each string
                string[] studyStrings = study.Split('\n');
                string[] gainStrings = gain.Split('\n');


                // updating each element
                form1.setDaysStudy(studyStrings);
                form1.setDaysGain(gainStrings);
                setNotes(notes);
            }
        }
    }
}
