using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphicLab1
{

    class MyLine
    {
        public const double precision = 0.2;
        public Point start, end;
        public Pen myPen;
        public const int Radius = Form1.Radius;
        public MyLine(Point start, Point end)
        {
            this.start = start;
            this.end = end;
            this.myPen = new Pen(Color.Black);
        }
        public void DrawMyLine(PaintEventArgs e, bool systemMethod)
        {
            if (systemMethod)
            {
                e.Graphics.DrawLine(myPen, start, end);
            }
            else
            {
                int x = start.X, y = start.Y, x2 = end.X, y2 = end.Y;
                int w = x2 - x;
                int h = y2 - y;
                int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
                if (w < 0) {
                    dx1 = -1;
                    dx2 = -1;
                }
                else if (w > 0) {
                    dx1 = 1;
                    dx2 = 1;
                }
                if (h < 0) dy1 = -1; 
                else if (h > 0) dy1 = 1;
                int longest = Math.Abs(w);
                int shortest = Math.Abs(h);
                if (!(longest > shortest))
                {
                    longest = Math.Abs(h);
                    shortest = Math.Abs(w);
                    if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                    dx2 = 0;
                }
                int numerator = longest / 2;
                for (int i = 0; i <= longest; i++)
                {
                    e.Graphics.FillRectangle(myPen.Brush,x,y,1,1);
                    numerator += shortest;
                    if (!(numerator < longest))
                    {
                        numerator -= longest;
                        x += dx1;
                        y += dy1;
                    }
                    else
                    {
                        x += dx2;
                        y += dy2;
                    }
                }
            }
            e.Graphics.FillEllipse(Brushes.Green, start.X - Radius, start.Y - Radius, Radius + Radius, Radius + Radius);
            e.Graphics.DrawEllipse(myPen, start.X - Radius, start.Y - Radius, Radius + Radius, Radius + Radius);
        }

        public void changeDist(Point offset)
        {
            start.Offset(offset);
            end.Offset(offset);
        }
        public bool checkPressedLine(Point pt) =>
            distanceBetweenPoints(start, pt) + distanceBetweenPoints(end, pt) <= distanceBetweenPoints(start, end) + precision;
        
        public double distanceBetweenPoints(Point a, Point b) =>
            Math.Sqrt(Math.Pow(b.X - a.X,2) + Math.Pow(b.Y - a.Y, 2));

        public Point midPoint() =>
            new Point((start.X + end.X)/2, (start.Y+end.Y)/2);
        
    }
}
