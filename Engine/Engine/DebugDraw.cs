using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Engine
{
    public static class DebugDraw
    {
        public static bool enabled = false;
        static List<Drawable> objs= new List<Drawable>();

        public static void Reset()
        {
            objs.Clear();
        }

        public static void AddRectangle(Vector2f pos, Vector2f size, Color color)
        {
            RectangleShape rectangleShape = new RectangleShape();
            rectangleShape.Position = new Vector2f(pos.X,-pos.Y);
            rectangleShape.Size = size;
            rectangleShape.FillColor = Color.Transparent;
            rectangleShape.OutlineThickness = 1;
            rectangleShape.OutlineColor = new Color(color.R,color.G,color.B,200);
            rectangleShape.Origin = new Vector2f(size.X / 2f, size.Y / 2f);

            objs.Add(rectangleShape);
        }

        public static void Draw(RenderWindow window)
        {
            foreach(Drawable draw in objs)
                window.Draw(draw);
        }

    }
}
