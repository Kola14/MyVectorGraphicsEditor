using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Figures;
using MyVectorGraphicsEditor.Classes.Figures;

namespace MyVectorGraphicsEditor.Classes
{
    class Model
    {
        public (IMemento.Command, Figure) State { get; private set; }

        private List<Figure> figures = new List<Figure>();

        public SuperManipulator Manipulator { get; private set; }

        public Group TmpGroup { get; private set; }

        public Model()
        {
            Manipulator = new ConcSuperManipulator();
            TmpGroup = new Group();
            Add(TmpGroup);
        }

        public void Add(Figure f)
        {
            if (f is null) return;
            if (figures.Contains(f)) return;
            State = (IMemento.Command.Add, f);
            figures.Add(f);
        }

        public void Remove(Figure f)
        {
            if (f is null) return;

            State = (IMemento.Command.Remove, f);

            figures.Remove(f);
            Manipulator = new ConcSuperManipulator();
        }

        public void Draw(Graphics g)
        {
            foreach (var f in figures)
            {
                f.Draw(g);
            }
            Manipulator.Draw(g);
        }

        public Figure Select(int x, int y)
        {
            if (Manipulator.Touch(x, y))
            {
                return Manipulator.Selected;
            }

            foreach (var f in figures.Where(f => f.Touch(x, y)))
            {
                if (f.GetType() == typeof(CustomFigure))
                {

                    Manipulator = new CustomSuperManipulator();
                    Manipulator.Attach(f);
                    return f;
                }
                
                Manipulator.Attach(f);
                return f;
            }

            //Manipulator.Attach(null);
            Manipulator = new ConcSuperManipulator();
            return null;
        }

        public void UnGroup()
        {
            TmpGroup = new Group();
        }

        public IMemento Save()
        {
            return new Memento(State);
        }

        public void Restore(IMemento memento)
        {
            State = memento.GetState();
        }

        public void ToCustom(Figure f)
        {
            if (f is null) return;

            Manipulator = new CustomSuperManipulator();

            CustomFigure custom = new CustomFigure(f);
            Remove(f);
            Add(custom);

            Manipulator.Attach(custom);

            Remove(f);
        }
    }
}
