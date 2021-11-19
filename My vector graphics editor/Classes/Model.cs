using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MyVectorGraphicsEditor.Classes.Figures;

namespace MyVectorGraphicsEditor.Classes
{
    class Model
    {
        public enum Command
        {
            Add,
            Remove
        }

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

            figures.Add(f);
        }

        public void Remove(Figure f)
        {
            if (f is null) return;

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

            foreach (var f in figures)
            {
                if (f.Touch(x, y))
                {
                    Manipulator.Attach(f);
                    return f;
                }
            }
            //Manipulator.Attach(null);
            Manipulator = new ConcSuperManipulator();
            return null;
        }

        public void UnGroup()
        {
            TmpGroup = new Group();
        }

        public void Save()
        {

        }

        public void Restore()
        {

        }
    }
}
