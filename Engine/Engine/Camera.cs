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
        public static Vector2 position = new Vector2(0,0);
        public static Entity target;
        public static float speed = 500f;
        public static float zoom = 1;

        public static void Update()
        {
            if(target!=null)
                position = new Vector2(target.position.X, -target.position.Y);
        }

    }
}
