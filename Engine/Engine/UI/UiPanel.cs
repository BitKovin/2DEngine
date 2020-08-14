using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Engine.UI
{
    class UiPanel: UiElement
    {
        public RectangleShape r_rectangle;
        public Vector2f position;
        public Vector2f size;
        public bool hovered;
        public Collision collision;
        public Color color = new Color(0,0,0,100);

        public UiPanel()
        {
            r_rectangle = new RectangleShape();
            r_rectangle.FillColor = new Color(100, 100, 100);

            collision = new Collision();
        }


        public override void Update()
        {
            base.Update();

            Vector2f origin = new Vector2f();

            switch (originH)
            {
                case Origin.Left:
                    origin += Left;
                    break;
                case Origin.Right:
                    origin += Right;
                    break;
                case Origin.Top:
                    origin += Top;
                    break;
                case Origin.Bottom:
                    origin += Bottom;
                    break;
                case Origin.Centre:
                    origin += Center;
                    break;
                default:
                    break;
            }

            switch (originV)
            {
                case Origin.Left:
                    origin += Left;
                    break;
                case Origin.Right:
                    origin += Right;
                    break;
                case Origin.Top:
                    origin += Top;
                    break;
                case Origin.Bottom:
                    origin += Bottom;
                    break;
                case Origin.Centre:
                    origin += Center;
                    break;
                default:
                    break;
            }

            collision.position = new Vector2f(position.X, -position.Y) + new Vector2f(Camera.position.X, -Camera.position.Y) + new Vector2f(origin.X, -origin.Y);
            collision.size = size;

            Collision MouseCol = new Collision();

            MouseCol.position = Input.MousePos;
            MouseCol.size = new Vector2f(2, 2);

            hovered = Collision.MakeCollionTest(collision, MouseCol);

            if (hovered)
                UiManager.UiHover = true;
        }

        public override void draw(RenderTarget target, RenderStates states)
        {

            Vector2f origin = new Vector2f();

            switch (originH)
            {
                case Origin.Left:
                    origin += Left;
                    break;
                case Origin.Right:
                    origin += Right;
                    break;
                case Origin.Top:
                    origin += Top;
                    break;
                case Origin.Bottom:
                    origin += Bottom;
                    break;
                case Origin.Centre:
                    origin += Center;
                    break;
                default:
                    break;
            }

            switch (originV)
            {
                case Origin.Left:
                    origin += Left;
                    break;
                case Origin.Right:
                    origin += Right;
                    break;
                case Origin.Top:
                    origin += Top;
                    break;
                case Origin.Bottom:
                    origin += Bottom;
                    break;
                case Origin.Centre:
                    origin += Center;
                    break;
                default:
                    break;
            }

            r_rectangle.FillColor = color;
            r_rectangle.Position =Renderer.view.Center-size/2+origin+position;
            r_rectangle.Size = size;
            r_rectangle.OutlineThickness = 1;
            r_rectangle.OutlineColor = Color.Black;
            Console.WriteLine(r_rectangle.Position);

            target.Draw(r_rectangle);
        }
    }
}
