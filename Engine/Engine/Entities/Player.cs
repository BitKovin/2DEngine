using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Numerics;

namespace Engine.Entities
{
    class Player: Entity
    {
        public float speed = 500f;
        public float stepHeight = 5f;
        float gravity;
        Collision collision;
        bool OnGround;
        public override void Start()
        {
            base.Start();
            SetTexture(TexturesData.GetTexture("playerIdle"));
            Camera.target = this;
            collision = new Collision();
            collision.size = new Vector2i(20,40);
        }
        public override void Update()
        {
            base.Update();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && OnGround)
                gravity = 300;

            gravity -= Time.DeltaTime * 1100f;

            Vector2f movement = new Vector2f(Input.Right, 0);

            Vector2f move = (new Vector2f(movement.X, 0) * speed) * Time.DeltaTime;
            position += move;
            UpdateCollision();
            Collide(move);

            OnGround = false;
            move = (new Vector2f(0, gravity) + new Vector2f(0, movement.Y) * speed) * Time.DeltaTime;
            position += move;
            UpdateCollision();
            Collide(move);

        }

        void Collide(Vector2f move)
        {

            foreach (Collision col in Level.collisions)
            {
                if (Collision.MakeCollionTest(collision, col))
                {

                    if(move.Y<0)
                    {
                        gravity = 0;
                        OnGround = true;
                        UpdateCollision();
                    }
                    if (move.Y > 0)
                    {
                        gravity = 0;
                        OnGround = false;
                        UpdateCollision();
                    }

                    position -= move;
                }
            }

        }

        void UpdateCollision()
        {
            collision.position = new Vector2i((int)position.X, (int)position.Y);
        }

    }
}
