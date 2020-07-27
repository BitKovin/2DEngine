using System;
using System.Windows.Forms;
using System.Threading;
using Engine.Editor;

namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread editor = new Thread(new ThreadStart(Editor));
            editor.Start();
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
            GameMain.Start();
            EditorMain.Start();
            while (Renderer.window.IsOpen)
            {
                GameMain.Update();
                EditorMain.Update();
            }
            Application.Exit();
        }
    }
}
