using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using SFML.System;
using Engine.Physics;

namespace Game.Entities
{
    public class Bullet : Entity
    {
        public Vector2f velocity;
        public Bullet(Vector2f pos, Vector2f vel):base()
        {
            position = pos;
            velocity = vel;
            type = "bullet";
            SetTexture("bullet");
        }

        public override void Start()
        {
            base.Start();

            physicBody = Physics.CreateBox(position.X, position.Y, 3, 3, this);
            physicBody.SetBullet(true);
            //Physics.world.DestroyBody(physicBody);
        }

        public override void Update()
        {
            base.Update();

            //Destroy();

            try
            {
                physicBody.SetLinearVelocity(new Box2DX.Common.Vec2(velocity.X, velocity.Y));
            }
            catch (SystemException) { };
            
        }

        public override void OnHit(Entity ent)
        {
            if (ent == Owner) return;
            Destroy();
            if (ent == null) return;

            ent.physicBody.ApplyImpulse(new Box2DX.Common.Vec2(velocity.X, velocity.Y) * 10000, new Box2DX.Common.Vec2(position.X, position.Y));
            ent.Destroy();
        }

    }
}
