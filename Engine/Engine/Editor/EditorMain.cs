using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
namespace Engine.Editor
{
    class EditorMain
    {

        static Vector2i startPoint;
        static Vector2i endPoint;
        public static string brush;
        public static string entity;
        public static Entity curentEntity;
        public static EditorWindow form;
        static Level baselevel;
        public static bool GamePaused;

        public static void Start()
        {
            Renderer.window.MouseButtonPressed += Window_MouseButtonPressed;
            Renderer.window.MouseButtonReleased += Window_MouseButtonReleased;
            GamePaused = true;
            baselevel = new Level();
        }

        public static void StartLevel()
        {
            GameMain.curentLevel = (Level)baselevel.Clone();
            GameMain.curentLevel.Start();
            GamePaused = false;
        }

        public static void Update()
        {
            Vector2i winPos = Renderer.window.Position;
            Action action = () => { form.SetPos(winPos.X, winPos.Y); };
            form.Invoke(action);

            if(curentEntity!=null)
            {
                curentEntity.position = Input.MousePos;
                Console.WriteLine(Input.MousePos);
            }

        }

        private static void Window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (curentEntity == null) return;
            baselevel.entities.Add((Entity)curentEntity.Clone());
            curentEntity = null;
        }

        private static void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (entity == null) return;
            curentEntity = Functions.EntityFromString(entity);
            GameMain.curentLevel.entities.Add(curentEntity);
        }

        public static void Test()
        {
            Brush brush = new Brush(GameMain.curentLevel);
            brush.SetTexture(new Texture("brush.png"));
            brush.SetSize(new Vector2i(100, 1000));
            brush.SetPosition(new Vector2i(200, -500));
            GameMain.curentLevel.brushes.Add(brush);
        }

    }
}
