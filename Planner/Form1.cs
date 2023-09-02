using Microsoft.VisualBasic.ApplicationServices;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Planner
{
    public partial class Form1 : Form
    {
        public Form2 form2;
        public string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PlannerNoter save file");
        public Form1()
        {
            InitializeComponent();

            this.Load += Label_OnLoad;
            if (form2 == null)
            {
                form2 = new Form2(this);
            }

            if (!Directory.Exists(folderPath))
            {
                folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PlannerNoter save file");
                Directory.CreateDirectory(folderPath);
                MessageBox.Show("Folder created at: " + folderPath);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label_OnLoad(object sender, EventArgs e)
        {
            CultureInfo english = new CultureInfo("en-US");
            DateTime currentDate = DateTime.Now;
            int week = CalculateWeek(currentDate);
            string Date = currentDate.ToString($"Week {week}, dddd, MMMM d, yyyy", english);
            label1.Text = Date;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            form2.Show();
        }


        public TextBox[] getDaysStudy()
        {
            TextBox[] textboxes = new TextBox[7];
            textboxes[0] = textBox5;
            textboxes[1] = textBox8;
            textboxes[2] = textBox11;
            textboxes[3] = textBox14;
            textboxes[4] = textBox17;
            textboxes[5] = textBox20;
            textboxes[6] = textBox23;
            return textboxes;
        }

        public TextBox[] getDaysGain()
        {
            TextBox[] textboxes = new TextBox[7];
            textboxes[0] = textBox6;
            textboxes[1] = textBox9;
            textboxes[2] = textBox12;
            textboxes[3] = textBox15;
            textboxes[4] = textBox18;
            textboxes[5] = textBox21;
            textboxes[6] = textBox24;
            return textboxes;
        }

        public void setDaysStudy(string[] input)
        {
            TextBox[] textBoxes = { textBox5, textBox8, textBox11, textBox14, textBox17, textBox20, textBox23 };
            for (int i = 0; i < input.Length; i++)
            {
                textBoxes[i].Text = input[i];
            }
            // empty out any element higher than input's length
            if (input.Length < 6)
            {
                for (int i = input.Length; i <= 6; i++)
                {
                    textBoxes[i].Text = "";
                }
            }
        }
        public void setDaysGain(string[] input)
        {
            TextBox[] textBoxes = { textBox6, textBox9, textBox12, textBox15, textBox18, textBox21, textBox24 };
            for (int i = 0; i < input.Length; i++)
            {
                textBoxes[i].Text = input[i];
            }
            // empty out any element higher than input's length
            if (input.Length < 6)
            {
                for (int i = input.Length; i <= 6; i++)
                {
                    textBoxes[i].Text = "";
                }
            }
        }

        private void SaveAndLoad(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this, form2);
            form3.Show();
        }

        public int CalculateWeek(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int week = (date.Day + (int)firstDayOfMonth.DayOfWeek - 1) / 7 + 1;
            return week;
        }
    }
}