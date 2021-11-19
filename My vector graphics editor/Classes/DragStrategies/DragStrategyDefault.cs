namespace MyVectorGraphicsEditor.Classes.DragStrategies
{
    class DragStrategyDefault: DragStrategy
    {
        public override DragStrategy Drag(Figure figure, float dx, float dy)
        {
            figure.Move(figure.X + dx, figure.Y + dy);
            return new DragStrategyDefault();
        }
    }
}
