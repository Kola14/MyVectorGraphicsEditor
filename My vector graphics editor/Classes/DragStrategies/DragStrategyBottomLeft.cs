using System;

namespace MyVectorGraphicsEditor.Classes.DragStrategies
{
    class DragStrategyBottomLeft: DragStrategy
    {
        public override DragStrategy Drag(Figure figure, float dx, float dy)
        {
            var x = figure.X;
            var y = figure.Y;
            var width = figure.Width;
            var height = figure.Height;

            figure.Move(x + dx, y);
            figure.Resize(width - dx, height + dy);

            if (width < 0 && height < 0)
            {
                figure.Move(x + width, y + height);
                //ActivePoint = 3;

                figure.Resize(Math.Abs(width) + 10, Math.Abs(height) + 10);

                return new DragStrategyBottomRight();
            }

            if (width < 0)
            {
                //ActivePoint = 3;
                figure.Move(x + width, y);

                figure.Resize(Math.Abs(width) + 10, height);

                return new DragStrategyBottomRight();
            }

            if (height < 0)
            {
                //ActivePoint = 1;
                figure.Move(x, y + height);

                figure.Resize(width, Math.Abs(height) + 10);

                return new DragStrategyTopLeft();
            }

            return new DragStrategyBottomLeft();
        }
    }
}
