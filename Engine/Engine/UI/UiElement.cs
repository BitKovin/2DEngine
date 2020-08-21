using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace Engine.UI
{
    public class UiElement: Drawable, IComparable
    {

        public enum Origin
        {
            Centre,
            Left,
            Right,
            Top,
            Bottom
        }

        public Int32 layer;
        public Origin originH;
        public Origin originV;

        public Vector2f Center = new Vector2f(0,0);

        public Vector2f Top = new Vector2f(0, -Constants.BaseResolution.Y/2f);
        public Vector2f Bottom = new Vector2f(0, Constants.BaseResolution.Y / 2f);

        public Vector2f Left = new Vector2f(-Constants.BaseResolution.X/2f, 0);
        public Vector2f Right = new Vector2f(Constants.BaseResolution.X / 2f, 0);

        public virtual void Update()
        {

            Left = new Vector2f(-Renderer.view.Size.X/2, 0);
            Right = new Vector2f(Renderer.view.Size.X/2, 0);

        }

        public virtual void draw(RenderTarget target, RenderStates states)
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            draw(target,states);
        }

        public int CompareTo(object obj)
        {
            UiElement element = obj as UiElement;
            return layer.CompareTo(element.layer);
        }
    }
}
