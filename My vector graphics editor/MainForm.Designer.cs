
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
            this.pnlDrawingPanel = new System.Windows.Forms.Panel();
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlDrawingPanel);
            this.Name = "MainForm";
            this.Text = "My vector graphics editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDrawingPanel;
    }
}

