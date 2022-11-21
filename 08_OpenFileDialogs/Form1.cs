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

namespace _08_OpenFileDialogs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();

            if (color.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = color.Color;   
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if(font.ShowDialog() == DialogResult.OK)
            {
                var selected = font.Font;

                button1.Font = selected;
                button2.Font = selected;
                button3.Font = selected;
                button4.Font = selected;
                button5.Font = selected;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            openFileDialog.FilterIndex = 2;

            if(openFileDialog.ShowDialog()== DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                textBox1.Text = reader.ReadToEnd();
                reader.Close();               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.CreatePrompt = true;
            save.DefaultExt = ".txt";
            save.OverwritePrompt = true;

            if(save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                writer.Write(textBox1.Text);
                writer.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                foreach (var item in Directory.GetFiles(dialog.SelectedPath))
                {
                    listBox1.Items.Add(Path.GetFileName(item));
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(FontFamily.GenericMonospace,20,FontStyle.Bold);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.YellowGreen;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.Green;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent++;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionRightIndent++;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = checkBox1.Checked;
        }
        public string DescktopPath => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile(DescktopPath + @"\DOCUMENT.rtf", RichTextBoxStreamType.RichText);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(DescktopPath + @"\DOCUMENT.rtf", RichTextBoxStreamType.RichText);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //richTextBox1.SelectionFont = new Font(FontFamily.GenericMonospace, 20, FontStyle.Bold);
            FontDialog font = new FontDialog();
            if (font.ShowDialog()== DialogResult.OK)
            {
                richTextBox1.SelectionFont = font.Font;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Too
            this.Close();
        }
    }
}
