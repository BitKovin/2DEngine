using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Game.Entities;
using SFML.Graphics;
using SFML.System;

namespace Game.Entities
{
    class MyTrigger:Trigger
    {

        public MyTrigger():base()
        {
            
        }

        public override void OnTriggerStay(Entity entity)
        {
            base.OnTriggerStay(entity);
            Console.WriteLine(entity.GetParam("name").value);
        }
    }
}
