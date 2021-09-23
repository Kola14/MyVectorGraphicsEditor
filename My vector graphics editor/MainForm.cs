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
        FigureCreator selectedCreator;
        Model model;
        Figure selectedFigure;

        Dictionary<string, FigureCreator> creators = new Dictionary<string, FigureCreator>();

        public MainForm()
        {
            InitializeComponent();

            creators["Rectangle"] = RectangleCreator.GetInstance();
            creators["Ellipse"] = EllipseCreator.GetInstance();
            creators["Select"] = null;

            model = new Model();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pnlDrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics graphics = pnlDrawingPanel.CreateGraphics();

            if (selectedCreator != null)
            {
                Figure figure;

                figure = selectedCreator.Create();
                figure.Move(e.X, e.Y);
                model.Add(figure);
            }
            else
            {
                selectedFigure = model.Select(e.X, e.Y);
            }
        }

        private void toolStripButton_Click(Object sender, EventArgs e)
        {
            string key = (sender as ToolStripButton).Text;
            if (creators.Keys.Contains(key))
            {
                selectedCreator = creators[key];
            }
        }

        private void pnlDrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            model.Draw(e.Graphics);
        }
    }
}
