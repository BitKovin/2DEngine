using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    [Serializable]
    class BrushData
    {
        public float posX;
        public float posY;
        public float SizeX;
        public float SizeY;
        public string tex;
        public BrushData(Brush brush)
        {
            posX = brush.position.X;
            posY = brush.position.Y;
            SizeX = brush.size.X;
            SizeY = brush.size.Y;
            tex = brush.textureName;
        }
    }
}
