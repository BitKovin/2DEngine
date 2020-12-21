using System;
using System.Reflection;
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
            Game.Game.Init();

            Physics.Physics.Init();

            if (Program.isEditor)
            {
                Editor.EditorMain.WindowInit();
                Editor.EditorMain.Start();
            }
            else
            {
                Renderer.Init();
            }
            



            Game.EntitiesList.Load();

            Renderer.window.SetFramerateLimit(150);
            Renderer.window.SetVerticalSyncEnabled(true);
            Time.Init();

            Level lvl = new Level();
            curentLevel = lvl;

            Renderer.window.Closed += Window_Closed;

            TexturesData.LoadTextures();

            Game.Game.Update();

            

        }

        public static void Update()
        {
            DebugDraw.Reset();
            UiManager.UiHover = false;
            foreach (UiElement uiElement in UiManager.objects)
                uiElement.Update();
            UiManager.objects.Sort();

            Physics.Physics.Update();

            if (Program.isEditor)
                Editor.EditorMain.Update();

            if (!Editor.EditorMain.GamePaused)
            {
                curentLevel.Update();
            }else
            {
                foreach (Entity ent in Editor.EditorMain.baselevel.entities)
                    ent.EditorUpdate();
            }
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
