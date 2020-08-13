using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    class GameMain
    {
        public static void Start()
        {

            Renderer.Init();

            Renderer.window.Closed += Window_Closed;
        }



        public static void Update()
        {
            Renderer.window.DispatchEvents();

            Renderer.Render();

        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            Renderer.window.Close();
        }
    }
}
