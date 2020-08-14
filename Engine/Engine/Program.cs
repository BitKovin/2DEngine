using System;
using System.Windows.Forms;
using System.Threading;
using Engine.Editor;

namespace Engine
{
    class Program
    {
        public static bool isEditor = true;
        static void Main(string[] args)
        {
            foreach(string s in args)
            {
                Console.WriteLine(s);
                if (s == "-editor")
                    isEditor = true;
            }
            if (isEditor)
            {
                Thread editor = new Thread(new ThreadStart(Editor));
                editor.Start();
            }
            Game();
        }

        static void Editor()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditorMain.form = new EditorWindow();
            Application.Run(EditorMain.form);

        }

        static void Game()
        {
            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

            GameMain.Start();
            if (isEditor)
                EditorMain.Start();

            while (Renderer.window.IsOpen)
            {
                GameMain.Update();
                if(isEditor)
                EditorMain.Update();
            }
            if(isEditor)
            Application.Exit();
        }
    }
}
