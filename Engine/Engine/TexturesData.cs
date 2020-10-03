using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Engine
{
    public class TexturesData
    {
        static Dictionary<string,Texture> textures = new Dictionary<string, Texture>();

        public static void LoadTextures()
        {
            textures.Add("playerIdle", new Texture("Assets//Player//Animations//stay.png"));
            textures.Add("b_test", new Texture("Assets//Brushes//test.png"));
            textures.Add("playerWalk0", new Texture("Assets//Player//Animations//walk0.png"));
            textures.Add("playerWalk1", new Texture("Assets//Player//Animations//walk1.png"));
            textures.Add("playerWalk2", new Texture("Assets//Player//Animations//walk2.png"));
            textures.Add("playerWalk3", new Texture("Assets//Player//Animations//walk3.png"));
            textures.Add("playerWalk4", new Texture("Assets//Player//Animations//walk4.png"));
            textures.Add("playerWalk5", new Texture("Assets//Player//Animations//walk5.png"));
            textures.Add("playerWalk6", new Texture("Assets//Player//Animations//walk6.png"));
            textures.Add("playerWalk7", new Texture("Assets//Player//Animations//walk7.png"));
            textures.Add("playerWalk8", new Texture("Assets//Player//Animations//stay.png"));
            textures.Add("playerInAir", new Texture("Assets//Player//Animations//walk1.png"));
        }

        public static void Add(string name, string path)
        {
            textures.Add(name, new Texture(path));
        }

        public static Texture GetTexture(string name)
        {
            try
            {
                return textures[name];
            }catch(SystemException ex)
            {
                return textures["b_test"];
            }
        }

    }
}
