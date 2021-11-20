using System;
using System.Collections.Generic;
using System.Text;
using Figures;

namespace Figures
{
    public abstract class FigureCreator
    {
        public virtual Figure Create()
        {
            return null;
        }
    }
}
