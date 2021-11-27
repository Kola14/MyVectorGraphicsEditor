using System.Collections.Generic;
using System.Drawing;
using Figures;
using MyVectorGraphicsEditor.Classes.Handlers;

namespace MyVectorGraphicsEditor.Classes
{
    class SuperManipulator : Figure
    {
        protected List<Handler> handlers = new List<Handler>();

        public Figure Selected { get; protected set; }

        public Handler ActiveHandler { get; protected set; }

        public override void Draw(Graphics graphics)
        {
            if (Selected is null) return;

            graphics.DrawRectangle(Pens.Red, X - 2, Y - 2, Width + 4, Height + 4);

            foreach (var h in handlers)
            {
                h.Reposition();
                h.Draw(graphics);
            }
        }

        public override bool Touch(float ax, float ay)
        {
            foreach (var h in handlers)
            {
                if (h.Touch(ax, ay))
                {
                    ActiveHandler = h;
                    return true;
                }
            }

            ActiveHandler = null;
            return false;
        }

        public void Drag(float dx, float dy)
        {
            ActiveHandler?.Drag(dx, dy);
            ActiveHandler = ActiveHandler?.PickNewHandler();
        }

        public virtual void Attach(Figure f)
        {
            Selected = f;

            if (Selected is null) return;

            Move(f.X, f.Y);

            Resize(f.Width, f.Height);

            Update();
        }

        public virtual void Update()
        {
            if (Selected is null) return;
            Selected.Move(X, Y);
            Selected.Resize(Width, Height);
        }
    }
}
