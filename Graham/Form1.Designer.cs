using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graham
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Start = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(903, 714);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Start
            // 
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Start.Location = new System.Drawing.Point(909, 43);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(129, 52);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Reset
            // 
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Reset.Location = new System.Drawing.Point(909, 117);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(129, 53);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Exit
            // 
            this.Exit.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.ForeColor = System.Drawing.Color.Red;
            this.Exit.Location = new System.Drawing.Point(909, 189);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(129, 51);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 712);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Get the mouse position relative to the PictureBox
            MouseEventArgs mouseArgs = e as MouseEventArgs;
            Point mousePosition = mouseArgs.Location;

            // Create a new PictureBox to represent the point
            PictureBox pointBox = new PictureBox();
            pointBox.BackColor = Color.Black;
            pointBox.Location = mousePosition;
            pointBox.Size = new Size(5, 5);

            // Add the point to the PictureBox
            pictureBox1.Controls.Add(pointBox);
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
       

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Start;
        private Button Reset;
        private Button Exit;
    }
}

