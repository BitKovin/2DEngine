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
        public static string brushType = "b_test";
        public static string entityType = "Player";
        public static Entity curentEntity;
        public static Entity selectedEntity;
        public static EditorWindow form;
        public static Level baselevel;
        public static bool GamePaused;
        public static string FileName = "test";

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
            }

            if(selectedEntity!=null)
            {
                if(Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    Collision mouseCol = new Collision();
                    mouseCol.position = Input.MousePos;
                    mouseCol.size = new Vector2f(5, 5);
                    if (Collision.MakeCollionTest(mouseCol, selectedEntity.collisions[0]))
                    {
                        selectedEntity.position = Input.MousePos;
                        selectedEntity.UpdateCollision();
                    }
                }

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
                        Console.WriteLine(curentEntity.position);
                        curentEntity.UpdateCollision();
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

            #region select
            Collision mouseCol = new Collision();
            mouseCol.position = Input.MousePos;
            mouseCol.size = new Vector2f(5, 5);
            Console.WriteLine(mouseCol.position);
            foreach (Entity entity in GameMain.curentLevel.entities)
                foreach (Collision col in entity.collisions)
                {
                    Console.WriteLine(col.position);
                    if (Collision.MakeCollionTest(mouseCol, col))
                    {
                        selectedEntity = col.owner;
                        Console.WriteLine("sellected");
                        return;
                    }
                }
            if (selectedEntity != null)
                selectedEntity.UpdateCollision();
            selectedEntity = null;
            #endregion

            if (e.Button == Mouse.Button.Left)
            {
                switch (tool)
                {
                    case Tool.enity:
                        if (entityType == null) return;
                        if (selectedEntity != null) return;
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
            brush.SetTexture(brushType);
            brush.SetSize(size);
            brush.SetPosition(pos);
            baselevel.brushes.Add(brush);

        }

    }
}
