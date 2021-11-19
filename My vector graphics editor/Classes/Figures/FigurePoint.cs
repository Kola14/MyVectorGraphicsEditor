using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyVectorGraphicsEditor.Classes.Figures
{
    class FigurePoint: Figure
    {
        public FigurePoint(float x, float y)
        {
            base.Move(x, y);
            base.Resize(1,1);
        }

        public override void Draw(Graphics graphics)
        {
            
        }

        public override void Resize(float newWidth, float newHeight)
        {
           
        }

        
    }
}
