using System;
using System.Drawing;

namespace MyVectorGraphicsEditor.Classes.Handlers
{
    class BottomRightHandler: Handler
    {
        public BottomRightHandler(Figure f) : base(f)
        {
            Resize(6, 6);
            Move(f.X + f.Width - 3, f.Y + f.Height - 3);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, X, Y, Width, Height);
        }

        public override void Drag(float x, float y)
        {
            manipulator.Resize(manipulator.Width + x, manipulator.Height + y);
            Reposition();
        }

        public override void Reposition()
        {
            Move(manipulator.X + manipulator.Width - 3, manipulator.Y + manipulator.Height - 3);
        }

        public override Handler PickNewHandler()
        {
            var x = manipulator.X;
            var y = manipulator.Y;
            var width = manipulator.Width;
            var height = manipulator.Height;

            if (width < 0 && height < 0)
            {
                manipulator.Move(x + width, y + height);
                //ActivePoint = 1;

                manipulator.Resize(Math.Abs(width) + 10, Math.Abs(height) + 10);

                return new TopLeftHandler(manipulator);
            }

            if (width < 0)
            {
                //ActivePoint = 4;
                manipulator.Move(x + width, y);

                manipulator.Resize(Math.Abs(width) + 10, height);

                return new BottomLeftHandler(manipulator);
            }

            if (height < 0)
            {
                //ActivePoint = 2;
                manipulator.Move(x, y + height);

                manipulator.Resize(width, Math.Abs(height) + 10);

                return new TopRightHandler(manipulator);
            }

            return new BottomRightHandler(manipulator);
        }
    }
}
