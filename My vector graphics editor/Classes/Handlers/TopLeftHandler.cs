﻿using System;
using System.Drawing;

namespace MyVectorGraphicsEditor.Classes.Handlers
{
    class TopLeftHandler: Handler
    {
        public TopLeftHandler(Figure f) : base(f)
        {
            Resize(6, 6);
            Move(f.X - 3, f.Y - 3);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, X, Y, Width, Height);
        }

        public override void Drag(float x, float y)
        {
            manipulator.Move(manipulator.X + x, manipulator.Y + y);
            manipulator.Resize(manipulator.Width - x, manipulator.Height - y);
            Reposition();
        }

        public override void Reposition()
        {
            Move(manipulator.X - 3, manipulator.Y - 3);
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
                //ActivePoint = 3;
                manipulator.Resize(Math.Abs(width) + 10, Math.Abs(height) + 10);
                return new BottomRightHandler(manipulator);
            }

            if (width < 0)
            {
                //ActivePoint = 2;
                manipulator.Move(x + width, y);
                manipulator.Resize(Math.Abs(width) + 10, height);
                return new TopRightHandler(manipulator);
            }

            if (height < 0)
            {
                //ActivePoint = 4;
                manipulator.Move(x, y + height);
                manipulator.Resize(width, Math.Abs(height) + 10);
            }

            return new TopLeftHandler(manipulator);
        }
    }
}