using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace Engine
{
    class Entity: Drawable,ICloneable
    {

        public Texture texture;
        public Vector2f position;
        public float rotation;

        public List<Entity> child = new List<Entity>();
        public Entity parrent;
        Sprite sprite;
        bool flipH;
        bool flipV;
        Level lvl;

        public Entity()
        {
        }

        public virtual void Start()
        {
         
            foreach (Entity ent in child)
                ent.Start();

        }

        public virtual void Update()
        {

            foreach (Entity ent in child)
                ent.Update();

        }

        public virtual void SetTexture(Texture tex)
        {
            if (sprite == null) {
                sprite = new Sprite(tex);
                return;
            }
            texture = tex;
            sprite.Texture = tex;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            sprite.Position = new Vector2f(position.X, position.Y * -1);
            sprite.Rotation = rotation;
            sprite.Origin = new Vector2f(sprite.TextureRect.Width/2f, sprite.TextureRect.Height/2f);
            target.Draw(sprite);
        }

        public void AddChild(Entity ent)
        {
            ent.parrent = this;
            child.Add(ent);

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
