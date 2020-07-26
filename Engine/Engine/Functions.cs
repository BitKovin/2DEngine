using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using SFML.System;

namespace Engine
{
    class Functions
    {

        public static Vector2f Vector2ToVector2f(Vector2 vec2)
        {
            return new Vector2f(vec2.X, vec2.Y);
        }

        public static Vector2 Vector2fToVector2(Vector2f vec2f)
        {
            return new Vector2(vec2f.X, vec2f.Y);
        }

    }
}
