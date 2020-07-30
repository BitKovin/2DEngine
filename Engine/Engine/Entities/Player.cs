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
        bool OldOnGround;

        public Player()
        {
            SetTexture(TexturesData.GetTexture("playerIdle"));
            if (!Editor.EditorMain.GamePaused)
                Start();

        }
        public override void Start()
        {
            base.Start();

            Camera.target = this;
            collision = new Collision();
            collision.size = new Vector2f(20,35);
        }
        public override void Update()
        {
            base.Update();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && OnGround)
                gravity = 300;

            gravity -= Time.DeltaTime * 1500f;
            if (Math.Abs(gravity) < 1)
                gravity *= 3f;

            Vector2f movement = new Vector2f(Input.Right, 0);
            GameMain.text.text = position.ToString();
            Vector2f move = (new Vector2f(movement.X, 0) * speed) * Time.DeltaTime;
            position += move;
            UpdateCollision();
            Collide(move);

            OnGround = false;
            move = (new Vector2f(0, gravity) + new Vector2f(0, movement.Y) * speed) * Time.DeltaTime;
            position += move;
            UpdateCollision();
            Collide(move);
            if(gravity<2f)
            OldOnGround = OnGround;
        }

        void Collide(Vector2f move)
        {

            foreach (Collision col in GameMain.curentLevel.collisions)
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
                    return;
                }
            }

        }

        void UpdateCollision()
        {
            collision.position = position;
        }

        public override Entity GetCopy()
        {
            return (Player)this.MemberwiseClone();
        }

    }
}
