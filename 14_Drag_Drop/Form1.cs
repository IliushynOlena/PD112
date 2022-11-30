using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_Drag_Drop
{
    public partial class Form1 : Form
    {
        bool isSelected = false;
        string selectedText = null;
        public Form1()
        {
            InitializeComponent();
            listBox1.AllowDrop = true;
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.Text) ||
                e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                listBox1.BackColor = Color.Orange;
            }

        }

        private void listBox1_DragLeave(object sender, EventArgs e)
        {
            listBox1.ResetBackColor();
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string item = e.Data.GetData(DataFormats.Text).ToString();
                listBox1.Items.Add(item);
            }
            else if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var item in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    listBox1.Items.Add(item);
                    File.OpenRead(item);
                }

            }
            listBox1.ResetBackColor();

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isSelected && textBox1.SelectionLength == 0)
                isSelected = true;
            else
            {
                textBox1.DoDragDrop(selectedText, DragDropEffects.Copy);
                isSelected = false;
            }

        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isSelected)
                selectedText = textBox1.SelectedText;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Context Menu");
        }
    }
}
