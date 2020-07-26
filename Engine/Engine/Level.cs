using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using Engine.Entities;
namespace Engine
{
    class Level
    {

        public static List<Entity> entities = new List<Entity>();
        public static List<Brush> brushes = new List<Brush>();
        public static List<Collision> collisions = new List<Collision>();

        public static void Start()
        {

            Player player = new Player();
            
            entities.Add(player);
            player.position = new Vector2f(0, -320);

            Brush brush = new Brush();
            brush.SetTexture(new Texture("brush.png"));
            brush.SetSize(new Vector2i(1000,300));
            brush.SetPosition(new Vector2i(0,-500));
            brushes.Add(brush);

            Brush brush2 = new Brush();
            brush2.SetTexture(new Texture("brush.png"));
            brush2.SetSize(new Vector2i(1000, 300));
            brush2.SetPosition(new Vector2i(20, -150));
            brushes.Add(brush2);

            foreach (Entity ent in entities)
            {
                ent.Start();
            }
        }
        public static void Update()
        {
            foreach (Entity ent in entities)
            {

                ent.Update();

            }
        }

    }
}
