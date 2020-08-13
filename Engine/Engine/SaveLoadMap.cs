using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Engine.Editor;

namespace Engine
{
    class SaveLoadMap
    {

        public static void Save(Level level)
        {
            MapData mapData;
            try
            {
                mapData = new MapData();
                mapData.brushes = new byte[level.brushes.Count][];
                mapData.entities = new byte[level.entities.Count][];
                int i = 0;
                foreach (Brush brush in level.brushes)
                {
                    BrushData brushData = new BrushData(brush);
                    mapData.brushes[i] = Functions.ObjectToByteArray(brushData);
                    i++;
                }
                i = 0;
                foreach (Entity entity in level.entities)
                {
                    EntityData data = new EntityData(entity);
                    mapData.entities[i] = Functions.ObjectToByteArray(data);
                    i++;
                }

                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = new FileStream($"Assets//maps//{EditorMain.FileName}.map", FileMode.Create);

                formatter.Serialize(file, mapData);
                file.Close();
            }catch(SystemException ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void Load(Level level)
        {
            if(File.Exists($"Assets//maps//{EditorMain.FileName}.map"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = new FileStream($"Assets//maps//{EditorMain.FileName}.map", FileMode.Open);
                MapData mapData = (MapData)formatter.Deserialize(file);
                level.brushes = mapData.GetBrushes();
                level.entities = mapData.GetEntities();

                file.Close();
            }
        }
    }
}
