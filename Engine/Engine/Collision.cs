using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Engine
{
    class Collision
    {

        public Vector2i position;
        public Vector2i size;

        public static bool MakeCollionTest(Collision col1,Collision col2)
        {

            IntRect Col1 = new IntRect(col1.position-(col1.size/2), col1.size);
            IntRect Col2 = new IntRect(col2.position-(col2.size/2), col2.size);

            return Col1.Intersects(Col2);

        }

    }
}
