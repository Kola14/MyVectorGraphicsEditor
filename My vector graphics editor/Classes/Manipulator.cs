using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MyVectorGraphicsEditor.Classes.Figures;

namespace MyVectorGraphicsEditor.Classes
{
    class Manipulator : Figure
    {
        private int ActivePoint = -1;

        public Figure Selected { get; private set; }

        public void Attach(Figure f)
        {
            Selected = f;
            if (f != null)
            {
                Move(f.X, f.Y);
                Resize(f.Width, f.Height);
            }
        }

        public void Drag(float dx, float dy)
        {
            switch (ActivePoint)
            {
                case 0:
                    Move(X + dx, Y + dy);
                    break;
                case 1:
                    Move(X + dx, Y + dy);
                    Resize(Width - dx, Height - dy);

                    if (Width < 0 && Height < 0)
                    {
                        Move(X + Width, Y + Height);
                        ActivePoint = 3;
                        Resize(Math.Abs(Width) + 10, Math.Abs(Height) + 10);
                    }

                    if (Width < 0)
                    {
                        ActivePoint = 2;
                        Move(X + Width, Y);
                        Resize(Math.Abs(Width) + 10, Height);
                    }

                    if (Height < 0)
                    {
                        ActivePoint = 4;
                        Move(X, Y + Height);
                        Resize(Width, Math.Abs(Height) + 10);
                    }

                    break;
                case 2:
                    Move(X, Y + dy);
                    Resize(Width + dx, Height - dy);

                    if (Width < 0 && Height < 0)
                    {
                        Move(X - Width, Y + Height);
                        ActivePoint = 4;

                        Resize(Math.Abs(Width) + 10, Math.Abs(Height) + 10);
                    }

                    if (Width < 0)
                    {
                        ActivePoint = 1;
                        Move(X + Width, Y);
                        Resize(Math.Abs(Width) + 10, Height);
                    }

                    if (Height < 0)
                    {
                        ActivePoint = 3;
                        Move(X, Y + Height);

                        Resize(Width, Math.Abs(Height) + 10);
                    }

                    break;
                case 3:
                    Resize(Width + dx, Height + dy);

                    if (Width < 0 && Height < 0)
                    {
                        Move(X + Width, Y + Height);
                        ActivePoint = 1;

                        Resize(Math.Abs(Width) + 10, Math.Abs(Height) + 10);
                    }

                    if (Width < 0)
                    {
                        ActivePoint = 4;
                        Move(X + Width, Y);

                        Resize(Math.Abs(Width) + 10, Height);
                    }

                    if (Height < 0)
                    {
                        ActivePoint = 2;
                        Move(X, Y + Height);

                        Resize(Width, Math.Abs(Height) + 10);
                    }

                    break;
                case 4:
                    Move(X + dx, Y);
                    Resize(Width - dx, Height + dy);

                    if (Width < 0 && Height < 0)
                    {
                        Move(X + Width, Y + Height);
                        ActivePoint = 3;

                        Resize(Math.Abs(Width) + 10, Math.Abs(Height) + 10);
                    }

                    if (Width < 0)
                    {
                        ActivePoint = 3;
                        Move(X + Width, Y);

                        Resize(Math.Abs(Width) + 10, Height);
                    }

                    if (Height < 0)
                    {
                        ActivePoint = 1;
                        Move(X, Y + Height);

                        Resize(Width, Math.Abs(Height) + 10);
                    }

                    break;
            }

        }

        public override bool Touch(float ax, float ay)
        {
            ActivePoint = -1;
            if (Math.Abs(ax - X) < 5 && Math.Abs(ay - Y) < 5)
            {
                ActivePoint = 1;
                return true;
            }
            else if (Math.Abs(ax - X - Width) < 5 && Math.Abs(ay - Y) < 5)
            {
                ActivePoint = 2;
                return true;
            }
            else if (Math.Abs(ax - X - Width) < 5 && Math.Abs(ay - Y - Height) < 5)
            {
                ActivePoint = 3;
                return true;
            }
            else if (Math.Abs(ax - X) < 5 && Math.Abs(ay - Y - Height) < 5)
            {
                ActivePoint = 4;
                return true;
            }
            else if (base.Touch(ax, ay))
            {
                ActivePoint = 0;
                return true;
            }

            return false;
        }

        public override void Draw(Graphics graphics)
        {
            if (Selected is null) return;
            graphics.DrawRectangle(Pens.Red, X - 2, Y - 2, Width + 4, Height + 4);
            graphics.FillRectangle(Brushes.Red, X-5, Y-5, 5, 5);
            graphics.FillRectangle(Brushes.Red, X + Width, Y - 5, 5, 5);
            graphics.FillRectangle(Brushes.Red, X + Width, Y + Height, 5, 5);
            graphics.FillRectangle(Brushes.Red, X - 5, Y + Height, 5, 5);
            graphics.FillRectangle(Brushes.Red, X + Width / 2 - 2,  Y + Height / 2 - 2, 5, 5);

        }

        public void Update()
        {
            if (Selected is null) return;
            Selected.Move(X, Y);
            Selected.Resize(Width, Height);
        }
    }
}
