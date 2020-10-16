namespace ComputerGraphicLab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.add_vertexes_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.delete_vertexes_button = new System.Windows.Forms.Button();
            this.move_vertexes_button = new System.Windows.Forms.Button();
            this.move_edges_button = new System.Windows.Forms.Button();
            this.delete_polygons_button = new System.Windows.Forms.Button();
            this.move_polygons_button = new System.Windows.Forms.Button();
            this.create_polygons_button = new System.Windows.Forms.Button();
            this.HolderPanel = new ComputerGraphicLab1.MyCustomPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.add_vertexes_button);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.delete_vertexes_button);
            this.splitContainer1.Panel1.Controls.Add(this.move_vertexes_button);
            this.splitContainer1.Panel1.Controls.Add(this.move_edges_button);
            this.splitContainer1.Panel1.Controls.Add(this.delete_polygons_button);
            this.splitContainer1.Panel1.Controls.Add(this.move_polygons_button);
            this.splitContainer1.Panel1.Controls.Add(this.create_polygons_button);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.HolderPanel);
            this.splitContainer1.Size = new System.Drawing.Size(795, 450);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // add_vertexes_button
            // 
            this.add_vertexes_button.Location = new System.Drawing.Point(13, 120);
            this.add_vertexes_button.Name = "add_vertexes_button";
            this.add_vertexes_button.Size = new System.Drawing.Size(170, 23);
            this.add_vertexes_button.TabIndex = 7;
            this.add_vertexes_button.Text = "Add Vertexes";
            this.add_vertexes_button.UseVisualStyleBackColor = true;
            this.add_vertexes_button.Click += new System.EventHandler(this.polygonsButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Edit Polygons";
            // 
            // delete_vertexes_button
            // 
            this.delete_vertexes_button.Location = new System.Drawing.Point(13, 178);
            this.delete_vertexes_button.Name = "delete_vertexes_button";
            this.delete_vertexes_button.Size = new System.Drawing.Size(170, 23);
            this.delete_vertexes_button.TabIndex = 5;
            this.delete_vertexes_button.Text = "Delete Vertexes";
            this.delete_vertexes_button.UseVisualStyleBackColor = true;
            this.delete_vertexes_button.Click += new System.EventHandler(this.polygonsButtonClick);
            // 
            // move_vertexes_button
            // 
            this.move_vertexes_button.Location = new System.Drawing.Point(13, 149);
            this.move_vertexes_button.Name = "move_vertexes_button";
            this.move_vertexes_button.Size = new System.Drawing.Size(170, 23);
            this.move_vertexes_button.TabIndex = 4;
            this.move_vertexes_button.Text = "Move Vertexes";
            this.move_vertexes_button.UseVisualStyleBackColor = true;
            this.move_vertexes_button.Click += new System.EventHandler(this.polygonsButtonClick);
            // 
            // move_edges_button
            // 
            this.move_edges_button.Location = new System.Drawing.Point(13, 207);
            this.move_edges_button.Name = "move_edges_button";
            this.move_edges_button.Size = new System.Drawing.Size(170, 23);
            this.move_edges_button.TabIndex = 3;
            this.move_edges_button.Text = "Move Edges";
            this.move_edges_button.UseVisualStyleBackColor = true;
            this.move_edges_button.Click += new System.EventHandler(this.polygonsButtonClick);
            // 
            // delete_polygons_button
            // 
            this.delete_polygons_button.Location = new System.Drawing.Point(12, 71);
            this.delete_polygons_button.Name = "delete_polygons_button";
            this.delete_polygons_button.Size = new System.Drawing.Size(171, 23);
            this.delete_polygons_button.TabIndex = 2;
            this.delete_polygons_button.Text = "Delete Polygons";
            this.delete_polygons_button.UseVisualStyleBackColor = true;
            this.delete_polygons_button.Click += new System.EventHandler(this.polygonsButtonClick);
            // 
            // move_polygons_button
            // 
            this.move_polygons_button.Location = new System.Drawing.Point(12, 42);
            this.move_polygons_button.Name = "move_polygons_button";
            this.move_polygons_button.Size = new System.Drawing.Size(171, 23);
            this.move_polygons_button.TabIndex = 1;
            this.move_polygons_button.Text = "Move Polygons";
            this.move_polygons_button.UseVisualStyleBackColor = true;
            this.move_polygons_button.Click += new System.EventHandler(this.polygonsButtonClick);
            // 
            // create_polygons_button
            // 
            this.create_polygons_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("create_polygons_button.BackgroundImage")));
            this.create_polygons_button.Location = new System.Drawing.Point(12, 12);
            this.create_polygons_button.Name = "create_polygons_button";
            this.create_polygons_button.Size = new System.Drawing.Size(171, 24);
            this.create_polygons_button.TabIndex = 0;
            this.create_polygons_button.Text = "Create Polygons";
            this.create_polygons_button.UseVisualStyleBackColor = true;
            this.create_polygons_button.Click += new System.EventHandler(this.polygonsButtonClick);
            // 
            // HolderPanel
            // 
            this.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HolderPanel.Location = new System.Drawing.Point(0, 0);
            this.HolderPanel.Name = "HolderPanel";
            this.HolderPanel.Size = new System.Drawing.Size(595, 450);
            this.HolderPanel.TabIndex = 0;
            this.HolderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            this.HolderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseDown);
            this.HolderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseMove);
            this.HolderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HolderPanel_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 450);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private MyCustomPanel HolderPanel;
        private System.Windows.Forms.Button move_edges_button;
        private System.Windows.Forms.Button delete_polygons_button;
        private System.Windows.Forms.Button move_polygons_button;
        private System.Windows.Forms.Button create_polygons_button;
        private System.Windows.Forms.Button delete_vertexes_button;
        private System.Windows.Forms.Button move_vertexes_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_vertexes_button;
    }
}

