using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Engine.UI
{
    public class UiText: UiElement
    {
        public Text r_text;
        public Vector2f position;
        public string text;

        public UiText()
        {
            r_text = new Text("1000", new Font("OpenSans-Regular.ttf"));
            r_text.Scale = new Vector2f(0.5f,0.5f);
        }

        public override void draw(RenderTarget target, RenderStates states, Vector2f pos)
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

            r_text.DisplayedString = text;
            r_text.Position = position + Renderer.view.Center + origin;
            FloatRect textRect = r_text.GetLocalBounds();
            r_text.Origin = new Vector2f(textRect.Left + textRect.Width / 2.0f, textRect.Top + textRect.Height / 2.0f);
            target.Draw(r_text);

            foreach (UiElement element in child)
            {
                element.draw(target, states, position + pos);
            }

        }

        public void SetFontSize(uint val)
        {
            r_text.CharacterSize = val * 2;
        }

    }
}
