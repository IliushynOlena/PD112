using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_ButtonsControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private bool IsSelectedMeal()
        {
            return (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked);
        }
        private void OrderButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if(!IsSelectedMeal())
            {
                MessageBox.Show("Select a meal....");
                return;
            }
          
            StringBuilder res = new StringBuilder( "------------Order----------------\n");//16
            if (checkBox1.Checked)
                res.Append("Breakfast ");
            if (checkBox2.Checked)
                res.Append("Lunch ");
            if (checkBox3.Checked)
                res.Append("Dinner ");//32
            res.AppendLine();
            res.Append("Delivery : ");
            if (radioButton1.Checked)
                res.Append("Economy");
            if (radioButton2.Checked)
                res.Append("Standart");//64

            if (radioButton3.Checked)
                res.Append("Premium");
            res.AppendLine();

            res.AppendLine("Login : " + textBox1.Text);
            res.AppendLine("Password : " + textBox2.Text);
            res.AppendLine("Phone : " + maskedTextBox1.Text);

            res.AppendLine("Date : " + dateTimePicker1.Value.ToString());
            res.AppendLine("From : " + monthCalendar1.SelectionStart);
            res.AppendLine("To : " + monthCalendar1.SelectionEnd);

            res.AppendLine("Count : " + numericUpDown1.Value);

            MessageBox.Show(res.ToString());
            button1.Enabled = true;
        }
    }
}
