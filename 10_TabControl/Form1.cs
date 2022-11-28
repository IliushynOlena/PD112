using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_TabControl
{
    public partial class Form1 : Form
    {
        public TextBox SelectedNameTb { 
            get 
            {
                foreach (var item in tabControl1.SelectedTab.Controls.OfType<TextBox>())
                {
                    if (item.Name == "nameTextBox")
                        return item;
                }
                return null;
            }
        }
        public Form1()
        {
            InitializeComponent();
            tabControl1.TabPages.Clear();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            nameTb.Clear();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           TabPage page = new TabPage($"New Tab {tabControl1.TabPages.Count + 1 }");
            page.UseVisualStyleBackColor = true;
            // label1
            // 
            Label mainlabel = new Label();
            mainlabel.AutoSize = true;
            mainlabel.Font = new System.Drawing.Font("Sitka Banner", 21.9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            mainlabel.Location = new System.Drawing.Point(475, 163);
            mainlabel.Size = new System.Drawing.Size(355, 106);
            mainlabel.Text = "Hello User";
            // 
            // label2
            // 
            Label namelabel = new Label();
            namelabel.AutoSize = true;
            namelabel.Location = new System.Drawing.Point(165, 388);
            namelabel.Size = new System.Drawing.Size(112, 41);
            namelabel.Text = "Name :";
            // 
            // nameTb
            // 
            TextBox nameText = new TextBox();   
            nameText.Location = new System.Drawing.Point(397, 382);
            nameText.Size = new System.Drawing.Size(537, 47);
            nameText.Name = "nameTextBox";
            // 
            // ClearBtn
            // 
            Button clearbutton = new Button();
            clearbutton.Location = new System.Drawing.Point(475, 526);
            clearbutton.Size = new System.Drawing.Size(355, 178);
            clearbutton.Text = "Clear";
            clearbutton.UseVisualStyleBackColor = true;
            clearbutton.Click += (s, args) => { nameText.Clear(); };


            page.Controls.Add(mainlabel);
            page.Controls.Add(namelabel);
            page.Controls.Add(nameText);
            page.Controls.Add(clearbutton);
            //TabPage page = new TabPage($"New Tab {tabControl1.TabCount + 1 }");
            tabControl1.TabPages.Add(page);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex != -1)
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
        }
      

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Name {SelectedNameTb.Text}");
        }
    }
}
