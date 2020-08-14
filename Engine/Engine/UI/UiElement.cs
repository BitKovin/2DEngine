using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace Engine.UI
{
    class UiElement: Drawable, IComparable
    {

        public Int32 layer;

        public virtual void Update()
        {

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
