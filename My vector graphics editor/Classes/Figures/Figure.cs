using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyVectorGraphicsEditor.Classes
{
    public abstract class Figure
    {
        private float x;
        private float y;
        private float width;
        private float height;
               
        public float X { get { return x; } }
        public float Y { get { return y; } }
        public float Width { get { return width; } }
        public float Height { get { return height; } }

        public virtual void Move(float newX, float newY)
        {
            x = newX;
            y = newY;
        }

        public virtual void Resize(float newWidth, float newHeight)
        {
            width = newWidth;
            height = newHeight;
        }

        public virtual bool Touch(float ax, float ay)
        {
            return ax >= x && ax <= x + width && ay >= y && ay <= y + height;
        }

        public virtual Figure Clone()
        {
            return null;
        }

        public abstract void Draw(Graphics graphics);
    }
}
