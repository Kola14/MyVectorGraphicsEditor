using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Figures;

namespace Figures
{
    [Serializable]
    public abstract class Figure
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }

        public virtual void Move(float newX, float newY)
        {
            X = newX;
            Y = newY;
        }

        public virtual void Resize(float newWidth, float newHeight)
        {
            Width = newWidth;
            Height = newHeight;
        }

        public virtual bool Touch(float ax, float ay)
        {
            return ax >= X && ax <= X + Width && ay >= Y && ay <= Y + Height;
        }

        public virtual Figure Clone()
        {
            return null;
        }

        public abstract void Draw(Graphics graphics);
    }
}
