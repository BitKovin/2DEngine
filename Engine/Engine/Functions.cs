using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using SFML.System;
using SFML.Graphics;
using Engine.Entities;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Engine
{
    class Functions
    {

        public static Vector2f Vector2ToVector2f(Vector2 vec2)
        {
            return new Vector2f(vec2.X, vec2.Y);
        }

        public static Vector2 Vector2fToVector2(Vector2f vec2f)
        {
            return new Vector2(vec2f.X, vec2f.Y);
        }


        public static Entity EntityFromString(string name)
        {
            switch (name)
            {
                case("Player"):
                    Console.WriteLine("playerSpawned");
                    return new Player();
            }
            return null;
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
