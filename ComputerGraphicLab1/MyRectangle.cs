using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ComputerGraphicLab1
{
    class MyRectangle
    {
        public List<MyLine> lines;
       
        public MyRectangle()
        {
            lines = new List<MyLine>();
        }

        public MyRectangle(List<MyLine> lines)
        {
            this.lines = lines;
        }

        
        public void DrawMyRectangle(PaintEventArgs e, bool systemMethod)
        {
            if (lines.Count > 0 && (lines.First().start == lines.Last().end))
            {
                e.Graphics.FillPolygon(Brushes.LightGray, lines.Select(it => it.start).ToArray());
            }
            if (systemMethod)
            {
                foreach (MyLine line in lines)
                {
                    line.DrawMyLine(e,systemMethod);
                }
            }
            else
            {

            }

        }
        public void Add(MyLine line)
        {
            lines.Add(line);
        }

        public bool checkPointInside(Point pt)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(lines.Select(it => it.start).ToArray());
            return path.GetBounds().Contains(pt);
        }

        public void moveRectangle(Point deltaDist)
        {
            foreach (MyLine line in lines)
            {
                line.addDist(deltaDist);
            }
        }
    }
}
