﻿using System;
using System.Windows.Forms;
using System.Threading;
using Engine.Editor;

namespace Engine
{
    public class Program
    {
        public static bool isEditor = false;
        static void Main(string[] args)
        {
            foreach(string s in args)
            {
                Console.WriteLine(s);
                if (s == "-editor")
                    isEditor = true;
            }
            Game();
        }
        

        static void Game()
        {
            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

            GameMain.Start();


            while (Renderer.window.IsOpen)
            {
                Renderer.window.DispatchEvents();
                Time.FrameStart();
                Input.Update();

                if (isEditor)
                    EditorMain.Update();
                GameMain.Update();
            }
        }
    }
}
