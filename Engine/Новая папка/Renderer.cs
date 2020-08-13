using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Engine
{

    class Renderer
    {
        public static RenderWindow window;

        public static void Init()
        {
            window = new RenderWindow(new VideoMode(1280,720), Constants.GameName);

        }

        public static void Render()
        {

            window.Display();

        }

    }
}
