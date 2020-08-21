using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entities;

namespace Game
{
    public class EntitiesList
    {
        public static Dictionary<string,Type> entities = new Dictionary<string,Type>();

        public static void Load()
        {
            entities.Add("Player", typeof(Player));
        }

    }
}
