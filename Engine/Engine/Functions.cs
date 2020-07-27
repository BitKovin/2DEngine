using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using SFML.System;
using SFML.Graphics;
using Engine.Entities;

namespace Engine
{
    class Functions
    {

        public static Vector2f Vector2ToVector2f(Vector2 vec2)
        {
            return new Vector2f(vec2.X, vec2.Y);
        }

        public static Vector2 Vector2fToVector2(Vector2f vec2f)
        {
            return new Vector2(vec2f.X, vec2f.Y);
        }

        public static void MakeBase(Level lvl)
        {
            Player player = new Player();

            lvl.entities.Add(player);
            player.position = new Vector2f(0, -320);

            Brush brush = new Brush(lvl);
            brush.SetTexture(new Texture("brush.png"));
            brush.SetSize(new Vector2i(1000, 300));
            brush.SetPosition(new Vector2i(0, -500));
            lvl.brushes.Add(brush);

            Brush brush2 = new Brush(lvl);
            brush2.SetTexture(new Texture("brush.png"));
            brush2.SetSize(new Vector2i(1000, 300));
            brush2.SetPosition(new Vector2i(20, -150));
            lvl.brushes.Add(brush2);
        }

        public static Entity EntityFromString(string name)
        {
            switch (name)
            {
                case("Player"):
                    Console.WriteLine("playerSpawned");
                    return new Player();

                case (null):
                    Console.WriteLine("null");
                    break;
            }
            return null;
        }

    }
}
