using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ComputerGraphicLab1
{
    interface Rule
    {
        public abstract void Draw(PaintEventArgs e, Point p1, Point p2);
    }

    class HorizontalRule : Rule
    {
        public void Draw(PaintEventArgs e, Point p1, Point p2)
        {
            e.Graphics.DrawString("-", new Font(FontFamily.GenericSansSerif, 20), Brushes.Green, new PointF((p1.X + p2.X) / 2 - 10, (p1.Y + p2.Y) / 2 - 35));
        }
    }

    class VerticalRule : Rule
    {
        public void Draw(PaintEventArgs e, Point p1, Point p2)
        {
            e.Graphics.DrawString("|", new Font(FontFamily.GenericSansSerif, 10), Brushes.Red, new PointF((p1.X + p2.X) / 2 - 15, (p1.Y + p2.Y) / 2 - 10));

        }
    }
    class AngleRule : Rule
    {
        Point p0;
        float angle;
        public AngleRule(float angle, Point p0)
        {
            this.angle = angle;
            this.p0 = p0;
        }
        public void Draw(PaintEventArgs e, Point p1, Point p2)
        {
            throw new NotImplementedException();
        }
    }

}
