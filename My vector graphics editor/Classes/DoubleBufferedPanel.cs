using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyVectorGraphicsEditor.Classes
{
    class DoubleBufferedPanel: Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}

