using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Engine.UI
{
    class UiButton : UiElement
    {
        public Text r_text;
        public RectangleShape r_rectangle;
        public Vector2f position;
        public Vector2f size;
        public string text;
        public bool hovered;
        public bool clicking;
        public Collision collision;

        public delegate void onClick();

        public event onClick OnClick;


        public UiButton()
        {
            r_text = new Text("1000", new Font("OpenSans-Regular.ttf"));
            r_text.Color = Color.Black;
            r_rectangle = new RectangleShape();
            r_rectangle.FillColor = new Color(100,100,100);

            collision = new Collision();

            Renderer.window.MouseButtonPressed += Window_MouseButtonPressed;

        }

        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left&hovered)
                OnClick();
        }

        public override void Update()
        {
            base.Update();

            collision.position = position * 0.5f + new Vector2f(Camera.position.X,-Camera.position.Y);
            collision.size = size;

            Collision MouseCol = new Collision();

            MouseCol.position = Input.MousePos;
            MouseCol.size = new Vector2f(2, 2);

            hovered = Collision.MakeCollionTest(collision, MouseCol);
            clicking = false;
            if (hovered)
            {
                UiManager.UiHover = true;
                clicking = Mouse.IsButtonPressed(Mouse.Button.Left);
            }
        }

        public override void draw(RenderTarget target, RenderStates states)
        {
            r_rectangle.Position = position * 0.5f + Renderer.view.Center - size/2f;
            r_rectangle.Size = size;
            r_rectangle.OutlineThickness = 2;
            r_rectangle.OutlineColor = Color.Black;

            if(hovered)
            {
                r_rectangle.FillColor = new Color(150, 150, 150);
            }
            else
            {
                r_rectangle.FillColor = new Color(100, 100, 100);
            }

            if(clicking)
            {
                r_rectangle.FillColor = new Color(200, 200, 200);
            }

            r_text.DisplayedString = text;
            r_text.Position = position * 0.5f + Renderer.view.Center;

            FloatRect textRect = r_text.GetLocalBounds();
            r_text.Origin = new Vector2f(textRect.Left + textRect.Width / 2.0f, textRect.Top + textRect.Height / 2.0f);
            target.Draw(r_rectangle);
            target.Draw(r_text);
        }
    }
}
