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
    enum Tool
    {
        enity,
        brush
    };
    class EditorMain
    {
        public static Tool tool;
        static Vector2i startPoint;
        static Vector2i endPoint;
        public static string brushType;
        public static string entityType;
        public static Entity curentEntity;
        public static EditorWindow form;
        static Level baselevel;
        public static bool GamePaused;

        public static Vector2f BrushStart;
        public static Vector2f BrushEnd;

        public static void Start()
        {
            Renderer.window.MouseButtonPressed += Window_MouseButtonPressed;
            Renderer.window.MouseButtonReleased += Window_MouseButtonReleased;
            GamePaused = true;
            baselevel = new Level();
            GameMain.curentLevel = baselevel;
        }

        public static void StartLevel()
        {
            GameMain.curentLevel = baselevel.Clone();
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
            if (e.Button == Mouse.Button.Left)
            {
                switch (tool)
                {
                    case Tool.enity:
                        if (curentEntity == null) return;
                        baselevel.entities.Add((Entity)curentEntity.Clone());
                        curentEntity = null;
                        break;
                    case Tool.brush:
                        BrushEnd = Input.MousePos;
                        BuildBrush();
                        break;
                    default:
                        break;
                }

            }
        }

        private static void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            
            if (e.Button == Mouse.Button.Left)
            {
                switch (tool)
                {
                    case Tool.enity:
                        if (entityType == null) return;
                        curentEntity = Functions.EntityFromString(entityType);
                        curentEntity.position = Input.MousePos;
                        GameMain.curentLevel.entities.Add(curentEntity);
                        break;
                    case Tool.brush:
                        BrushStart = Input.MousePos;
                        break;
                    default:
                        break;
                }

            }
        }

        public static void BuildBrush()
        {
            
            Console.WriteLine("brush");
            float SizeX = BrushEnd.X - BrushStart.X;
            if(SizeX<0)
                SizeX = SizeX * -1;
            float SizeY = BrushEnd.Y- BrushStart.Y;
            float posX = (BrushStart.X + BrushEnd.X) / 2f;
            float posY = (BrushStart.Y + BrushEnd.Y) / 2f;

            Vector2i pos = new Vector2i((int)posX, (int)posY);
            Vector2i size = new Vector2i((int)SizeX, -(int)SizeY);
            Console.WriteLine(size);
            
            Brush brush = new Brush();
            brush.SetTexture(new Texture("brush.png"));
            brush.SetSize(size);
            brush.SetPosition(pos);
            baselevel.brushes.Add(brush);

        }

    }
}
