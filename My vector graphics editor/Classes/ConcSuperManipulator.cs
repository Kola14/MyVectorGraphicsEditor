using System.Collections.Generic;
using System.Net.Http.Headers;
using Figures;
using MyVectorGraphicsEditor.Classes.Figures;
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
            if (f.GetType() == typeof(FigurePoint))
            {
                handlers = new List<Handler>();
                handlers.Add(new CustomHandler(f));
                return;
            }

            base.Attach(f);

            handlers = new List<Handler>(new Handler[]
            {
                new TopLeftHandler(this), new TopRightHandler(this),
                new BottomLeftHandler(this), new BottomRightHandler(this), new DefaultHandler(this)
            });
        }
    }
}
