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


        public void DrawMyRectangle(PaintEventArgs e, MyRectangle selectedRectange, bool systemMethod)
        {
            if (lines.Count > 0 && (lines.First().start == lines.Last().end))
            {
                if (selectedRectange != this)
                {
                    e.Graphics.FillPolygon(Brushes.LightGray, lines.Select(it => it.start).ToArray());
                }
                else
                {
                    e.Graphics.FillPolygon(Brushes.Gray, lines.Select(it => it.start).ToArray());
                }
            }
            if (systemMethod)
            {
                foreach (MyLine line in lines)
                {
                    line.DrawMyLine(e, systemMethod);
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

        public void moveRectangle(Point offset)
        {
            foreach (MyLine line in lines)
            {
                line.changeDist(offset);
            }
        }
        // return false : should remove all rectangle
        public bool removeVertex(Point vertex)
        {
            if (lines.Count == 3) return false;
            for (int i = 0; i < lines.Count; i++)
            {
                if (vertex == lines[i].start)
                {
                    MyLine newLine = new MyLine(lines[(i + lines.Count - 1) % lines.Count].start, lines[i].end);
                    lines.RemoveAt(i);
                    lines.RemoveAt((i + lines.Count - 1) % lines.Count);
                    lines.Insert((i + lines.Count - 1) % lines.Count, newLine);
                    return true;
                }
            }
            return true;
        }
        public void addVertexOnThePressedLine(Point pressedPoint)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].checkPressedLine(pressedPoint))
                {
                    MyLine tmp = lines[i];
                    lines.RemoveAt(i);
                    lines.Insert(i, new MyLine(tmp.start, tmp.midPoint()));
                    lines.Insert(i + 1, new MyLine(tmp.midPoint(),tmp.end));
                    break;
                }
            }
        }

        public void moveLine(int lineIndex, Point offset)
        {
            lines[(lines.Count + lineIndex - 1) % lines.Count].end.Offset(offset);
            lines[(lineIndex + 1) % lines.Count].start.Offset(offset);
            lines[lineIndex].changeDist(offset);
        }
    }
}
