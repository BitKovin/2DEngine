using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal
{
    class Saved
    {
        /*
        ///////////////////////////////////////////any to byte////////////////////////////////////////////////
        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////load texture to stream/////////////////////////////////////
            FileStream file = File.OpenRead("image.png");
            byte[] bytes = new byte[file.Length];
            for (int i = 0; i < file.Length; i++)
            {
                bytes[i] = (byte)file.ReadByte();
            }
            Texture tex = new Texture(bytes);
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        */
    }
}
