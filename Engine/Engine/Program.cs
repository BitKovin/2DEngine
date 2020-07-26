using System;

namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {

            GameMain.Start();
            while (Renderer.window.IsOpen)
            {
                GameMain.Update();
            }
            
        }
    }
}
