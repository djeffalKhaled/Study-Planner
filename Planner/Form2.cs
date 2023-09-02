using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            CultureInfo english = new CultureInfo("en-US");
            int week = form1.CalculateWeek(DateTime.Now);
            label1.Text = DateTime.Now.ToString($"Week {week}, dddd, MMMM d, yyyy", english);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public RichTextBox GetNotes()
        {
            return richTextBox1;
        }
        public void setNotes(string input)
        {
            richTextBox1.Text = input;
        }

        private void Planner(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void SaveAndLoad(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(form1, this);
            form3.Show();
        }

       
    }
}
