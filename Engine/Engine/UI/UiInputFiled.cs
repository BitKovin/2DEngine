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
    class UiInputField : UiElement
    {
        public Text r_text;
        public RectangleShape r_rectangle;
        public Font font = new Font("OpenSans-Regular.ttf");
        public Vector2f position;
        public Vector2f size;
        public string text;
        public bool hovered;
        public bool entering;
        public Collision collision;

        public delegate void onClick();

        public event onClick OnClick;


        public UiInputField()
        {
            r_text = new Text("1000", font);
            r_text.Color = Color.Black;
            r_rectangle = new RectangleShape();
            r_rectangle.FillColor = new Color(100, 100, 100);

            collision = new Collision();

            Renderer.window.MouseButtonPressed += Window_MouseButtonPressed;
            Renderer.window.TextEntered += Window_TextEntered;
            Renderer.window.KeyPressed += Window_KeyPressed;

            r_text.Scale = new Vector2f(0.5f, 0.5f);
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
                entering = false;
        }

        private void Window_TextEntered(object sender, TextEventArgs e)
        {
            if (!entering) return;
            if(e.Unicode.GetHashCode()== -842352728)
            {
                if (text.Length < 1) return;
                text = text.Remove(text.Length-1);
                return;
            }
            text += e.Unicode;
        }

        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
                if(hovered)
                {
                    entering = true;
                    try
                    {
                        OnClick();
                    }
                    catch (SystemException ex)
                    { }
                }else
                {
                    entering = false;
                }
        }


        public override void Update()
        {
            base.Update();

            Vector2f origin = new Vector2f();

            switch (originH)
            {
                case Origin.Left:
                    origin += Left;
                    break;
                case Origin.Right:
                    origin += Right;
                    break;
                case Origin.Top:
                    origin += Top;
                    break;
                case Origin.Bottom:
                    origin += Bottom;
                    break;
                case Origin.Centre:
                    origin += Center;
                    break;
                default:
                    break;
            }

            switch (originV)
            {
                case Origin.Left:
                    origin += Left;
                    break;
                case Origin.Right:
                    origin += Right;
                    break;
                case Origin.Top:
                    origin += Top;
                    break;
                case Origin.Bottom:
                    origin += Bottom;
                    break;
                case Origin.Centre:
                    origin += Center;
                    break;
                default:
                    break;
            }

            collision.position = new Vector2f(position.X, -position.Y) + new Vector2f(Camera.position.X, -Camera.position.Y) + new Vector2f(origin.X, -origin.Y);
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

            Vector2f origin = new Vector2f();

            switch (originH)
            {
                case Origin.Left:
                    origin += Left;
                    break;
                case Origin.Right:
                    origin += Right;
                    break;
                case Origin.Top:
                    origin += Top;
                    break;
                case Origin.Bottom:
                    origin += Bottom;
                    break;
                case Origin.Centre:
                    origin += Center;
                    break;
                default:
                    break;
            }

            switch (originV)
            {
                case Origin.Left:
                    origin += Left;
                    break;
                case Origin.Right:
                    origin += Right;
                    break;
                case Origin.Top:
                    origin += Top;
                    break;
                case Origin.Bottom:
                    origin += Bottom;
                    break;
                case Origin.Centre:
                    origin += Center;
                    break;
                default:
                    break;
            }

            r_rectangle.Position = position + Renderer.view.Center - size / 2f + origin;
            r_rectangle.Size = size;
            r_rectangle.OutlineThickness = 1;
            r_rectangle.OutlineColor = Color.Black;
            //Console.WriteLine(r_rectangle.Position);

            if (hovered)
            {
                r_rectangle.FillColor = new Color(150, 150, 150);
            }
            else
            {
                r_rectangle.FillColor = new Color(100, 100, 100);
            }

            if (entering)
            {
                r_rectangle.FillColor = new Color(200, 200, 200);
            }

            r_text.DisplayedString = text;
            r_text.Position = position + Renderer.view.Center + origin - new Vector2f(size.X/2,0);

            FloatRect textRect = r_text.GetLocalBounds();
            r_text.Origin = new Vector2f(0, textRect.Top + textRect.Height / 2.0f);
            target.Draw(r_rectangle);
            target.Draw(r_text);
        }

        public void SetFontSize(uint val)
        {
            r_text.CharacterSize = val * 2;
        }

    }
}
