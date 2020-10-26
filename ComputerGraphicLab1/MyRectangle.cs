using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
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
            foreach (MyLine line in lines)
            {
                line.DrawMyLine(e, systemMethod);
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
            return path.IsVisible(pt);
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
                    if (i != 0)
                        lines.Insert((i + lines.Count - 1) % lines.Count, newLine);
                    else
                        lines.Insert((i + lines.Count) % lines.Count, newLine);
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
        public void moveVertex(int lineIndexWithStartPoint, Point finishPosition)
        {
            lines[lineIndexWithStartPoint].start = finishPosition;
            lines[(lineIndexWithStartPoint + lines.Count - 1) % lines.Count].end = finishPosition;
            changeRectWithRulesRelativelyPoint(lineIndexWithStartPoint);
        }
        public void moveLine(int lineIndex, Point offset)
        {
            lines[(lines.Count + lineIndex - 1) % lines.Count].end.Offset(offset);
            lines[(lineIndex + 1) % lines.Count].start.Offset(offset);
            lines[lineIndex].changeDist(offset);
            changeRectWithRulesRelativelyPoint(lineIndex);
        }

        public void addRule(Rule rule, int lineIndex) {
            lines[lineIndex].rule = rule;
            changeRectWithRulesRelativelyPoint(lineIndex);
        }
        public void deleteRule(int lineIndex)
        {
            lines[lineIndex].rule = null;
        }

        public bool changeRectWithRulesRelativelyPoint(int pointIndex)
        {
            for(int i = 0; i < lines.Count - 1; i++)
            {
                //start point static , end point able to move
                if (lines[(pointIndex + i) % lines.Count].rule?.GetType() == typeof(HorizontalRule))
                {
                    lines[(pointIndex + i) % lines.Count].end = new Point(lines[(pointIndex + i) % lines.Count].end.X, lines[(pointIndex + i) % lines.Count].start.Y);
                    lines[(pointIndex + i + 1) % lines.Count].start = new Point(lines[(pointIndex + i) % lines.Count].end.X, lines[(pointIndex + i) % lines.Count].start.Y);
                }
                else if(lines[(pointIndex + i) % lines.Count].rule?.GetType() == typeof(VerticalRule))
                {        
                    lines[(pointIndex + i) % lines.Count].end = new Point(lines[(pointIndex + i) % lines.Count].start.X, lines[(pointIndex + i) % lines.Count].end.Y);
                    lines[(pointIndex + i + 1) % lines.Count].start = new Point(lines[(pointIndex + i) % lines.Count].start.X, lines[(pointIndex + i) % lines.Count].end.Y);
                }

            }
            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[(pointIndex + lines.Count - i) % lines.Count].rule?.GetType() == typeof(HorizontalRule))
                {
                    lines[(pointIndex + lines.Count - i) % lines.Count].start = new Point(lines[(pointIndex + lines.Count - i) % lines.Count].start.X, lines[(pointIndex + lines.Count - i) % lines.Count].end.Y);
                    lines[(pointIndex + lines.Count - i - 1) % lines.Count].end = new Point(lines[(pointIndex + lines.Count - i) % lines.Count].start.X, lines[(pointIndex + lines.Count - i) % lines.Count].end.Y);
                }
                else if (lines[(pointIndex + lines.Count - i) % lines.Count].rule?.GetType() == typeof(VerticalRule))
                {
                    lines[(pointIndex + lines.Count - i) % lines.Count].start = new Point(lines[(pointIndex + lines.Count - i) % lines.Count].end.X, lines[(pointIndex + lines.Count - i) % lines.Count].start.Y);
                    lines[(pointIndex + lines.Count - i - 1) % lines.Count].end = new Point(lines[(pointIndex + lines.Count - i) % lines.Count].end.X, lines[(pointIndex + lines.Count - i) % lines.Count].start.Y);
                }
            }
            return false;
        }
    }
}
