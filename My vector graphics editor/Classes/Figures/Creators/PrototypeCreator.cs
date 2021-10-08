using System;
using System.Collections.Generic;
using System.Text;

namespace MyVectorGraphicsEditor.Classes.Figures
{
    class PrototypeCreator : FigureCreator
    {
        public Figure prototype { get; set; }

        private static PrototypeCreator instance = null;

        private PrototypeCreator() { }

        public static PrototypeCreator GetInstance()
        {
            if (instance is null) instance = new PrototypeCreator();

            return instance;
        }

        public override Figure Create()
        {
            if (prototype is null) return null;
            return prototype.Clone();
        }
    }
}
