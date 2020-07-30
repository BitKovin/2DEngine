using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Engine
{
    [Serializable]
    class MapData
    {
        public byte[][] brushes;

        public List<Brush>GetBrushes()
        {
            List<Brush> brushList = new List<Brush>();
            foreach(byte[] Byte in brushes)
            {
                Brush brush = new Brush();
                BrushData data = Functions.FromByteArray<BrushData>(Byte);
                brush.SetTexture(data.tex);
                brush.SetPosition(new Vector2i(data.posX, data.posY));
                brush.SetSize(new Vector2i(data.SizeX, data.SizeY));
                brushList.Add(brush);
            }
            return brushList;
        }

    }
}
