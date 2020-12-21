using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Game.Entities;
using SFML.Graphics;
using SFML.System;

namespace Game.Entities
{
    public class Trigger:Entity
    {
        EntityParam text;
        EntityParam SizeX;
        EntityParam SizeY;
        Collision collision = new Collision();
        public Trigger()
        {

            collisions = new Collision[1];
            collision.owner = this;
            collisions[0] = collision;

            Trigger = true;
            HideInGame = true;
            //Console.WriteLine("trigger");
            SetTexture("playerIdle");

            SizeX = new EntityParam("Size X", "100");
            SizeY = new EntityParam("Size Y", "100");
            text = new EntityParam("Text", "Hello world!");

            entityParams.Add(SizeX);
            entityParams.Add(SizeY);
            entityParams.Add(text);

            type = "Trigger";


            collision.position = position;
            collision.size = new Vector2f(float.Parse(SizeX.value), float.Parse(SizeY.value));

        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
            collision.size = new Vector2f(float.Parse(SizeX.value), float.Parse(SizeY.value));
            collision.position = position;
            foreach (Entity ent in GameMain.curentLevel.entities)
            {
                if (!ent.Trigger)
                    if(Collision.MakeCollionTest(collision,ent.collisions[0]))
                    {
                        Console.WriteLine(text.value);
                    }
            }

        }

        public virtual void OnTriggerStay()
        {

        }

        public override void UpdateCollision()
        {
            collision.position = position;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            try
            {
                collision.position = position;
                collision.size = new Vector2f(float.Parse(SizeX.value), float.Parse(SizeY.value));
                RectangleShape box = new RectangleShape();
                box.Position = new Vector2f(position.X - collision.size.X / 2, -position.Y - collision.size.Y / 2);
                box.Size = collision.size;
                box.FillColor = new Color(0, 255, 0, 150);
                target.Draw(box);
            }catch(SystemException)
            {

            }
        }
        
    }
}
