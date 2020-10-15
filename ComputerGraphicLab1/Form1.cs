using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComputerGraphicLab1
{
    public partial class Form1 : Form
    {
        public const int Radius = 3;

        Panel panel2;
        List<MyRectangle> rectangles;
        bool actualCreatingLines;
        Point startPointRectangle;
        MyLine actualCreatingLine;
        MyRectangle actualCreatingRectangle;
        Button selectedButton;
        bool leftMouseDown;
        MyRectangle selectedRectangle;
        Point startPressedPosForMove;
        public Form1()
        {
            InitializeComponent();
            panel2 = HolderPanel;
            actualCreatingRectangle = new MyRectangle();
            actualCreatingLines = false;
            rectangles = new List<MyRectangle>();
            startPointRectangle = Point.Empty;
            actualCreatingLine = new MyLine(Point.Empty,Point.Empty);
            selectedButton = create_polygons_button;
            leftMouseDown = false;
        }
        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (MyRectangle rec in rectangles)
            {
                rec.DrawMyRectangle(e, true);
            }
            actualCreatingRectangle.DrawMyRectangle(e,true);
            if(actualCreatingLine.start != Point.Empty)
            {
                actualCreatingLine.DrawMyLine(e,true);
            }
        }
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if(selectedButton == create_polygons_button)
            {
                if (actualCreatingLines)
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
                            actualCreatingLines = false;
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
                    actualCreatingLines = true;
                    actualCreatingRectangle = new MyRectangle();
                }
            }
            else if(selectedButton == move_polygons_button)
            {
                int i;
                for (i = rectangles.Count-1; i >= 0; i--)
                {
                    if (rectangles[i].checkPointInside(e.Location)) {
                        startPressedPosForMove = e.Location;
                        selectedRectangle = rectangles[i];
                        break;
                    }
                }
                leftMouseDown = true;
            }
            else if(selectedButton == delete_polygons_button)
            {

            }
            else if(selectedButton == edit_polygons_button){

            }
            panel2.Invalidate();
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(selectedButton == create_polygons_button)
            {
                if (actualCreatingLines)
                {
                    actualCreatingLine.end = e.Location;
                }
            }else if(selectedButton == move_polygons_button)
            {
                if (leftMouseDown && selectedRectangle != null)
                {
                    selectedRectangle.moveRectangle(
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
            selectedButton = (Button)sender;
        }

        private void HolderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if(selectedButton == move_polygons_button)
            {
                selectedRectangle = null;
                leftMouseDown = false;
            }
        }
    }
}
