using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Game
{
    public class Game
    {

        public static void Init()
        {
            Program.isEditor = true;
            DebugDraw.enabled = true;

            TexturesData.Add("bullet", "bullet.png");

        }

        public static void Start()
        {
        }

        public static void Update()
        {
            
        }

    }
}
