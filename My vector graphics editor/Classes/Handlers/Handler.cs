using System.Drawing;

namespace MyVectorGraphicsEditor.Classes.Handlers
{
    class Handler : Figure
    {
        protected Figure manipulator;

        public Handler(Figure f)
        {
            manipulator = f;
        }

        public virtual void Drag(float ax, float ay) { }

        public override void Draw(Graphics graphics)
        {
            
        }

        public virtual void Reposition() {}

        public virtual Handler PickNewHandler()
        {
            return null;
        }
    }
}
