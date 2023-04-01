using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graham
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private List<PointF> points = new List<PointF>();
        List<PointF> hull = new List<PointF>();

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(new PointF(e.X, e.Y));
                Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                points.Clear();
                Invalidate();
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(e.Location);
                pictureBox1.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the points from the PictureBox
            List<PointF> points = new List<PointF>();
            foreach (Control control in pictureBox1.Controls)
            {
                if (control is PictureBox && control != pictureBox1)
                {
                    points.Add(control.Location);
                }
            }

            // Perform the Graham's scan algorithm on the points
            List<PointF> hull = GrahamScan(points);

            // Draw the hull on the PictureBox
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);

                // Check if the hull contains at least three points
                if (hull.Count >= 3)
                {
                    g.DrawPolygon(Pens.Black, hull.ToArray());
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the hull in blue
            if (hull.Count >= 3)
            {
                g.DrawPolygon(Pens.Blue, hull.ToArray());
            }

            // Draw the points in black
            foreach (var p in points)
            {
                g.FillEllipse(Brushes.Black, p.X - 2, p.Y - 2, 5, 5);
            }
        }

        private static double Cross(PointF O, PointF A, PointF B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }

        private static List<PointF> GrahamScan(List<PointF> points)
        {
            List<PointF> hull = new List<PointF>();

            // Find the point with the lowest y-coordinate (and leftmost x-coordinate in case of ties)
            PointF p0 = points.OrderBy(p => p.Y).ThenBy(p => p.X).FirstOrDefault();

            if (p0 == null)
            {
                // Handle the case where the sequence is empty
                return hull;
            }

            // Sort the points by the angle they make with the horizontal line passing through p0
            IEnumerable<PointF> sortedPoints = points.OrderBy(p => Math.Atan2(p.Y - p0.Y, p.X - p0.X));

            foreach (PointF p in sortedPoints)
            {
                // Remove any points that would make a non-left turn
                while (hull.Count >= 2 && Cross(hull[hull.Count - 2], hull[hull.Count - 1], p) <= 0)
                {
                    hull.RemoveAt(hull.Count - 1);
                }

                hull.Add(p);
            }

            return hull;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            //Clear the points from the PictureBox
            pictureBox1.Controls.Clear();

            // Clear the hull from the graphics context
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            // Exit the application
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the size and position of the form
           
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
       
        



