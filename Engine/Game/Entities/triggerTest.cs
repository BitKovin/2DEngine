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
    public class TriggerTest:Entity
    {
        EntityParam text;
        EntityParam SizeX;
        EntityParam SizeY;
        Collision collision = new Collision();
        public TriggerTest()
        {



            collisions = new Collision[1];
            collision.owner = this;
            collisions[0] = collision;

            Trigger = true;
            HideInGame = true;
            Console.WriteLine("trigger");
            SetTexture("playerIdle");
            text = new EntityParam();
            SizeX = new EntityParam();
            SizeY = new EntityParam();
            entityParams = new EntityParam[3];
            entityParams[0] = text;
            entityParams[1] = SizeX;
            entityParams[2] = SizeY;
            text.name = "text";
            text.value = "hello world";
            SizeX.name = "Size X";
            SizeX.value = "100";
            SizeY.name = "Size Y";
            SizeY.value = "100";
            type = "TriggerTest";

            stringCustomSaveData = new string[3];
            stringCustomSaveData[0] = text.value;
            stringCustomSaveData[1] = SizeX.value;
            stringCustomSaveData[2] = SizeY.value;

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
