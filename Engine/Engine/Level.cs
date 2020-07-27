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

        public List<Entity> entities = new List<Entity>();
        public List<Brush> brushes = new List<Brush>();
        public List<Collision> collisions = new List<Collision>();

        public void Start()
        {

            foreach (Entity ent in entities)
            {
                ent.Start();
            }
        }
        public void Update()
        {
            Console.WriteLine("update");
            foreach (Entity ent in entities)
                ent.Update();
        }

    }
}
