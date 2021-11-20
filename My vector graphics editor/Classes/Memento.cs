using Figures;

namespace MyVectorGraphicsEditor.Classes
{
    class Memento: IMemento
    {
        private (IMemento.Command, Figure) state;

        public (IMemento.Command, Figure) GetState()
        {
            return state;
        }

        public Memento((IMemento.Command, Figure) state)
        {
            this.state = state;
        }
    }
}
