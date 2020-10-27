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
        Point startPressedPosForMovePolygons;
        MyRectangle selectedRectangle;
        MyRectangle actualEditedRectangle;
        int actualMovingPointIndex;
        private Point startPressedPosForMoveLine;
        private MyRectangle rectangleWithSelectedEdge;
        private int pressedLineIndex;
        RadioButton activeAlgorythm;

        MyRectangle SelectedRectangle { get
            {
                return selectedRectangle;
            }
            set {
                if (value != null && rectangles.Count > 1)
                {
                    selectedRectangle = value;
                    rectangles.Remove(selectedRectangle);
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
            actualEditedRectangle = null;
            actualMovingPointIndex = -1;
            startPressedPosForMoveLine = Point.Empty;
            rectangleWithSelectedEdge = null;
            pressedLineIndex = -1;
            activeAlgorythm = system_method_radiobutton;
        }
        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (MyRectangle rec in rectangles)
            {
                rec.DrawMyRectangle(e,SelectedRectangle, activeAlgorythm.Text);
            }
            actualCreatingRectangle.DrawMyRectangle(e, SelectedRectangle, activeAlgorythm.Text);
            if(actualCreatingLine.start != Point.Empty)
            {
                actualCreatingLine.DrawMyLine(e, activeAlgorythm.Text);
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
                        startPressedPosForMovePolygons = e.Location;
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
                foreach(MyRectangle rect in rectangles)
                {
                    rect.addVertexOnThePressedLine(e.Location);
                }
            }
            else if (SelectedButton == move_vertexes_button)
            {
                bool isFinded = false;

                for (int i = rectangles.Count - 1; i >= 0 && !isFinded; i--)
                {
                    for (int j = 0; j < rectangles[i].lines.Count; j++)
                    {
                        Point tmp;
                        if (checkClickPos(tmp = rectangles[i].lines[j].start, e.Location))
                        {
                            actualEditedRectangle = rectangles[i];
                            actualMovingPointIndex = j;
                            isFinded = true;
                            break;
                        }
                    }
                }
            }
            else if (SelectedButton == delete_vertexes_button)
            {
                bool isFinded = false;
                for (int i = rectangles.Count - 1; i >= 0 && !isFinded; i--)
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
                bool isFound = false;
                for (int i = rectangles.Count - 1; i >= 0 && !isFound; i--)
                {
                    for (int j = 0; j < rectangles[i].lines.Count; j++)
                    {
                        if (rectangles[i].lines[j].checkPressedLine(e.Location))
                        {
                            startPressedPosForMoveLine = e.Location;
                            rectangleWithSelectedEdge = rectangles[i];
                            pressedLineIndex = j;
                            isFound = true;
                            break;
                        }
                    }
                }
                leftMouseDown = true;
            }
            else if(SelectedButton == edit_horisontal_rule_button)
            {

                if (e.Button == MouseButtons.Left)
                {
                    bool isFound = false;
                    for (int i = rectangles.Count - 1; i >= 0 && !isFound; i--)
                    {
                        for (int j = 0; j < rectangles[i].lines.Count; j++)
                        {
                            if (rectangles[i].lines[j].checkPressedLine(e.Location))
                            {
                                if(rectangles[i].lines[j].rule == null && 
                                    rectangles[i].lines[(rectangles[i].lines.Count + j - 1)% rectangles[i].lines.Count].rule?.GetType() != typeof(HorizontalRule) &&
                                    rectangles[i].lines[(j + 1) % rectangles[i].lines.Count].rule?.GetType() != typeof(HorizontalRule)
                                    )
                                {
                                    rectangles[i].addRule(new HorizontalRule(), j);
                                }

                                isFound = true;
                                break;
                            }
                        }
                    }
                }else if(e.Button == MouseButtons.Right)
                {
                    bool isFound = false;
                    for (int i = rectangles.Count - 1; i >= 0 && !isFound; i--)
                    {
                        for (int j = 0; j < rectangles[i].lines.Count; j++)
                        {
                            if (rectangles[i].lines[j].checkPressedLine(e.Location))
                            {
                                rectangles[i].deleteRule(j);
                                isFound = true;
                                break;
                            }
                        }
                    }
                }
            }
            else if (SelectedButton == edit_vertical_rule_button)
            {
                if (e.Button == MouseButtons.Left)
                {
                    bool isFound = false;
                    for (int i = rectangles.Count - 1; i >= 0 && !isFound; i--)
                    {
                        for (int j = 0; j < rectangles[i].lines.Count; j++)
                        {
                            if (rectangles[i].lines[j].checkPressedLine(e.Location))
                            {

                                if (rectangles[i].lines[j].rule == null &&
                                    rectangles[i].lines[(rectangles[i].lines.Count + j - 1) % rectangles[i].lines.Count].rule?.GetType() != typeof(VerticalRule) &&
                                    rectangles[i].lines[(j + 1) % rectangles[i].lines.Count].rule?.GetType() != typeof(VerticalRule)
                                    )
                                {
                                    rectangles[i].addRule(new VerticalRule(), j);
                                }
                                isFound = true;
                                break;
                            }
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    bool isFound = false;
                    for (int i = rectangles.Count - 1; i >= 0 && !isFound; i--)
                    {
                        for (int j = 0; j < rectangles[i].lines.Count; j++)
                        {
                            if (rectangles[i].lines[j].checkPressedLine(e.Location))
                            {
                                rectangles[i].deleteRule(j);

                                isFound = true;
                                break;
                            }
                        }
                    }
                }
            }
            else if (SelectedButton == edit_angle_rule)
            {

            }
            panel2.Invalidate();
        }
        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(SelectedButton == create_polygons_button)
            {
                if (createingLine)
                {
                    actualCreatingLine.end = e.Location;
                }
            }
            else if(SelectedButton == move_polygons_button)
            {
                if (leftMouseDown && SelectedRectangle != null)
                {
                    SelectedRectangle.moveRectangle(
                        new Point(e.Location.X - startPressedPosForMovePolygons.X, e.Location.Y - startPressedPosForMovePolygons.Y)
                        );
                    startPressedPosForMovePolygons = e.Location;
                }
            }
            else if (SelectedButton == move_vertexes_button)
            {
                if(actualEditedRectangle != null && actualMovingPointIndex != -1)
                {
                    actualEditedRectangle.moveVertex(actualMovingPointIndex,e.Location);
                }
            }
            else if (SelectedButton == move_edges_button)
            {
                if(rectangleWithSelectedEdge != null && pressedLineIndex != -1)
                {

                    rectangleWithSelectedEdge.moveLine(pressedLineIndex, new Point(e.X - startPressedPosForMoveLine.X, e.Y - startPressedPosForMoveLine.Y));
                    startPressedPosForMoveLine = e.Location;
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
            else if (SelectedButton == move_vertexes_button)
            {
                actualMovingPointIndex = -1;
                actualEditedRectangle = null;
            }
            else if(SelectedButton == move_edges_button)
            {
                startPressedPosForMoveLine = Point.Empty;
                rectangleWithSelectedEdge = null;
                pressedLineIndex = -1;
            }
        }
        private void system_method_radiobutton_Click(object sender, EventArgs e)
        {
            activeAlgorythm = (RadioButton)sender;
            panel2.Invalidate();
        }
    }
}
