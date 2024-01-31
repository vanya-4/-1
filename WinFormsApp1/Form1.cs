namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image=new Bitmap(pictureBox1.Width,pictureBox1.Height);
        }
        int x, y; //  попередні координати
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        public void FillingAnArrea(int x1,int y1)
        {
            
            if (x1 >= pictureBox1.Width || x1 < 1 || y1 >= pictureBox1.Height - 1 || y1 < 1)
                return;
            Graphics graph = Graphics.FromImage(pictureBox1.Image);
            graph.DrawLine(new Pen(Color.Green), x1, y1, x1, y1+0.5f);
            pictureBox1.Invalidate();
            Bitmap image=(Bitmap)pictureBox1.Image;
            if (image.GetPixel(x1+1,y1).ToArgb()!=Color.Black.ToArgb()&& image.GetPixel(x1 + 1, y1).ToArgb() != Color.Green.ToArgb())
            {
                FillingAnArrea(x1+1,  y1);
            }
            if (image.GetPixel(x1 - 1, y1).ToArgb() != Color.Black.ToArgb() && image.GetPixel(x1 - 1, y1).ToArgb() != Color.Green.ToArgb())
            {
                FillingAnArrea(x1 - 1, y1);
            }
            if (image.GetPixel(x1, y1+1).ToArgb() != Color.Black.ToArgb() && image.GetPixel(x1, y1+1).ToArgb() != Color.Green.ToArgb())
            {
                FillingAnArrea(x1 , y1 + 1);
            }
            if (image.GetPixel(x1, y1 - 1).ToArgb() != Color.Black.ToArgb() && image.GetPixel(x1, y1 - 1).ToArgb() != Color.Green.ToArgb())
            {
                FillingAnArrea(x1 , y1 - 1);
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            if (e.Button == MouseButtons.Right)
            {
                FillingAnArrea(e.X, e.Y);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics graph=Graphics.FromImage(pictureBox1.Image);
                graph.DrawLine(new Pen(Color.Black),e.X,e.Y,x,y);
                x = e.X;
                y = e.Y;
                pictureBox1.Invalidate();
            }

        }
    }
}