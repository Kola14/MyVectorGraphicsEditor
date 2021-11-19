
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
            this.pnlDrawingPanel = new MyVectorGraphicsEditor.Classes.DoubleBufferedPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlbSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbRectangle = new System.Windows.Forms.ToolStripButton();
            this.tsbEllipse = new System.Windows.Forms.ToolStripButton();
            this.btnSaveFigure = new System.Windows.Forms.Button();
            this.btnUngroup = new System.Windows.Forms.Button();
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
            this.pnlDrawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDrawingPanel_MouseMove);

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
            // btnSaveFigure
            // 
            this.btnSaveFigure.Location = new System.Drawing.Point(13, 39);
            this.btnSaveFigure.Name = "btnSaveFigure";
            this.btnSaveFigure.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFigure.TabIndex = 2;
            this.btnSaveFigure.Text = "Save figure";
            this.btnSaveFigure.UseVisualStyleBackColor = true;
            this.btnSaveFigure.Click += new System.EventHandler(this.btnSaveFigure_Click);
            // 
            // btnUngroup
            // 
            this.btnUngroup.Location = new System.Drawing.Point(94, 39);
            this.btnUngroup.Name = "btnUngroup";
            this.btnUngroup.Size = new System.Drawing.Size(75, 23);
            this.btnUngroup.TabIndex = 3;
            this.btnUngroup.Text = "Ungroup";
            this.btnUngroup.UseVisualStyleBackColor = true;
            this.btnUngroup.Click += new System.EventHandler(this.btnUngroup_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUngroup);
            this.Controls.Add(this.btnSaveFigure);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlDrawingPanel);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "My vector graphics editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
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
        private System.Windows.Forms.Button btnSaveFigure;
        private System.Windows.Forms.Button btnUngroup;
    }
}

