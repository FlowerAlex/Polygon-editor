using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphicLab1
{
    public partial class Form1 : Form
    {
        public const int Radius = 3;

        Panel panel2;
        List<MyRectangle> rectangles;
        bool createingLine;
        Point startPointRectangle;
        MyLine actualCreatingLine;
        MyRectangle actualCreatingRectangle;
        Button selectedButton;
        Button SelectedButton
        {
            get { return selectedButton; }
            set
            {
                selectedRectangle = null;
                selectedButton = value;
                panel2.Invalidate();
            }
        }
        bool leftMouseDown;
        Point startPressedPosForMove;
        MyRectangle selectedRectangle;
        MyRectangle SelectedRectangle { get
            {
                return selectedRectangle;
            }
            set {
                if (value != null && rectangles.Count > 1)
                {
                    selectedRectangle = value;
                    rectangles.Remove(SelectedRectangle);
                    rectangles.Add(selectedRectangle);
                }
                else selectedRectangle = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
            panel2 = HolderPanel;
            actualCreatingRectangle = new MyRectangle();
            createingLine = false;
            rectangles = new List<MyRectangle>();
            startPointRectangle = Point.Empty;
            actualCreatingLine = new MyLine(Point.Empty,Point.Empty);
            SelectedButton = create_polygons_button;
            leftMouseDown = false;
        }
        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (MyRectangle rec in rectangles)
            {
                rec.DrawMyRectangle(e,SelectedRectangle, true);
            }
            actualCreatingRectangle.DrawMyRectangle(e, SelectedRectangle, true);
            if(actualCreatingLine.start != Point.Empty)
            {
                actualCreatingLine.DrawMyLine(e,true);
            }
        }
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if(SelectedButton == create_polygons_button)
            {
                if (createingLine)
                {
                    if (checkClickPos(startPointRectangle, e.Location))
                    {
                        //reset all tmp values for the next polygon
                        if (startPointRectangle != actualCreatingLine.start)
                        {
                            actualCreatingRectangle.Add(new MyLine(actualCreatingLine.start, startPointRectangle));
                            rectangles.Add(actualCreatingRectangle);
                            actualCreatingLine.start = Point.Empty;
                            actualCreatingLine.end = Point.Empty;
                            actualCreatingRectangle = new MyRectangle();
                            createingLine = false;
                            startPointRectangle = Point.Empty;
                            panel2.Invalidate();
                        }
                        return;
                    }
                    actualCreatingRectangle.Add(new MyLine(actualCreatingLine.start, e.Location));
                    actualCreatingLine.start = e.Location;
                }
                else
                {
                    startPointRectangle = actualCreatingLine.start = actualCreatingLine.end = e.Location;
                    createingLine = true;
                    actualCreatingRectangle = new MyRectangle();
                }
            }
            else if(SelectedButton == move_polygons_button)
            {
                int i;
                for (i = rectangles.Count-1; i >= 0; i--)
                {
                    if (rectangles[i].checkPointInside(e.Location)) {
                        startPressedPosForMove = e.Location;
                        SelectedRectangle = rectangles[i];
                        break;
                    }
                }
                leftMouseDown = true;
            }
            else if(SelectedButton == delete_polygons_button)
            {
                int i;
                for (i = rectangles.Count - 1; i >= 0; i--)
                {
                    if (rectangles[i].checkPointInside(e.Location))
                    {
                        rectangles.RemoveAt(i);
                        break;
                    }
                }
            }
            else if(SelectedButton == add_vertexes_button){ 


                //int i;
                //for (i = rectangles.Count - 1; i >= 0; i--)
                //{
                //    if (rectangles[i].checkPointInside(e.Location))
                //    {
                //        SelectedRectangle = rectangles[i];
                //        break;
                //    }
                //    SelectedRectangle = null;
                //}
            }else if (SelectedButton == move_vertexes_button)
            {

            }
            else if (SelectedButton == delete_vertexes_button)
            {
                int i;
                bool isFinded = false;
                for (i = rectangles.Count - 1; i >= 0 && !isFinded; i--)
                {
                    for (int j = 0; j < rectangles[i].lines.Count; j++)
                    {
                        Point tmp;
                        if (checkClickPos(tmp = rectangles[i].lines[j].start, e.Location))
                        {
                            if(!rectangles[i].removeVertex(tmp)) rectangles.RemoveAt(i);
                            isFinded = true;
                            break;
                        }
                    }
                }
            }
            else if (SelectedButton == move_edges_button)
            {

            }
            panel2.Invalidate();
        }
        bool isEditButton(Button bt)
        {
            return bt == add_vertexes_button ||
                bt == move_vertexes_button || 
                bt == delete_vertexes_button || 
                bt == move_edges_button;
        }
        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(SelectedButton == create_polygons_button)
            {
                if (createingLine)
                {
                    actualCreatingLine.end = e.Location;
                }
            }else if(SelectedButton == move_polygons_button)
            {
                if (leftMouseDown && SelectedRectangle != null)
                {
                    SelectedRectangle.moveRectangle(
                        new Point(e.Location.X - startPressedPosForMove.X, e.Location.Y - startPressedPosForMove.Y)
                        );
                    startPressedPosForMove = e.Location;
                }
            }
            panel2.Invalidate();

        }

        public bool checkClickPos(Point center, Point point) =>
             Math.Sqrt(Math.Pow(center.X - point.X, 2) + Math.Pow(center.Y - point.Y, 2)) <= Radius;

        private void polygonsButtonClick(object sender, EventArgs e)
        {
            SelectedButton = (Button)sender;
        }

        private void HolderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if(SelectedButton == move_polygons_button)
            {
                SelectedRectangle = null;
                leftMouseDown = false;
            }
        }
    }
}
