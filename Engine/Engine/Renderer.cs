using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using Engine.UI;
using SFML.System;

namespace Engine
{

    class Renderer
    {
        public static RenderWindow window;
        public static View view;
        static float oldZoom = 1;
        static Texture tooltex = new Texture("Assets//Editor//tool.png");
        static Sprite toolSpr = new Sprite(tooltex);
        public static void Init()
        {
            window = new RenderWindow(new VideoMode(1600,900), Constants.GameName);
            view = new View(new FloatRect(0, 0, Constants.BaseResolution.X * Camera.zoom, Constants.BaseResolution.Y * Camera.zoom));
            toolSpr.Origin = new Vector2f(32,34);
        }

        public static void Render()
        {
            view = new View(new FloatRect(0, 0, Constants.BaseResolution.X*Camera.zoom, Constants.BaseResolution.Y * Camera.zoom));
            window.Clear(Color.Blue);
            view.Center = Camera.position;
            view.Zoom(1f / oldZoom);
            view.Zoom(Camera.zoom);
            oldZoom = Camera.zoom;
            window.SetView(view);

            Vector2f pos = new Vector2f(Editor.EditorMain.ToolPos.X, -Editor.EditorMain.ToolPos.Y);
            toolSpr.Position = pos;

            window.Draw(toolSpr);

            foreach (Brush brush in GameMain.curentLevel.brushes)
            {
                window.Draw(brush);
            }
            if (Editor.EditorMain.brushDraw != null)
                window.Draw(Editor.EditorMain.brushDraw);

            foreach (Entity ent in GameMain.curentLevel.entities)
            {
                window.Draw(ent);
                foreach (Entity ent2 in ent.child)
                {
                    window.Draw(ent2);
                }
            }
            DrawUI();
            window.Display();

        }

        static void DrawUI()
        {
            foreach (Drawable it in UiManager.objects)
            {
                window.Draw(it);
            }
        }

    }
}
