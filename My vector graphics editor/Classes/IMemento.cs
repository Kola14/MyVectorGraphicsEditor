using Figures;

namespace MyVectorGraphicsEditor.Classes
{
    public interface IMemento
    {
        public enum Command
        {
            Add,
            Remove
        }

        (Command, Figure) GetState();
    }
}
