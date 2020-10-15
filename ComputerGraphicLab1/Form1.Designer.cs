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
            this.edit_polygons_button = new System.Windows.Forms.Button();
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
            this.splitContainer1.Panel1.Controls.Add(this.edit_polygons_button);
            this.splitContainer1.Panel1.Controls.Add(this.delete_polygons_button);
            this.splitContainer1.Panel1.Controls.Add(this.move_polygons_button);
            this.splitContainer1.Panel1.Controls.Add(this.create_polygons_button);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.HolderPanel);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // edit_polygons_button
            // 
            this.edit_polygons_button.Location = new System.Drawing.Point(12, 100);
            this.edit_polygons_button.Name = "edit_polygons_button";
            this.edit_polygons_button.Size = new System.Drawing.Size(171, 23);
            this.edit_polygons_button.TabIndex = 3;
            this.edit_polygons_button.Text = "Edit Polygons";
            this.edit_polygons_button.UseVisualStyleBackColor = true;
            this.edit_polygons_button.Click += new System.EventHandler(this.polygonsButtonClick);
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
            this.HolderPanel.Size = new System.Drawing.Size(596, 450);
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
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private MyCustomPanel HolderPanel;
        private System.Windows.Forms.Button edit_polygons_button;
        private System.Windows.Forms.Button delete_polygons_button;
        private System.Windows.Forms.Button move_polygons_button;
        private System.Windows.Forms.Button create_polygons_button;
    }
}

