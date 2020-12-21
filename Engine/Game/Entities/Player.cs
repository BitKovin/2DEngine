using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Engine;
using Engine.Editor;
using Engine.Physics;

namespace Game.Entities
{
    public class Player : Entity
    {

        public float speed = 300f;
        public float stepHeight = 5f;
        float gravity;
        Collision collision;
        bool OnGround;
        StateMachine stateMachine;
        Animation idle;
        Animation walk;
        Animation inAir;

        public Player():base()
        {
            SetTexture("playerIdle");
            if (!EditorMain.GamePaused)
                Start();
            type = "Player";
            floatCustomSaveData = new float[2];
            floatCustomSaveData[0] = speed;
            floatCustomSaveData[1] = gravity;

            collisions = new Collision[1];

            collision = new Collision();
            collision.size = new Vector2f(15, 35);
            collision.position = position;
            collision.owner = this;
            collisions[0] = collision;


        }



        public override void Start()
        {
            base.Start();
            Renderer.window.KeyPressed += Window_KeyPressed;
            //Camera.target = this;
            //collision = new Collision();
            //collision.size = new Vector2f(15,35);

            idle = new Animation();
            walk = new Animation();
            inAir = new Animation();
            stateMachine = new StateMachine();

            idle.frames.Add("playerIdle");
            idle.frameTime = 1f;
            walk.frames.Add("playerWalk0");
            walk.frames.Add("playerWalk1");
            walk.frames.Add("playerWalk2");
            walk.frames.Add("playerWalk3");
            walk.frames.Add("playerWalk4");
            walk.frames.Add("playerWalk5");
            walk.frames.Add("playerWalk6");
            walk.frames.Add("playerWalk7");
            walk.frames.Add("playerWalk8");
            walk.frameTime = 0.05f;

            inAir.frames.Add("playerInAir");
            inAir.frameTime = 1f;

            stateMachine.states.Add("idle", idle);
            stateMachine.states.Add("walk", walk);
            stateMachine.states.Add("inAir", inAir);
            stateMachine.SetState("idle");

            physicBody = Physics.CreateBox(position.X, position.Y, 15, 35, this,0);
            physicBody.FreezeRotation();
            Box2DX.Collision.MassData massData = new Box2DX.Collision.MassData();
            massData.I = 0;
            massData.Mass = 1000;
            physicBody.SetMass(massData);

        }
        public override void Update()
        {
            base.Update();

            gravity -= 1400f * Engine.Time.DeltaTime;

            

            Box2DX.Collision.Segment segment = new Box2DX.Collision.Segment();
            segment.P1 = new Box2DX.Common.Vec2(position.X, position.Y);
            segment.P2 = new Box2DX.Common.Vec2(position.X, position.Y-20);

            Box2DX.Collision.Segment segment2 = new Box2DX.Collision.Segment();
            segment2.P1 = new Box2DX.Common.Vec2(position.X, position.Y);
            segment2.P2 = new Box2DX.Common.Vec2(position.X-7f, position.Y - 20);

            Box2DX.Collision.Segment segment3 = new Box2DX.Collision.Segment();
            segment3.P1 = new Box2DX.Common.Vec2(position.X, position.Y);
            segment3.P2 = new Box2DX.Common.Vec2(position.X+7f, position.Y - 20);

            float l;
            Box2DX.Common.Vec2 normal;

            OnGround = Math.Abs(physicBody.GetLinearVelocity().Y) < 100 & (
                Physics.world.RaycastOne(segment, out l, out normal, false, null) != null
                ||Physics.world.RaycastOne(segment, out l, out normal, false, null) != null
                || Physics.world.RaycastOne(segment2, out l, out normal, false, null) != null
                || Physics.world.RaycastOne(segment3, out l, out normal, false, null) != null);



            Box2DX.Collision.Segment left = new Box2DX.Collision.Segment();
            left.P1 = new Box2DX.Common.Vec2(position.X, position.Y);
            left.P2 = new Box2DX.Common.Vec2(position.X - 10f, position.Y - 17);

            Box2DX.Collision.Segment right = new Box2DX.Collision.Segment();
            right.P1 = new Box2DX.Common.Vec2(position.X, position.Y);
            right.P2 = new Box2DX.Common.Vec2(position.X + 10f, position.Y - 17);

            bool Left = Physics.world.RaycastOne(left, out l, out normal, false, null)==null;
            bool Right = Physics.world.RaycastOne(right, out l, out normal, false, null) == null;

            Vector2f movement = new Vector2f(Input.Right, 0);
            //GameMain.text.text = position.ToString();
            if (Input.Right > 0) flipH = false;
            if (Input.Right < 0) flipH = true;
            Vector2f move = new Vector2f(movement.X, 0) * speed;

            if ((move.X < 0 & !Left) || (move.X>0&!Right))
                move = new Vector2f();


            physicBody.SetLinearVelocity(new Box2DX.Common.Vec2(move.X,physicBody.GetLinearVelocity().Y));

            if (move.X != 0)
            {
                stateMachine.SetState("walk");
            }
            else
            {
                stateMachine.SetState("idle");
            }
            
            if (!OnGround)
                stateMachine.SetState("inAir");
                
            stateMachine.Update();
            SetTexture(stateMachine.OutFrame);
            Camera.position = position;

            UpdateCollision();

            DebugDraw.AddRectangle(position, new Vector2f(15, 35), Color.Green);

        }

        public override void EditorUpdate()
        {
            base.EditorUpdate();
            DebugDraw.AddRectangle(position, new Vector2f(15, 35), Color.Green);
        }

        public override void UpdateCollision()
        {
            collision.position = position;
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Space&&OnGround)
                physicBody.ApplyImpulse(new Box2DX.Common.Vec2(0,160000),physicBody.GetWorldCenter());
        }

    }
}