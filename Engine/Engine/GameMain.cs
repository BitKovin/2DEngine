using System;
using System.Collections.Generic;
using System.Text;
using Engine.UI;
using SFML.System;
using SFML.Graphics;
using System.IO;

namespace Engine
{
    public class GameMain
    {

        public static Level curentLevel;
        public static void Start()
        {

            Renderer.Init();
            Game.Game.Init();

            if (Program.isEditor)
                Editor.EditorMain.Start();

            Game.EntitiesList.Load();

            Renderer.window.SetFramerateLimit(150);
            Renderer.window.SetVerticalSyncEnabled(true);
            Time.Init();

            Level lvl = new Level();
            curentLevel = lvl;

            Renderer.window.Closed += Window_Closed;

            TexturesData.LoadTextures();

            Game.Game.Update();

            Physics.Physics.Init();

        }

        public static void Update()
        {

            UiManager.UiHover = false;
            foreach (UiElement uiElement in UiManager.objects)
                uiElement.Update();
            UiManager.objects.Sort();

            Physics.Physics.Update();

            if (!Editor.EditorMain.GamePaused)
                curentLevel.Update();
            Game.Game.Update();
            Camera.Update();


            Renderer.Render();

        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Renderer.window.Close();
        }
    }
}
