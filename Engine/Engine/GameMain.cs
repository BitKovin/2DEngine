using System;
using System.Collections.Generic;
using System.Text;
using Engine.UI;
using SFML.System;
using SFML.Graphics;


using System.IO;

namespace Engine
{
    class GameMain
    {
        public static UiText text;
        public static void Start()
        {

            Renderer.Init();
            Renderer.window.SetFramerateLimit(500);
            Renderer.window.SetVerticalSyncEnabled(true);
            Time.Init();

            Renderer.window.Closed += Window_Closed;

            TexturesData.LoadTextures();

            /////////////////////////////////////////////////



            ////////////////////////////////////////////////

            Level.Start();
            foreach (Entity ent in Level.entities)
            {
                ent.Start();
            }

            Renderer.view.Zoom(0.5f);

            text = new UiText();
            text.position = new Vector2f(-1280 / 2, -720 / 2);
            text.r_text.Color = Color.Blue;
            UI.UiManager.objects.Add(text);
        }



        public static void Update()
        {
            Renderer.window.DispatchEvents();
            Time.FrameStart();
            text.text = "FPS: " + (1f/Time.DeltaTime).ToString();
            Input.Update();
            foreach (Entity ent in Level.entities)
            {
                ent.Update();
            }
            Camera.Update();

            Renderer.Render();

        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Renderer.window.Close();
        }
    }
}
