using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using SFML.System;

namespace Engine
{
    class Camera
    {
        public static Vector2 position;
        public static Entity target;
        public static float speed = 500f;

        public static void Update()
        {

            position = new Vector2(target.position.X, -target.position.Y);
        }

    }
}
