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
        public static Brush selectedBrush;
        public static EditorWindow form;
        public static Level baselevel;
        public static bool GamePaused;
        public static string FileName = "test";
        public static Brush brushDraw;
        public static Vector2f ToolPos;
        public static Vector2f BrushStart;
        public static Vector2f BrushEnd;
        static Vector2f MousePosOld;
        public static Vector2f cameraPos;
        static bool drawing;

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

            ToolPos = Functions.SnapToGrid(Input.MousePos,5f);

            if(curentEntity!=null)
            {
                curentEntity.position = Input.MousePos;
            }

            if(Keyboard.IsKeyPressed(Keyboard.Key.Delete))
            {
                baselevel.brushes.Remove(selectedBrush);
                selectedBrush = null;

                baselevel.entities.Remove(selectedEntity);
                selectedEntity = null;
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

            if(Mouse.IsButtonPressed(Mouse.Button.Left)&&tool==Tool.brush&&drawing)
            {
                BrushEnd = ToolPos;
                BuildDrawBrush();
            }else
            {
                brushDraw = null;
            }

            if(Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                Vector2f move = Input.MousePosWindow - MousePosOld;
                cameraPos += new Vector2f(-move.X,move.Y);
            }
            MousePosOld = Input.MousePosWindow;
            if(GamePaused)
            Camera.position = cameraPos;
        }

        private static void Window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            drawing = false;
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

                        if (selectedBrush != null) return;
                        BrushEnd = ToolPos;
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

            if (selectedEntity != null)
                selectedEntity.UpdateCollision();
            selectedEntity = null;
            #endregion

            if (e.Button == Mouse.Button.Left)
            {
                Collision mouseCol = new Collision();
                mouseCol.position = Input.MousePos;
                mouseCol.size = new Vector2f(1, 1);
                Console.WriteLine(mouseCol.position);

                switch (tool)
                {
                    case Tool.enity:

                        foreach (Entity entity in baselevel.entities)
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
                        selectedEntity = null;
                        if (entityType == null) return;
                        if (selectedEntity != null) return;
                        curentEntity = Functions.EntityFromString(entityType);
                        curentEntity.position = Input.MousePos;
                        baselevel.entities.Add(curentEntity);
                        break;
                    case Tool.brush:

                        foreach (Brush brush in baselevel.brushes)
                        {
                            if(Collision.MakeCollionTest(mouseCol, brush.collision))
                            {
                                selectedBrush = brush;
                                Console.WriteLine("sellected");
                                return;
                            }
                        }
                        selectedBrush = null;
                        BrushStart = ToolPos;
                        drawing = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void BuildBrush()
        {

            float SizeX = BrushEnd.X - BrushStart.X;
            if(SizeX<0)
                SizeX = SizeX * -1;
            float SizeY = BrushEnd.Y- BrushStart.Y;
            if (SizeY > 0)
                SizeY *= -1;
            if (SizeX == 0 || SizeY == 0) return;
            float posX = (BrushStart.X + BrushEnd.X) / 2f;
            float posY = (BrushStart.Y + BrushEnd.Y) / 2f;

            Vector2f pos = new Vector2f(posX, posY);
            Vector2f size = new Vector2f(SizeX, -SizeY);
            Console.WriteLine(size);
            
            Brush brush = new Brush();
            brush.SetTexture(brushType);
            brush.SetSize(size);
            brush.SetPosition(pos);
            baselevel.brushes.Add(brush);
            Console.WriteLine("brush");
        }

        public static void BuildDrawBrush()
        {
            float SizeX = BrushEnd.X - BrushStart.X;
            if (SizeX < 0)
                SizeX = SizeX * -1;
            float SizeY = BrushEnd.Y - BrushStart.Y;
            if (SizeY > 0)
                SizeY *= -1;
            float posX = (BrushStart.X + BrushEnd.X) / 2f;
            float posY = (BrushStart.Y + BrushEnd.Y) / 2f;

            Vector2f pos = new Vector2f(posX, posY);
            Vector2f size = new Vector2f(SizeX, -SizeY);

            Brush brush = new Brush();
            brush.SetTexture(brushType);
            brush.SetSize(size);
            brush.SetPosition(pos);
            brushDraw = brush;
        }

    }
}
