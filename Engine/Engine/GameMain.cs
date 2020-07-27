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
        public static Level curentLevel;
        public static void Start()
        {

            Renderer.Init();
            Renderer.window.SetFramerateLimit(500);
            Renderer.window.SetVerticalSyncEnabled(true);
            Time.Init();

            Level lvl = new Level();
            //Functions.MakeBase(lvl);
            curentLevel = lvl;

            Renderer.window.Closed += Window_Closed;

            TexturesData.LoadTextures();

            foreach (Entity ent in curentLevel.entities)
            {
                ent.Start();
            }

            Renderer.view.Zoom(0.5f);

            text = new UiText();
            text.position = new Vector2f(-1280 / 2, -720 / 2);
            text.r_text.Color = Color.Blue;
            UI.UiManager.objects.Add(text);
            curentLevel.Start();
        }



        public static void Update()
        {
            Renderer.window.DispatchEvents();
            Time.FrameStart();
            text.text = "FPS: " + (1f/Time.DeltaTime).ToString();
            Input.Update();
            if (!Editor.EditorMain.GamePaused)
                curentLevel.Update();
            Camera.Update();

            Renderer.Render();

        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Renderer.window.Close();
        }
    }
}
