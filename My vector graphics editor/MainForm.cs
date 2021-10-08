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
        private int oldx, oldy;
        private int newFigureNumber = 0;

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
            if (selectedCreator != null)
            {
                var figure = selectedCreator.Create();
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
            var key = (sender as ToolStripButton)?.Text;
            if (creators.Keys.Contains(key))
            {
                if (key != null) selectedCreator = creators[key];
            }
        }

        private void pnlDrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            model.Draw(e.Graphics);
            Refresh();
        }

        private void btnSaveFigure_Click(object sender, EventArgs e)
        {
            if (selectedFigure is null) return;

            var figureName = $"Custom figure {newFigureNumber}";
            newFigureNumber++;

            var creator = PrototypeCreator.GetInstance();
            creator.prototype = selectedFigure;

            creators[figureName] = creator;

            var btn = new ToolStripButton()
            {
                Text = figureName
            };

            btn.Click += toolStripButton_Click;

            toolStrip1.Items.Add(btn);
        }

        private void pnlDrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                model.Manipulator.Drag(e.X - oldx, e.Y - oldy);
                model.Manipulator.Update();
                Refresh();
            }

            oldx = e.X;
            oldy = e.Y;
        }
    }
}
