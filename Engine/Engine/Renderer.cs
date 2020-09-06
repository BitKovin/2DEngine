using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using Engine.UI;
using SFML.System;

namespace Engine
{

    public class Renderer
    {
        public static RenderWindow window;
        public static View view;
        static float oldZoom = 1;
        static Texture tooltex = new Texture("Assets//Editor//tool.png");
        static Sprite toolSpr = new Sprite(tooltex);
        static Texture t_grid = new Texture("Assets//Editor//grid.png");
        static Sprite s_grid = new Sprite(t_grid);
        public static float hToV;

        public static void Init()
        {
            window = new RenderWindow(new VideoMode(1600,900), Constants.GameName);
            hToV = (float)window.Size.X / (float)window.Size.Y;
            view = new View(new FloatRect(0, 0, Constants.BaseResolution.Y * Camera.zoom * hToV, Constants.BaseResolution.Y * Camera.zoom));
            toolSpr.Origin = new Vector2f(32,34);
            t_grid.Repeated = true;

            window.Resized += Window_Resized;

        }

        private static void Window_Resized(object sender, SizeEventArgs e)
        {
            hToV = (float)window.Size.X / (float)window.Size.Y;
            view.Size = new Vector2f(Constants.BaseResolution.Y * hToV * Camera.zoom, Constants.BaseResolution.Y * Camera.zoom);
            view.Center = Camera.position;
        }

        public static void Render()
        {
            view = new View(new FloatRect(0, 0, Constants.BaseResolution.Y*Camera.zoom * hToV, Constants.BaseResolution.Y * Camera.zoom));
            window.Clear(Color.Blue);

            view.Center = new Vector2f(Camera.position.X,-Camera.position.Y);
            view.Zoom(1f / oldZoom);
            view.Zoom(Camera.zoom);
            oldZoom = Camera.zoom;
            window.SetView(view);

            if (Editor.EditorMain.GamePaused)
            {
                s_grid.Position = Camera.position - new Vector2f(800, 800);
                s_grid.TextureRect = new IntRect((int)Camera.position.X, (int)Camera.position.Y, 2000, 2000);
                window.Draw(s_grid);

                Vector2f pos = new Vector2f(Editor.EditorMain.ToolPos.X, -Editor.EditorMain.ToolPos.Y);
                toolSpr.Position = pos;

                window.Draw(toolSpr);
            }
            foreach (Brush brush in GameMain.curentLevel.brushes)
            {
                window.Draw(brush);
            }
            if (Editor.EditorMain.brushDraw != null)
                window.Draw(Editor.EditorMain.brushDraw);

            foreach (Entity ent in GameMain.curentLevel.entities)
            {
                //if(!ent.HideInGame&!Editor.EditorMain.GamePaused)
                window.Draw(ent);
                foreach (Entity ent2 in ent.child)
                {
                    //if (!ent.HideInGame & !Editor.EditorMain.GamePaused)
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
