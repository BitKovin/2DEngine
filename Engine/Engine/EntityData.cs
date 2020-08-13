﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    [Serializable]
    class EntityData
    {
        public string type;
        public float posX;
        public float posY;
        public float rot;
        public string tex;
        public bool flipH;
        public bool flipV;

        public int[] intCustomSaveData;
        public float[] floatCustomSaveData;
        public string[] stringCustomSaveData;
        public bool[] boolCustomSaveData;

        public EntityData(Entity entity)
        {
            type = entity.type;
            posX = entity.position.X;
            posY = entity.position.Y;
            rot = entity.rotation;
            tex = entity.textureName;
            flipH = entity.flipH;
            flipV = entity.flipV;
            intCustomSaveData = entity.intCustomSaveData;
            floatCustomSaveData = entity.floatCustomSaveData;
            stringCustomSaveData = entity.stringCustomSaveData;
            boolCustomSaveData = entity.boolCustomSaveData;
        }

    }
}