using System;

namespace MyVectorGraphicsEditor.Classes.DragStrategies
{
    class DragStrategyTopRight: DragStrategy
    {
        public override DragStrategy Drag(Figure figure, float dx, float dy)
        {
            var x = figure.X;
            var y = figure.Y;
            var width = figure.Width;
            var height = figure.Height;

            figure.Move(x, y + dy);
            figure.Resize(width + dx, height - dy);

            if (width < 0 && height < 0)
            {
                figure.Move(x - width, y + height);
                //ActivePoint = 4;

                figure.Resize(Math.Abs(width) + 10, Math.Abs(height) + 10);

                return new DragStrategyBottomLeft();
            }

            if (width < 0)
            {
                //ActivePoint = 1;
                figure.Move(x + width, y);
                figure.Resize(Math.Abs(width) + 10, height);

                return new DragStrategyTopLeft();
            }

            if (height < 0)
            {
                //ActivePoint = 3;
                figure.Move(x, y + height);

                figure.Resize(width, Math.Abs(height) + 10);

                return new DragStrategyBottomRight();
            }

            return new DragStrategyTopRight();
        }
    }
}
