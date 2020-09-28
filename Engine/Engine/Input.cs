using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.System;

namespace Engine
{
    public class Input
    {

        public static float Forward, Right;
        public static Vector2f MousePos;
        public static Vector2f MousePosWindow;
        public static bool cursorInBounds;

        public static void Update()
        {
            cursorInBounds = false;
            #region Right
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                Right -= Time.DeltaTime * 7f;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                Right += Time.DeltaTime * 7f;

            if (!Keyboard.IsKeyPressed(Keyboard.Key.A) && !Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                if (Right > 0)
                    Right -= Time.DeltaTime * 5f;
                if (Right < 0)
                    Right += Time.DeltaTime * 5f;
                if (Right < 0.1f && Right > -0.1f)
                    Right = 0;
            }
            if (Right > 1)
                Right = 1;
            if (Right < -1)
                Right = -1;
            #endregion

            #region Forward
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                Forward -= Time.DeltaTime * 7f;
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                Forward += Time.DeltaTime * 7f;

            if (!Keyboard.IsKeyPressed(Keyboard.Key.S) && !Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                if (Forward > 0)
                    Forward -= Time.DeltaTime * 5f;
                if (Forward < 0)
                    Forward += Time.DeltaTime * 5f;
                if (Forward < 0.1f && Forward > -0.1f)
                    Forward = 0;
            }
            if (Forward > 1)
                Forward = 1;
            if (Forward < -1)
                Forward = -1;
            #endregion

            #region MousePos
            MousePos = new Vector2f((Mouse.GetPosition(Renderer.window).X - (Renderer.window.Size.X / 2)) / ((Renderer.window.Size.X / Renderer.view.Size.X)) + Camera.position.X, ( -Mouse.GetPosition(Renderer.window).Y + (Renderer.window.Size.Y / 2)) / (Renderer.window.Size.Y / Renderer.view.Size.Y) + Camera.position.Y);
            MousePosWindow = new Vector2f(Mouse.GetPosition(Renderer.window).X - (Renderer.window.Size.X / 2) / (Renderer.window.Size.Y / Renderer.view.Size.Y), -Mouse.GetPosition(Renderer.window).Y + (Renderer.window.Size.Y / 2)) / (Renderer.window.Size.Y / Renderer.view.Size.Y);
            #endregion

            if(MousePos.X>Camera.position.X-(float)Constants.BaseResolution.Y*Renderer.hToV)
                if (MousePos.X < Camera.position.X + (float)Constants.BaseResolution.Y * Renderer.hToV)

                    if (MousePos.Y > Camera.position.X - (float)Constants.BaseResolution.Y)
                        if (MousePos.Y < Camera.position.X + (float)Constants.BaseResolution.Y)
                        {
                            cursorInBounds = true;
                        }

        }

    }
}
