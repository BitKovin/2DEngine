using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Engine
{
    class TexturesData
    {
        static Dictionary<string,Texture> textures = new Dictionary<string, Texture>();

        public static void LoadTextures()
        {
            textures.Add("playerIdle", new Texture("Assets//Player//Animations//stay.png"));
            textures.Add("b_test", new Texture("Assets//Brushes//test.png"));
        }

        public static Texture GetTexture(string name)
        {
            return textures[name];
        }

    }
}
