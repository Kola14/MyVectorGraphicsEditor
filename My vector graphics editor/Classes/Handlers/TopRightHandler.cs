using System;
using System.Drawing;
using Figures;

namespace MyVectorGraphicsEditor.Classes.Handlers
{
    class TopRightHandler: Handler
    {
        public TopRightHandler(Figure f) : base(f)
        {
            Resize(6, 6);
            Move(f.X + f.Width - 3, f.Y - 3);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, X, Y, Width, Height);
        }

        public override void Drag(float x, float y)
        {
            manipulator.Move(manipulator.X, manipulator.Y + y);
            manipulator.Resize(manipulator.Width + x, manipulator.Height - y);
        }

        public override void Reposition()
        {
            Move(manipulator.X + manipulator.Width - 3, manipulator.Y - 3);
        }

        public override Handler PickNewHandler()
        {
            var x = manipulator.X;
            var y = manipulator.Y;
            var width = manipulator.Width;
            var height = manipulator.Height;

            if (width < 0 && height < 0)
            {
                manipulator.Move(x - width, y + height);
                //ActivePoint = 4;

                manipulator.Resize(Math.Abs(width) + 10, Math.Abs(height) + 10);

                return new BottomLeftHandler(manipulator);
            }

            if (width < 0)
            {
                //ActivePoint = 1;
                manipulator.Move(x + width, y);
                manipulator.Resize(Math.Abs(width) + 10, height);

                return new TopLeftHandler(manipulator);
            }

            if (height < 0)
            {
                //ActivePoint = 3;
                manipulator.Move(x, y + height);

                manipulator.Resize(width, Math.Abs(height) + 10);

                return new BottomRightHandler(manipulator);
            }

            return new TopRightHandler(manipulator);
        }
    }
}
