using System;
using System.Collections.Generic;
using System.Text;

namespace MyVectorGraphicsEditor.Classes.Figures
{
    abstract class FigureCreator
    {
        public virtual Figure Create()
        {
            return null;
        }
    }
}
