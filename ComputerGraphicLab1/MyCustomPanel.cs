namespace ComputerGraphicLab1
{
    class MyCustomPanel : System.Windows.Forms.Panel
    {
        public MyCustomPanel() : base()
        {
            SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }
}
