using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Engine.UI
{
    class UiPanel: UiElement
    {
        public RectangleShape r_rectangle;
        public Vector2f position;
        public Vector2f size;
        public bool hovered;
        public Collision collision;
        public Color color = new Color(0,0,0,100);

        public UiPanel()
        {
            r_rectangle = new RectangleShape();
            r_rectangle.FillColor = new Color(100, 100, 100);

            collision = new Collision();
        }


        public override void Update()
        {
            base.Update();

            collision.position = position * 0.5f + new Vector2f(Camera.position.X, -Camera.position.Y) + originH - originV;
            collision.size = size;

            Collision MouseCol = new Collision();

            MouseCol.position = Input.MousePos;
            MouseCol.size = new Vector2f(2, 2);

            hovered = Collision.MakeCollionTest(collision, MouseCol);

            if (hovered)
                UiManager.UiHover = true;
        }

        public override void draw(RenderTarget target, RenderStates states)
        {
            r_rectangle.FillColor = color;
            r_rectangle.Position = position * 0.5f + Renderer.view.Center - size / 2f + originH + originV;
            r_rectangle.Size = size;    
            r_rectangle.OutlineThickness = 1;
            r_rectangle.OutlineColor = Color.Black;
            
            target.Draw(r_rectangle);
        }
    }
}
