using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using SFML.System;
using SFML.Graphics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Game.Entities;

namespace Engine
{
    public class Functions
    {


        public static Entity EntityFromString(string name)
        {
            return Game.EntitiesList.GetEntity(name);
        }

        public static byte[] ObjectToByteArray(object obj)
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

        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

        public static Vector2f SnapToGrid(Vector2f val, float grid)
        {
            return new Vector2f(val.X - val.X % grid, val.Y - val.Y % grid);
        }

    }
}
