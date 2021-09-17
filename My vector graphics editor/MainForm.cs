using MyVectorGraphicsEditor.Classes;
using MyVectorGraphicsEditor.Classes.Figures;
using MyVectorGraphicsEditor.Classes.Figures.Creators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVectorGraphicsEditor
{
    public partial class MainForm : Form
    {
        FigureCreator selectedFigureCreator;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            selectedFigureCreator = RectangleCreator.GetInstance();
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            selectedFigureCreator = EllipseCreator.GetInstance();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectedFigureCreator = null;
        }

        private void pnlDrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedFigureCreator is null) return;

            Figure figure = selectedFigureCreator.Create();
            figure.X = e.X;
            figure.Y = e.Y;

            //RefreshPanel();

            figure.Draw(pnlDrawingPanel.CreateGraphics());
        }

        private void RefreshPanel()
        {
            var graphics = pnlDrawingPanel.CreateGraphics();

            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, pnlDrawingPanel.Width, pnlDrawingPanel.Height);
        }
    }
}
