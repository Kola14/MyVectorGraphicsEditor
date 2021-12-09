using MyVectorGraphicsEditor.Classes;
using MyVectorGraphicsEditor.Classes.Figures;
using System;
using System.Linq;
using System.Windows.Forms;
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
        private int _newFigureNumber;
        private bool _shiftPressed;

        private Editor _editor;

        private CreatorsManager manager = new CreatorsManager();

        public MainForm()
        {
            InitializeComponent();

            //LoadConfig();

            //_model = new Model();
            //_caretaker = new Caretaker(_model);

            _editor = new Editor();
            _editor.AttachToolStrip(toolStrip1);
            _editor.LoadConfig();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadConfig()
        {
            manager.LoadConfig();

            foreach (var creator in manager.Creators)
            {
                var button = new ToolStripButton();
                button.Text = creator.Key;
                button.Click += toolStripButton_Click;
                toolStrip1.Items.Add(button);
            }
        }

        private void pnlDrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //if (_selectedCreator != null)
            if (_editor.CurrentCreatorIsNull)
            {
                //_model.UnGroup();
                //var figure = _selectedCreator.Create();
                //figure.Move(e.X, e.Y);
                //_model.Add(figure);
                //_caretaker.Backup();

                _editor.Select(sender, e);
            }
            else
            {
                _editor.UseCreator(sender, e);

                //if (_shiftPressed)
                //{
                //    _selectedFigure = _model.Select(e.X, e.Y);
                //    _model.TmpGroup.Add(_selectedFigure);
                //    _model.Manipulator.Attach(_model.TmpGroup);
                //}
                //else
                //{
                //    _selectedFigure = _model.Select(e.X, e.Y);
                //    _model.UnGroup();
                //}
            }
        }

        private void toolStripButton_Click(Object sender, EventArgs e)
        {
            //var key = (sender as ToolStripButton)?.Text;
            //if (manager.Creators.Keys.Contains(key))
            //{
            //    if (key != null) _selectedCreator = manager.Creators[key];
            //}

            _editor.ButtonClick(sender, e);

            //_model.ButtonClick(sender, e);
        }

        private void pnlDrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            //_model.Draw(e.Graphics);

            _editor.DrawModel(sender, e);
            Refresh();
        }

        private void btnSaveFigure_Click(object sender, EventArgs e)
        {
            _editor.SaveFigure();

            //if (_selectedFigure is null) return;

            //var figureName = $"Custom_figure_{_newFigureNumber}";
            //_newFigureNumber++;

            //var creator = PrototypeCreator.GetInstance();

            //if (_model.TmpGroup is null || _model.TmpGroup.IsEmpty())
            //{
            //    creator.prototype = _selectedFigure.Clone();
            //}
            //else
            //{
            //    creator.prototype = _model.TmpGroup.Clone();
            //}

            //manager.AddCreator(creator, figureName);

            //var btn = new ToolStripButton();
            //btn.Text = figureName;
            //btn.Click += toolStripButton_Click;

            //toolStrip1.Items.Add(btn);

            //manager.SaveCreator(creator, figureName);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) 
                _editor.ShiftPressed = true;

            if (ModifierKeys.HasFlag(Keys.Control) && e.KeyCode == Keys.Z)
            {
                //_caretaker.Undo();
                _editor.Undo();
                Refresh();
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                _editor.ShiftPressed = false;
        }

        private void btnUngroup_Click(object sender, EventArgs e)
        {
            _editor.Ungroup();


            //if (_selectedFigure is null) return;

            //if (_selectedFigure.GetType() == typeof(Group))
            //{
            //    var group = (Group)_selectedFigure;

            //    foreach (var f in group.Figures)
            //    {
            //        _model.Add(f.Clone());
            //    }
            //}

            //_model.Remove(_selectedFigure);

            //_selectedFigure = null;
        }

        private void btnToCustom_Click(object sender, EventArgs e)
        {
            //if (_selectedFigure is null) return;

            //if (_selectedFigure.GetType() == typeof(Group)) return;

            //_model.ToCustom(_selectedFigure);

            _editor.ToCustom();

            Refresh();
        }

        private void pnlDrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    _model.Manipulator.Drag(e.X - _oldx, e.Y - _oldy); 
            //    _model.Manipulator.Update();
            //    Refresh();
            //}

            //_oldx = e.X;
            //_oldy = e.Y;

            _editor.Move(sender, e);
            Refresh();
        }
    }
}
