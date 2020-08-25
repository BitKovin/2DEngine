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
    public class UiButton : UiElement
    {
        public Text r_text;
        public RectangleShape r_rectangle;
        public Font font = new Font("OpenSans-Regular.ttf");
        public Vector2f position;
        public Vector2f size;
        public string text;
        public bool hovered;
        public bool clicking;
        public Collision collision;

        public bool active = true;

        public delegate void onClick();

        public event onClick OnClick;


        public UiButton()
        {
            r_text = new Text("1000", font);
            r_text.Color = Color.Black;
            r_rectangle = new RectangleShape();
            r_rectangle.FillColor = new Color(100,100,100);

            collision = new Collision();

            Renderer.window.MouseButtonPressed += Window_MouseButtonPressed;

            r_text.Scale = new Vector2f(0.5f, 0.5f);
        }

        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left & hovered)
                try
                {
                    OnClick();
                } catch (SystemException ex)
                { }
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

            collision.position = new Vector2f(position.X,-position.Y) + Camera.position + new Vector2f(origin.X,-origin.Y);
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
            if(!active)
            {
                hovered = false;
                clicking = false;
            }
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

            r_rectangle.Position = position + Renderer.view.Center - size/2f + origin;
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

            if(clicking)
            {
                r_rectangle.FillColor = new Color(200, 200, 200);
            }

            r_text.Color = Color.Black;
            r_text.DisplayedString = text;
            r_text.Position = position + Renderer.view.Center + origin;

            FloatRect textRect = r_text.GetLocalBounds();
            r_text.Origin = new Vector2f(textRect.Left + textRect.Width / 2.0f, textRect.Top + textRect.Height / 2.0f);

            if (!active)
            {
                r_text.Color = new Color(10, 10, 10);
                r_rectangle.FillColor = new Color(70, 70, 70);
                r_rectangle.OutlineColor = new Color(10,10,10);
            }

            target.Draw(r_rectangle);
            target.Draw(r_text);
        }

        public void SetFontSize(uint val)
        {
            r_text.CharacterSize = val * 2;
        }

    }
}
