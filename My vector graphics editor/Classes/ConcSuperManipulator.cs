using System.Collections.Generic;
using MyVectorGraphicsEditor.Classes.Handlers;

namespace MyVectorGraphicsEditor.Classes
{
    class ConcSuperManipulator: SuperManipulator
    {
        public ConcSuperManipulator() : base()
        {
            handlers = new List<Handler>(new Handler[]
            {
                new TopLeftHandler(this), new TopRightHandler(this),
                new BottomLeftHandler(this), new BottomRightHandler(this), new DefaultHandler(this)
            });
        }

        public override void Attach(Figure f)
        {
            base.Attach(f);

            handlers = new List<Handler>(new Handler[]
            {
                new TopLeftHandler(this), new TopRightHandler(this),
                new BottomLeftHandler(this), new BottomRightHandler(this), new DefaultHandler(this)
            });
        }
    }
}
