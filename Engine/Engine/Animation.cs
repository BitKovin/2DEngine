using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Engine
{
    class Animation
    {
        public float frameTime;
        public int curentFrameId;
        public List<string> frames;
        public string CurentFrame;
        float time;
        public Animation()
        {
            frames = new List<string>();
        }

        public void Update()
        {
            while(time>frameTime)
            {
                curentFrameId++;
                if (curentFrameId == frames.Count)
                    curentFrameId = 0;
                time -= frameTime;
            }
            time += Time.DeltaTime;
            CurentFrame = frames[curentFrameId];
        }

    }
}
