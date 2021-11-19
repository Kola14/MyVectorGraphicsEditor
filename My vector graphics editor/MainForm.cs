﻿using MyVectorGraphicsEditor.Classes;
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
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace MyVectorGraphicsEditor
{
    public partial class MainForm : Form
    {
        FigureCreator selectedCreator;
        Model model;
        private Caretaker caretaker;
        Figure selectedFigure;
        private int oldx, oldy;
        private int newFigureNumber = 0;
        private bool ShiftPressed = false;

        Dictionary<string, FigureCreator> creators = new Dictionary<string, FigureCreator>();

        public MainForm()
        {
            InitializeComponent();

            LoadConfig();

            model = new Model();
            caretaker = new Caretaker(model);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadConfig()
        {
            var creatorPath = "MyVectorGraphicsEditor.Classes.Figures.Creators.";

            var config = new XmlDocument();

            config.Load(@"C:\Users\Kola\source\repos\MyVectorGraphicEditor\My vector graphics editor\Config.xml");

            var root = config.DocumentElement;

            if (root is null) return;

            foreach (XmlElement node in root)
            {
                var figure = node?.GetAttribute("name");

                if (figure is null) return;

                var creatorName = node?.FirstChild?.InnerText;
                var fullCreatorName = creatorPath + creatorName;

                var creator = (FigureCreator)Type.GetType(fullCreatorName)?.GetMethod("GetInstance")?.Invoke(null, null);

                creators[figure] = creator;
            }

            foreach (var creator in creators)
            {
                var button = new ToolStripButton();
                button.Text = creator.Key;
                button.Click += toolStripButton_Click;
                toolStrip1.Items.Add(button);
            }
        }

        private void pnlDrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedCreator != null)
            {
                model.UnGroup();
                var figure = selectedCreator.Create();
                figure.Move(e.X, e.Y);
                model.Add(figure);
                caretaker.Backup();
            }
            else
            {
                if (ShiftPressed)
                {
                    selectedFigure = model.Select(e.X, e.Y);
                    model.TmpGroup.Add(selectedFigure);
                    model.Manipulator.Attach(model.TmpGroup);
                }
                else
                {
                    selectedFigure = model.Select(e.X, e.Y);
                    model.UnGroup();
                }
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

            if (model.TmpGroup is null || model.TmpGroup.IsEmpty())
            {
                creator.prototype = selectedFigure.Clone();
            }
            else
            {
                creator.prototype = model.TmpGroup.Clone();
            }

            creators[figureName] = creator;

            var btn = new ToolStripButton()
            {
                Text = figureName
            };

            btn.Click += toolStripButton_Click;

            toolStrip1.Items.Add(btn);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) 
                ShiftPressed = true;

            if (ModifierKeys.HasFlag(Keys.Control) && e.KeyCode == Keys.Z)
            {
                caretaker.Undo();
                Refresh();
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) 
                ShiftPressed = false;
        }

        private void btnUngroup_Click(object sender, EventArgs e)
        {
            if (selectedFigure is null) return;

            if (selectedFigure.GetType() == typeof(Group))
            {
                Group group = (Group)selectedFigure;

                foreach (var f in group.Figures)
                {
                    model.Add(f.Clone());
                }
            }

            model.Remove(selectedFigure);

            selectedFigure = null;
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
