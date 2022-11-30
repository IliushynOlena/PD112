using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13_PictureBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //foreach (var item in this.Controls.OfType<PictureBox>())
            //{
            //    item.ImageLocation = @"https://images.unsplash.com/photo-1501183007986-d0d080b147f9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8ZnJlZXxlbnwwfHwwfHw%3D&w=1000&q=80";
            //}
            pictureBox1.ImageLocation = @"https://loremflickr.com/400/400";
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
           
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            PictureBox box = new PictureBox()
            {
                Location = new Point(new Random().Next(this.Width - 32) - 200, 0),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 200,
                Height = 200,
                ImageLocation = @"https://loremflickr.com/400/400"
            };

            this.Controls.Add(box);
            timer.Stop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if(!IsOutsideLeftBorder(new Point(x -5, y)))
                        x -= 5;
                    break;
                case Keys.Up:
                    y -= 5;
                    break;
                case Keys.Right:
                    if (!IsOutsideRightBorder(new Point(x + 5, y)))
                        x += 5;
                    else
                        x = this.Width - pictureBox1.Width - 32;//16
                    break;
                case Keys.Down:
                    y += 5;
                    break;              
            }
            pictureBox1.Location = new Point(x, y);

        }

        private bool IsOutsideLeftBorder(Point p)
        {
            return p.X < 0;
        }
        private bool IsOutsideRightBorder(Point p)
        {
            return p.X + pictureBox1.Width > this.Width - 32;//16
        }
    }
}
