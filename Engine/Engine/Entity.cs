using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using Box2DX.Dynamics;

namespace Engine
{
    public class Entity: Drawable,ICloneable
    {
        public bool HideInGame;

        public Entity Owner;

        public bool active = true;

        public bool Trigger;

        public Body physicBody;

        public Texture texture;
        public string textureName;
        public Vector2f position;
        public float rotation;

        public List<Entity> child = new List<Entity>();
        public Entity parrent;
        Sprite sprite;
        public bool flipH;
        public bool flipV;
        public string type;

        public List<EntityParam> entityParams = new List<EntityParam>();

        public int[] intCustomSaveData;
        public float[] floatCustomSaveData;
        public string[] stringCustomSaveData;
        public bool[] boolCustomSaveData;

        public Collision[] collisions;

        ContactPoint p;

        public int lvlID;

        public Entity()
        {
            entityParams.Add(new EntityParam("name", ""));
        }

        public virtual void Start()
        {
            lvlID = GameMain.curentLevel.GetHashCode();
            
            foreach (Entity ent in child)
                ent.Start();

            //Physics.Physics.solver.OnAdd += Solver_OnAdd;

            Renderer.window.KeyPressed += KeyPressed;
            Renderer.window.KeyReleased += KeyReleased;
            Renderer.window.MouseButtonPressed += MouseButtonPressed;
            Renderer.window.MouseButtonReleased += MouseButtonReleased;
            Renderer.window.JoystickButtonPressed += JoystickButtonPressed;
            Renderer.window.JoystickButtonReleased += JoystickButtonReleased;

        }

        public virtual void JoystickButtonReleased(object sender, SFML.Window.JoystickButtonEventArgs e)
        {
            
        }

        public virtual void JoystickButtonPressed(object sender, SFML.Window.JoystickButtonEventArgs e)
        {
            
        }

        public virtual void MouseButtonReleased(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            
        }

        public virtual void MouseButtonPressed(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            
        }

        public virtual void KeyReleased(object sender, SFML.Window.KeyEventArgs e)
        {
            
        }

        public virtual void KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            
        }

        public virtual void OnHit(Entity ent)
        {
            
        }

        public void Destroy()
        {
            try
            {
                physicBody._shapeList._isSensor = true;
                Physics.Physics.world.DestroyBody(physicBody);
            }
            catch (SystemException) { };
            GameMain.curentLevel.entities.Remove(this);
            active = false;
            UnbindKeys();
        }

        public void UnbindKeys()
        {
            Renderer.window.KeyPressed -= KeyPressed;
            Renderer.window.KeyReleased -= KeyReleased;
            Renderer.window.MouseButtonPressed -= MouseButtonPressed;
            Renderer.window.MouseButtonReleased -= MouseButtonReleased;
            Renderer.window.JoystickButtonPressed -= JoystickButtonPressed;
            Renderer.window.JoystickButtonReleased -= JoystickButtonReleased;
        }

        public virtual void Update()
        {
            
            foreach (Entity ent in child)
                ent.Update();

        }

        public virtual void EditorUpdate()
        {

        }

        public virtual void SetTexture(string tex)
        {
            textureName = tex;
            Texture Texture = TexturesData.GetTexture(tex);
            if (sprite == null) {
                sprite = new Sprite(Texture);
                return;
            }

            texture = Texture;
            sprite.Texture = texture;
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            float x = 1;
            float y = 1;
            if (flipH) x = -1;
            if (flipV) y = -1;
            sprite.Position = new Vector2f(position.X, position.Y * -1);
            sprite.Rotation = rotation;
            sprite.Scale = new Vector2f(x, y);
            sprite.Origin = new Vector2f(sprite.TextureRect.Width/2f, sprite.TextureRect.Height/2f);
            target.Draw(sprite);
        }

        public void AddChild(Entity ent)
        {
            ent.parrent = this;
            child.Add(ent);

        }

        public virtual Entity GetCopy()
        {
            return (Entity)this.MemberwiseClone();
        }

        public virtual void UpdateCollision()
        {
            
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public EntityParam GetParam(string name)
        {

            foreach (EntityParam param in entityParams)
                if (param.name == name) return param;

            return null;
        }

    }
}
