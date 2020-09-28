using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Engine
{
    public class Brush:Drawable
    {

        public Vector2f position;
        public Vector2f size;
        public string textureName;
        public Texture texture;
        public Collision collision;

        public Brush()
        {
            collision = new Collision();
            collision.size = new Vector2f(size.X, size.Y);
            collision.position = new Vector2f(position.X, position.Y);
        }

        public void Init()
        {
            collision = new Collision();
            collision.size = new Vector2f(size.X, size.Y);
            collision.position = new Vector2f(position.X, position.Y);
            GameMain.curentLevel.collisions.Add(collision);

            Physics.Physics.CreateStaticBox(position.X, position.Y, size.X, size.Y);

        }

        public void SetTexture(string Texture)
        {

            texture = TexturesData.GetTexture(Texture);
            texture.Repeated = true;
            textureName = Texture;

        }

        public void SetSize(Vector2f Size)
        {
            size = Size;
            collision.size = new Vector2f(size.X, size.Y);
        }

        public void SetPosition(Vector2f pos)
        {

            position = pos;
            collision.position = new Vector2f(position.X, position.Y);

        }

        public void Draw(RenderTarget target, RenderStates states)
        {

            Sprite spr = new Sprite(texture);
            spr.TextureRect = new IntRect(new Vector2i((int)(position.X-(size.X/2)), (int)(-position.Y - (size.Y / 2))), new Vector2i((int)size.X,(int)size.Y));
            spr.Position = new Vector2f(position.X,-position.Y);
            spr.Origin = new Vector2f(spr.TextureRect.Width / 2f, spr.TextureRect.Height / 2f);

            target.Draw(spr);

        }
    }
}
