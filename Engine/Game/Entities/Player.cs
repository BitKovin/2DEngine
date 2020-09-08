﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Engine;
using Engine.Editor;

namespace Game.Entities
{
    public class Player : Entity
    {
        public float speed = 400f;
        public float stepHeight = 5f;
        float gravity;
        Collision collision;
        bool OnGround;
        StateMachine stateMachine;
        Animation idle;
        Animation walk;
        Animation inAir;

        public Player()
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
        }
        public override void Update()
        {
            base.Update();

            gravity -= 1400f * Engine.Time.DeltaTime;
            if (Math.Abs(gravity) < 1)
                gravity *= 3f;

            Vector2f movement = new Vector2f(Input.Right, 0);
            //GameMain.text.text = position.ToString();
            if (Input.Right > 0) flipH = false;
            if (Input.Right < 0) flipH = true;
            Vector2f move = (new Vector2f(movement.X, 0) * speed) * Engine.Time.DeltaTime;
            position += move;
            UpdateCollision();
            Collide(move);

            move = (new Vector2f(0, gravity) + new Vector2f(0, movement.Y) * speed) * Engine.Time.DeltaTime;
            position += move;
            UpdateCollision();
            Collide(move);
            if (movement.X != 0)
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
        }

        void Collide(Vector2f move)
        {

            foreach (Collision col in GameMain.curentLevel.collisions)
            {
                if (Collision.MakeCollionTest(collision, col))
                {

                    if (move.Y < 0)
                    {
                        OnGround = true;
                        gravity = 0;
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
                if (Math.Abs(gravity) > 100)
                    OnGround = false;
            }

        }

        public override void UpdateCollision()
        {
            collision.position = position;
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Space && OnGround)
                gravity = 300;
        }

    }
}