using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphicLab1
{

    class MyLine
    {
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
            e.Graphics.DrawEllipse(myPen, start.X-Radius,start.Y- Radius, Radius + Radius,Radius + Radius);
            if (systemMethod)
            {
                e.Graphics.DrawLine(myPen, start, end);
            }
            else { throw new NotImplementedException(); }
        }

        public void addDist(Point deltaDist)
        {
            start.Offset(deltaDist);
            end.Offset(deltaDist);
        }
    }
}
