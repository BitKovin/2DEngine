using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class EntityParam:ICloneable
    {
        public string name;
        public string value;

        public EntityParam()
        { }

        public EntityParam(string n, string v)
        {
            name = n;
            value = v;
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone() as EntityParam;
        }
    }
}
