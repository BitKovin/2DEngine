using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace Engine
{
    class Entity: Drawable
    {

        public Texture texture;
        public Vector2f position;
        public float rotation;

        public List<Entity> child = new List<Entity>();
        public Entity parrent;

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

        public void Draw(RenderTarget target, RenderStates states)
        {
            Sprite sprite = new Sprite(texture);
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
    }
}
