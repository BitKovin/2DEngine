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

        public Level Clone()
        {
            Level clone = new Level();

            foreach(Brush brush in brushes)
            {
                Brush brushClone = new Brush();
                clone.brushes.Add(brushClone);
                brushClone.SetPosition(brush.position);
                brushClone.SetSize(brush.size);
                brushClone.SetTexture(brush.texture);
            }

            foreach(Entity entity in entities)
            {
                Entity ent = entity.GetCopy();
                clone.entities.Add(ent);
            }

            return clone;
        }

        public void Start()
        {

            foreach (Entity ent in entities)
            {
                ent.Start();
            }

            foreach (Brush bruh in brushes)
            {
                bruh.Init();
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
