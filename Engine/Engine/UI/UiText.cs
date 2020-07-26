using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Engine.UI
{
    class UiText: Drawable
    {
        public Text r_text;
        public Vector2f position;
        public string text;

        public UiText()
        {
            r_text = new Text("1000",new Font("OpenSans-Regular.ttf"));
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            r_text.DisplayedString = text;
            r_text.Position = position + Renderer.view.Center;
            target.Draw(r_text);
        }
    }
}
