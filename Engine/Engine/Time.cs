using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.System;

namespace Engine
{
    class Time
    {
        public static float DeltaTime;
        static Clock clock;

        public static void Init()
        {
            clock = new Clock();
        }
        public static void FrameStart()
        {

            DeltaTime = clock.Restart().AsMilliseconds() * 0.001f;
            if (DeltaTime > 0.07f) DeltaTime = 0.07f;

        }

    }
}
