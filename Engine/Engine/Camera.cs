﻿using System;
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
        public static Vector2f position = new Vector2f(0,0);
        public static Entity target;
        public static float zoom = 1f;

        public static void Update()
        {
            if(target!=null)
                position = new Vector2f(target.position.X, -target.position.Y);
            GameMain.text.text = position.ToString();
        }

    }
}
