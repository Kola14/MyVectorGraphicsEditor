using System;
using System.Collections.Generic;
using System.Linq;

namespace MyVectorGraphicsEditor.Classes
{
    class Caretaker
    {
        private List<IMemento> mementos = new List<IMemento>();

        private Model model;

        public Caretaker(Model model)
        {
            this.model = model;
        }

        public void Backup()
        {
            //mementos.Add(model.Save());
        }

        public void Undo()
        {
            if (mementos.Count == 0) return;

            var memento = mementos.Last();

            switch (memento.GetState().Item1)
            {
                case IMemento.Command.Remove:
                    model.Add(memento.GetState().Item2);
                    break;
                case IMemento.Command.Add:
                    model.Remove(memento.GetState().Item2);
                    break;
            }

            mementos.Remove(memento);

            try
            {
                //model.Restore(memento);
            }
            catch (Exception)
            {
                Undo();
            }
        }
    }
}
