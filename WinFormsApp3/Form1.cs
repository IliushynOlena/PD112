using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        Point startLocation;
        public Form1()
        {
            InitializeComponent();
            startLocation = CSharpButton.Location;
        }

        private void ClickButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello Windows Form", "Congratulation !", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClickButton_MouseEnter(object sender, EventArgs e)
        {
            ClickButton.BackColor = Color.Cyan;
        }

        private void ClickButton_MouseLeave(object sender, EventArgs e)
        {
            ClickButton.BackColor = Color.Lime;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to close window?", "Question", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CSharpButton.Location = new Point(CSharpButton.Location.X + 2, CSharpButton.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CSharpButton.Location = new Point(CSharpButton.Location.X - 2, CSharpButton.Location.Y);

        }

        private void CSharpButton_Click(object sender, EventArgs e)
        {
            CSharpButton.Location = startLocation;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouse = e.Location;
            this.Text = $"Mouse Pisition : {e.X} : {e.Y} : {CSharpButton.Left} ";

            if(mouse.X >=  CSharpButton.Left && (mouse.X <= CSharpButton.Left + CSharpButton.Width ))
            {
                if(mouse.X >= CSharpButton.Left + (CSharpButton.Width)/2)
                {
                    CSharpButton.Left = CSharpButton.Left - 5;
                }
                else
                {
                    CSharpButton.Left = CSharpButton.Left + 5;
                }
            }
        }
    }
}
