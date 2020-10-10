using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Engine.Physics;
using SFML.System;

namespace Game.Entities
{
    class Test: Entity
    {
        Collision collision;
        public Test()
        {
            SetTexture("b_test");

            collisions = new Collision[1];

            type = "Test";

            entityParams = new EntityParam[1];
            entityParams[0] = new EntityParam();
            entityParams[0].name = "Name";
            collision = new Collision();
            collision.size = new Vector2f(50, 50);
            collision.position = position;
            collision.owner = this;
            collisions[0] = collision;

        }
        public override void Start()
        {
            base.Start();
            physicBody = Physics.CreateBox(position.X, position.Y, 50, 50, this);
            //physicBody.FreezeRotation();
            
        }

        public override void Update()
        {
            base.Update();

        }

        public override void UpdateCollision()
        {
            collision.position = position;
        }
    }
}
