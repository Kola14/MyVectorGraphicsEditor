using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Figures;
using MyVectorGraphicsEditor.Classes;
using MyVectorGraphicsEditor.Classes.Figures;

namespace MyVectorGraphicsEditor.Classes
{
    class Editor
    {
        public bool ShiftPressed { get; set; }
        public bool CurrentCreatorIsNull
        {
            get => _selectedCreator == null;
        }


        private Model _model;
        private CreatorsManager _manager = new CreatorsManager();
        private ToolStrip _toolStrip;
        private FigureCreator _selectedCreator;
        private Figure _selectedFigure;
        private int _newFigureNumber;
        private Caretaker _caretaker;
        private int _oldx, _oldy;

        public Editor()
        {
            _model = new Model();
            _caretaker = new Caretaker(_model);
        }

        public void AttachToolStrip(ToolStrip toolStrip)
        {
            _toolStrip = toolStrip;
        }

        public void LoadConfig()
        {
            _manager.LoadConfig();

            foreach (var creator in _manager.Creators)
            {
                var button = new ToolStripButton();
                button.Text = creator.Key;
                button.Click += ButtonClick;
                _toolStrip.Items.Add(button);
            }
        }

        public void ButtonClick(Object sender, EventArgs e)
        {
            var key = (sender as ToolStripButton)?.Text;

            if (_manager.Creators.Keys.Contains(key))
            {
                if (key != null) _selectedCreator = _manager.Creators[key];
            }
        }

        public void SaveFigure()
        {
            if (_selectedFigure is null) return;

            var figureName = $"Custom_figure_{_newFigureNumber}";
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

            _manager.AddCreator(creator, figureName);

            var btn = new ToolStripButton();
            btn.Text = figureName;
            btn.Click += ButtonClick;

            _toolStrip.Items.Add(btn);

            _manager.SaveCreator(creator, figureName);
        } 

        public void UseCreator(object sender, MouseEventArgs e)
        {
            _model.UnGroup();
            var figure = _selectedCreator.Create();
            figure.Move(e.X, e.Y);
            _model.Add(figure);
            _caretaker.Backup();
        }

        public void Select(object sender, MouseEventArgs e)
        {
            if (ShiftPressed)
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

        public void Undo()
        {
            _caretaker.Undo();
        }

        public void Ungroup()
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

        public void ToCustom()
        {
            if (_selectedFigure is null) return;

            if (_selectedFigure.GetType() == typeof(Group)) return;

            _model.ToCustom(_selectedFigure);
        }

        public void Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _model.Manipulator.Drag(e.X - _oldx, e.Y - _oldy);
                _model.Manipulator.Update();
            }

            _oldx = e.X;
            _oldy = e.Y;
        }

        public void DrawModel(object sender, PaintEventArgs e)
        {
            _model.Draw(e.Graphics);
        }
    }
}
