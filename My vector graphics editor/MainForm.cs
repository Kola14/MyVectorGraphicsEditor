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
using System.Windows.Forms.VisualStyles;
using System.Xml;
using Figures;

namespace MyVectorGraphicsEditor
{
    public partial class MainForm : Form
    {
        private FigureCreator _selectedCreator;
        private Model _model;
        private Caretaker _caretaker;
        private Figure _selectedFigure;
        private int _oldx, _oldy;
        private int _newFigureNumber = 0;
        private bool _shiftPressed = false;

        private Dictionary<string, FigureCreator> _creators = new Dictionary<string, FigureCreator>();

        public MainForm()
        {
            InitializeComponent();

            LoadConfig();

            _model = new Model();
            _caretaker = new Caretaker(_model);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadConfig()
        {
            //TODO change these ugly strings
            //TODO make the creatorPath self buildable
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

                _creators[figure] = creator;
            }

            foreach (var creator in _creators)
            {
                var button = new ToolStripButton();
                button.Text = creator.Key;
                button.Click += toolStripButton_Click;
                toolStrip1.Items.Add(button);
            }
        }

        private void pnlDrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedCreator != null)
            {
                _model.UnGroup();
                var figure = _selectedCreator.Create();
                figure.Move(e.X, e.Y);
                _model.Add(figure);
                _caretaker.Backup();
            }
            else
            {
                if (_shiftPressed)
                {
                    _selectedFigure = _model.Select(e.X, e.Y);
                    _model.TmpGroup.Add(_selectedFigure);
                    _model.Manipulator.Attach(_model.TmpGroup);
                }
                else
                {
                    _selectedFigure = _model.Select(e.X, e.Y);
                    _model.UnGroup();
                }
            }
        }

        private void toolStripButton_Click(Object sender, EventArgs e)
        {
            var key = (sender as ToolStripButton)?.Text;
            if (_creators.Keys.Contains(key))
            {
                if (key != null) _selectedCreator = _creators[key];
            }
        }

        private void pnlDrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            _model.Draw(e.Graphics);
            Refresh();
        }

        private void btnSaveFigure_Click(object sender, EventArgs e)
        {
            if (_selectedFigure is null) return;

            var figureName = $"Custom figure {_newFigureNumber}";
            _newFigureNumber++;

            var creator = PrototypeCreator.GetInstance();

            if (_model.TmpGroup is null || _model.TmpGroup.IsEmpty())
            {
                creator.prototype = _selectedFigure.Clone();
            }
            else
            {
                creator.prototype = _model.TmpGroup.Clone();
            }

            _creators[figureName] = creator;

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
                _shiftPressed = true;

            if (ModifierKeys.HasFlag(Keys.Control) && e.KeyCode == Keys.Z)
            {
                _caretaker.Undo();
                Refresh();
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) 
                _shiftPressed = false;
        }

        private void btnUngroup_Click(object sender, EventArgs e)
        {
            if (_selectedFigure is null) return;

            if (_selectedFigure.GetType() == typeof(Group))
            {
                var group = (Group)_selectedFigure;

                foreach (var f in group.Figures)
                {
                    _model.Add(f.Clone());
                }
            }

            _model.Remove(_selectedFigure);

            _selectedFigure = null;
        }

        private void pnlDrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _model.Manipulator.Drag(e.X - _oldx, e.Y - _oldy);
                _model.Manipulator.Update();
                Refresh();
            }

            _oldx = e.X;
            _oldy = e.Y;
        }
    }
}
