using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Engine
{
    class Brush:Drawable
    {

        public Vector2i position;
        public Vector2i size;
        public Texture texture;
        Collision collision;

        public Brush()
        {
        }

        public void Init()
        {
            collision = new Collision();
            GameMain.curentLevel.collisions.Add(collision);
            collision.size = size;
            collision.position = position;
        }

        public void SetTexture(Texture tex)
        {

            texture = tex;
            texture.Repeated = true;

        }

        public void SetSize(Vector2i Size)
        {
            size = Size;
        }

        public void SetPosition(Vector2i pos)
        {

            position = pos;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {

            Sprite spr = new Sprite(texture);
            spr.TextureRect = new IntRect(new Vector2i(position.X-(size.X/2), -position.Y - (size.Y / 2)), size);
            spr.Position = new Vector2f(position.X,-position.Y);
            spr.Origin = new Vector2f(spr.TextureRect.Width / 2f, spr.TextureRect.Height / 2f);

            target.Draw(spr);

        }
    }
}
