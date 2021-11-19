namespace MyVectorGraphicsEditor.Classes
{
    abstract class DragStrategy
    {
        public abstract DragStrategy Drag(Figure figure, float dx, float dy);
    }
}
