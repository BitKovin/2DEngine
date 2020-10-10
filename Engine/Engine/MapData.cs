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
        public byte[][] entities;
        public List<Brush>GetBrushes()
        {
            List<Brush> brushList = new List<Brush>();
            foreach(byte[] Byte in brushes)
            {
                Brush brush = new Brush();
                BrushData data = Functions.FromByteArray<BrushData>(Byte);
                brush.SetTexture(data.tex);
                brush.SetPosition(new Vector2f(data.posX, data.posY));
                brush.SetSize(new Vector2f(data.SizeX, data.SizeY));
                brushList.Add(brush);
            }
            return brushList;
        }
        
        public List<Entity>GetEntities()
        {
            List<Entity> entityList = new List<Entity>();

            foreach(byte[] Byte in entities)
            {
                EntityData data = Functions.FromByteArray<EntityData>(Byte);
                Entity entity = Functions.EntityFromString(data.type);
                if (entity != null)
                {
                    EntityParam[] entityParams = new EntityParam[data.entityParams.Length];
                    for (int i = 0; i < data.entityParams.Length; i++)
                    {
                        entity.entityParams[i].value = data.entityParams[i];
                    }
                    entity.position = new Vector2f(data.posX, data.posY);
                    entity.rotation = data.rot;
                    entity.SetTexture(data.tex);
                    entity.type = data.type;
                    entity.flipH = data.flipH;
                    entity.flipV = data.flipV;

                    entity.UpdateCollision();

                    entity.intCustomSaveData = data.intCustomSaveData;
                    entity.floatCustomSaveData = data.floatCustomSaveData;
                    entity.stringCustomSaveData = data.stringCustomSaveData;
                    entity.boolCustomSaveData = data.boolCustomSaveData;
                    entityList.Add(entity);
                }
            }

            return entityList;
        }
    }
}
