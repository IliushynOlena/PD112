using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_Graphics_GDI
{
    public partial class Form1 : Form
    {
        enum TypeShape {  Rectangle, Line , Ellipse}
        int redraw_count = 0;
        List<Point> points = new List<Point>();
        List<MyShape> shapes = new List<MyShape>();
        Point start;
        public Form1()
        {
            InitializeComponent();
            colorCb.Items.Add(Color.Red);
            colorCb.Items.Add(Color.Green);
            colorCb.Items.Add(Color.Blue);
            colorCb.Items.Add(Color.Pink);
            colorCb.SelectedIndex = 0;
            colorCb.Size = new Size(300, 100);

            foreach (var item in Enum.GetValues(typeof(TypeShape)))
            {
                figureCb.Items.Add(item);
            }
            figureCb.Size = new Size(300, 100);
            figureCb.SelectedIndex = 0;
        }

        private void drawBtn_Click(object sender, EventArgs e)
        {
            Graphics g =  this.CreateGraphics();
            Pen pen = new Pen(Brushes.Red, 6);
            Point point = new Point(10, 10);
            Size size = new Size(320, 320);
            Rectangle rect = new Rectangle(point, size);

            int x = 43, y = 53, heigth = 120, width = 120;
            Rectangle rect2 = new Rectangle(x,y, width, heigth);    
            g.FillEllipse(Brushes.Green, rect);

            g.DrawEllipse(pen, rect2);
        }

        private void PrintFigure(Graphics g)
        {
            foreach (var p in points)
            {
                g.FillEllipse(Brushes.Red, p.X - 15, p.Y - 15, 30, 30);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var s in shapes)
            {
                s.Draw(g);

            }

            //Create Line
            //PrintFigure(e.Graphics);


            //using (Graphics g = e.Graphics)
            //{
            //    Pen pen = new Pen(Color.Red, 16);
            //    pen.StartCap = System.Drawing.Drawing2D.LineCap.SquareAnchor;
            //    pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            //    pen.DashCap = System.Drawing.Drawing2D.DashCap.Triangle;

            //    g.DrawLine(pen, 50, 300, 600, 300);


            //    int x = 43, y = 53, heigth = 120, width = 120;
            //    Rectangle rect2 = new Rectangle(x, y, width, heigth);
            //    g.DrawEllipse(pen, rect2);

            //}

            //Draw Rectangle
            //this.Text = $" {redraw_count++}";
            //Graphics g = e.Graphics;
            //Pen pen = new Pen(Brushes.Red, 6);
            //Point point = new Point(10, 10);
            //Size size = new Size(320, 320);
            //Rectangle rect = new Rectangle(point, size);

            //int x = 43, y = 53, heigth = 120, width = 120;
            //Rectangle rect2 = new Rectangle(x, y, width, heigth);
            //g.FillEllipse(Brushes.Green, rect);

            //g.DrawEllipse(pen, rect2);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Point point = e.Location;
            //points.Add(point);

            //this.CreateGraphics().FillEllipse(Brushes.Red, point.X - 15, point.Y -15, 30, 30);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Point end = e.Location;
            Graphics g = this.CreateGraphics();
         
            Color color = (Color)colorCb.SelectedItem;
            SolidBrush brush = new SolidBrush(color);

            MyShape shape = null;
            var type = (TypeShape)figureCb.SelectedItem;
            if (type == TypeShape.Rectangle || type == TypeShape.Ellipse)
            {

                Rectangle rect = new Rectangle();
                rect.X = start.X < end.X ? start.X : end.X;
                rect.Y = start.Y < end.Y ? start.Y : end.Y;

                rect.Width = Math.Abs(e.X - start.X);
                rect.Height = Math.Abs(e.Y - start.Y);

                if(type == TypeShape.Rectangle)
                    shape = new MyRectangle(color, rect);
                else
                    shape = new MyEllipse(color, rect);
             
            }
            else if(type == TypeShape.Line)
            {
                shape = new MyLine(color, start, end);
               
            }
            shape.Draw(g);
            shapes.Add(shape);

        }
    }

    abstract class MyShape
    {
        public abstract void Draw(Graphics g);
    }

    class MyRectangle : MyShape
    {
        public Color Color { get; set; }
        public Rectangle Rectangle { get; set; }
        public MyRectangle()   {    }
        public MyRectangle(Color C, Rectangle R)
        {
            Color = C;
            Rectangle = R;
        }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color), Rectangle);
        }
    }

    class MyLine : MyShape
    {
        public Pen Pen { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public MyLine() {    }
        public MyLine(Color c, Point s, Point e)
        {
            Pen = new Pen(c);
            Start = s;
            End = e;
        }
        public override void Draw(Graphics g)
        {
            g.DrawLine(Pen, Start, End);
        }
    }
    class MyEllipse : MyRectangle
    {
      
        public MyEllipse() { }
        public MyEllipse(Color C, Rectangle R) : base (C, R) { }
       
        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color), Rectangle);
        }
    }
}   
