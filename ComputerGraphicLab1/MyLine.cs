using System;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace ComputerGraphicLab1
{

    class MyLine
    {
        public const double precision = 0.2;
        public Point start, end;
        public Pen myPen;
        public const int Radius = Form1.Radius;
        public Rule rule;
        public MyLine(Point start, Point end, Rule rule = null)
        {
            this.start = start;
            this.end = end;
            this.myPen = new Pen(Color.Black);
            this.rule = rule;
        }
        public void DrawMyLine(PaintEventArgs e, string btnName)
        {
            if (btnName == "system method")
            {
                e.Graphics.DrawLine(myPen, start, end);
            }
            else if (btnName == "bresenham method")
            {
                int d, dx, dy, ai, bi, xi, yi;
                int x = start.X, y = start.Y;
                xi = start.X < end.X ? 1 : -1;
                yi = start.Y < end.Y ? 1 : -1;
                dx = Math.Abs(end.X - start.X);
                dy = Math.Abs(end.Y - start.Y);

                e.Graphics.FillRectangle(myPen.Brush, x, y, 1, 1);
                if (dx > dy)
                {
                    ai = (dy - dx) * 2;
                    bi = dy * 2;
                    d = bi - dx;
                    while (x != end.X)
                    {
                        x += xi;

                        if (d >= 0)
                        {
                            y += yi;
                            d += ai;
                        }
                        else
                        {
                            d += bi;
                        }
                        e.Graphics.FillRectangle(myPen.Brush, x, y, 1, 1);
                    }
                }
                else
                {
                    ai = (dx - dy) * 2;
                    bi = dx * 2;
                    d = bi - dy;
                    while (y != end.Y)
                    {
                        y += yi;
                        if (d >= 0)
                        {
                            x += xi;
                            d += ai;
                        }
                        else
                        {
                            d += bi;
                        }
                        e.Graphics.FillRectangle(myPen.Brush, x, y, 1, 1);
                    }
                }
            }
            else if (btnName == "algorythm WU")
            {
            }
            e.Graphics.FillEllipse(Brushes.Green, start.X - Radius, start.Y - Radius, Radius + Radius, Radius + Radius);
            e.Graphics.DrawEllipse(myPen, start.X - Radius, start.Y - Radius, Radius + Radius, Radius + Radius);
            rule?.Draw(e, start, end);
        }
        public void changeDist(Point offset)
        {
            start.Offset(offset);
            end.Offset(offset);
        }
        public bool checkPressedLine(Point pt) =>
            distanceBetweenPoints(start, pt) + distanceBetweenPoints(end, pt) <= distanceBetweenPoints(start, end) + precision;
        
        public static double distanceBetweenPoints(Point a, Point b) =>
            Math.Sqrt(Math.Pow(b.X - a.X,2) + Math.Pow(b.Y - a.Y, 2));

        public Point midPoint() =>
            new Point((start.X + end.X)/2, (start.Y+end.Y)/2);
    }
}
