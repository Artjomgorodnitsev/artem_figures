using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace artem_figures
{
    public partial class Form1 : Form
    {
        bool RectangleClicked, CircleClicked, SquareleClicked = false;
        int RectangleX, CircleX, SquareX, RectangleY, CircleY, SquareY = 0;
        int X, Y, dX, dY;
        int LastClicked = 0;
        

        Rectangle rectangle = new Rectangle(10, 10, 200, 100);
        Rectangle circle = new Rectangle(220, 10, 150, 150);
        Rectangle square = new Rectangle(380, 10, 150, 150);
        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.MouseMove += PictureBox1_MouseMove;

        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if((label1.Location.X < square.X + square.Width) && (label1.Location.X > square.X))
            {
                if((label1.Location.Y < square.Y + square.Height) && (label1.Location.Y > square.Y))
                {
                    label3.Text = "Синий квадрат";
                    label2.Text = "Квадрат";
                    label3.BackColor = Color.Blue;
                }
            }
            if ((label1.Location.X < rectangle.X + rectangle.Width) && (label1.Location.X > rectangle.X))
            {
                if ((label1.Location.Y < rectangle.Y + rectangle.Height) && (label1.Location.Y > rectangle.Y))
                {
                    label3.Text = "Жёлтый прямоугольник";
                    label2.Text = "Прямоугольник";
                    label3.BackColor = Color.Yellow;
                }
            }
            if ((label1.Location.X < circle.X + circle.Width) && (label1.Location.X > circle.X))
            {
                if ((label1.Location.Y < circle.Y + circle.Height) && (label1.Location.Y > circle.Y))
                {
                    label3.Text = "Красный круг";
                    label2.Text = "Круг";
                    label3.BackColor = Color.Red;
                }
            }
            if (RectangleClicked)
            {
                rectangle.X = e.X - RectangleX;
                rectangle.Y = e.Y - RectangleY;
            }
            if (CircleClicked)
            {
                circle.X = e.X - CircleX;
                circle.Y = e.Y - CircleY;
            }
            if (SquareleClicked)
            {
                square.X = e.X - SquareX;
                square.Y = e.Y - SquareY;
            }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            RectangleClicked = false;
            CircleClicked = false;
            SquareleClicked = false;


            if (LastClicked == 2)
            {
                if((label2.Location.X< circle.X + circle.Width) && (label2.Location.X > circle.X))
                {
                    if((label2.Location.Y < circle.Y + circle.Height) && (label2.Location.Y > circle.Y))
                    {
                        X = circle.X;
                        Y = circle.Y;
                        dX = CircleX;
                        dY = CircleY;

                        circle.X = square.X;
                        circle.Y = square.Y;
                        CircleX = SquareX;
                        CircleY = SquareY;

                        square.X = X;
                        square.Y = Y;
                        SquareX = dX;
                        SquareY = dY;

                    }
                }
            }
            

        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if((e.X <rectangle.X + rectangle.Width) && (e.X > rectangle.X))
            {
                if((e.Y < rectangle.Y + rectangle.Height) && (e.Y > rectangle.Y))
                {
                    RectangleClicked = true;

                    RectangleX = e.X - rectangle.X;
                    RectangleY = e.Y - rectangle.Y;
                }
            }
            if ((e.X < circle.X + circle.Width) && (e.X > circle.X))
            {
                if ((e.Y < circle.Y + circle.Height) && (e.Y > circle.Y))
                {
                    CircleClicked = true;

                    CircleX = e.X - circle.X;
                    CircleY = e.Y - circle.Y;
                }
            }
            if ((e.X < square.X + square.Width) && (e.X > square.X))
            {
                if ((e.Y < square.Y + square.Height) && (e.Y > square.Y))
                {
                    SquareleClicked = true;

                    SquareX = e.X - square.X;
                    SquareY = e.Y - square.Y;
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox1_Click(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, circle);
            e.Graphics.FillRectangle(Brushes.Blue, square);
            e.Graphics.FillRectangle(Brushes.Yellow, rectangle);
        }
    }
}
