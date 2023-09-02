using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Planner
{
    public partial class Form3 : Form
    {
        private Form1 mainForm1;
        private Form2 mainForm2;
        public string folderPath;
        public Form3(Form1 form1, Form2 form2)
        {
            InitializeComponent();
            mainForm1 = form1;
            mainForm2 = form2;

            label3.Text = "Week " + CalculateWeek(dateTimePicker1.Value);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Save(object sender, EventArgs e)
        {
            int week = CalculateWeek(dateTimePicker1.Value);
            string dateSave = $"week{week}_" + dateTimePicker1.Value.ToString("yyyyMM");
            string fileName = $"{dateSave}.txt";

            string NotesSave = mainForm2.GetNotes().Text;
            string[] daysStudy = new string[7];
            string[] daysGain = new string[7];
            for (int i = 0; i <= 6; i++)
            {
                TextBox[] textboxes = mainForm1.getDaysStudy();
                daysStudy[i] = textboxes[i].Text;
            }
            for (int i = 0; i <= 6; i++)
            {
                TextBox[] textboxes = mainForm1.getDaysGain();
                daysGain[i] = textboxes[i].Text;
            }

            string content = "";
            content += "Notes: \n";
            content += NotesSave + "\n";
            content += "Study: \n";
            for (int i = 0; i <= 6; i++)
            {
                content += daysStudy[i] + "\n";
            }
            content += "Gain: \n";
            for (int i = 0; i <= 6; i++)
            {
                content += daysGain[i] + "\n";
            }
            // Full path to save the file
            string filePath = Path.Combine(mainForm1.folderPath, fileName);
            // Save the file
            File.WriteAllText(filePath, content);

            // Display a message (optional)
            MessageBox.Show($"File saved as {fileName}", "File Saved", MessageBoxButtons.OK);
        }

        private void Load(object sender, EventArgs e)
        {
            int week = CalculateWeek(dateTimePicker1.Value);
            string dateLoad = $"week{week}_" + dateTimePicker1.Value.ToString("yyyyMM");
            string[] files = Directory.GetFiles(mainForm1.folderPath);
            bool isFound = false;
            string loadFile;
            foreach(string file in files)
            {
                if (file.Contains(dateLoad))
                {
                    isFound = true;
                    string content = File.ReadAllText(file);
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
                        mainForm1.setDaysStudy(studyStrings);
                        mainForm1.setDaysGain(gainStrings);
                        mainForm2.setNotes(notes);
                        MessageBox.Show("Loaded save file on " + dateLoad, "File Loaded", MessageBoxButtons.OK);
                    }
                }
            }
            if (!isFound)
            {
                MessageBox.Show("Save file could not be located on " + dateLoad, "File does not exist", MessageBoxButtons.OK, MessageBoxIcon.Warning) ;
            }
        }
        private int CalculateWeek(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int week = (date.Day + (int)firstDayOfMonth.DayOfWeek - 1) / 7 + 1;
            return week;
        }

        private void UpdateWeek(object sender, EventArgs e)
        {
            label3.Text = "Week " + CalculateWeek(dateTimePicker1.Value);
        }
    }
}
