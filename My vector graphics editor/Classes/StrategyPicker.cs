using System;
using MyVectorGraphicsEditor.Classes.DragStrategies;

namespace MyVectorGraphicsEditor.Classes
{
    class StrategyPicker
    {
        public static DragStrategy PickStrategy(Figure figure, float ax, float ay)
        {
            var x = figure.X;
            var y = figure.Y;
            var width = figure.Width;
            var height = figure.Height;

            if (Math.Abs(ax - x) < 5 && Math.Abs(ay - y) < 5)
            {
                return new DragStrategyTopLeft();
            }

            if (Math.Abs(ax - x - width) < 5 && Math.Abs(ay - y) < 5)
            {
                return new DragStrategyTopRight();
            }

            if (Math.Abs(ax - x - width) < 5 && Math.Abs(ay - y - height) < 5)
            {
                return new DragStrategyBottomRight();
            }

            if (Math.Abs(ax - x) < 5 && Math.Abs(ay - y - height) < 5)
            {
                return new DragStrategyBottomLeft();
            }

            return null;
        }
    }
}
