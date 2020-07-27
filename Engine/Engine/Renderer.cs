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

        public static void Init()
        {
            window = new RenderWindow(new VideoMode(1600,900), Constants.GameName);
            view = new View(new FloatRect(0, 0, 1280, 720));
        }

        public static void Render()
        {
            window.Clear(Color.Blue);
            view.Center = Functions.Vector2ToVector2f(Camera.position);
            window.SetView(view);

            foreach (Brush brush in GameMain.curentLevel.brushes)
            {
                window.Draw(brush);
            }

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
