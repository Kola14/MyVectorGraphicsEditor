
using MyVectorGraphicsEditor.Classes;

namespace MyVectorGraphicsEditor
{
    partial class MainForm
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
            this.pnlDrawingPanel = new DoubleBufferedPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlbSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbRectangle = new System.Windows.Forms.ToolStripButton();
            this.tsbEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDrawingPanel
            // 
            this.pnlDrawingPanel.BackColor = System.Drawing.Color.White;
            this.pnlDrawingPanel.Location = new System.Drawing.Point(12, 89);
            this.pnlDrawingPanel.Name = "pnlDrawingPanel";
            this.pnlDrawingPanel.Size = new System.Drawing.Size(776, 349);
            this.pnlDrawingPanel.TabIndex = 0;
            this.pnlDrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDrawingPanel_Paint);
            this.pnlDrawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDrawingPanel_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbSelect,
            this.tsbRectangle,
            this.tsbEllipse});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlbSelect
            // 
            this.tlbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlbSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbSelect.Name = "tlbSelect";
            this.tlbSelect.Size = new System.Drawing.Size(42, 22);
            this.tlbSelect.Text = "Select";
            this.tlbSelect.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // tsbRectangle
            // 
            this.tsbRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRectangle.Name = "tsbRectangle";
            this.tsbRectangle.Size = new System.Drawing.Size(63, 22);
            this.tsbRectangle.Text = "Rectangle";
            this.tsbRectangle.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // tsbEllipse
            // 
            this.tsbEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEllipse.Name = "tsbEllipse";
            this.tsbEllipse.Size = new System.Drawing.Size(44, 22);
            this.tsbEllipse.Text = "Ellipse";
            this.tsbEllipse.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlDrawingPanel);
            this.Name = "MainForm";
            this.Text = "My vector graphics editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Panel pnlDrawingPanel;
        private DoubleBufferedPanel pnlDrawingPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlbSelect;
        private System.Windows.Forms.ToolStripButton tsbRectangle;
        private System.Windows.Forms.ToolStripButton tsbEllipse;
    }
}

