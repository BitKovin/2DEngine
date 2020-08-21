using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class StateMachine
    {
        public Dictionary<string, Animation> states = new Dictionary<string, Animation>();
        string curentState;
        public string OutFrame;

        public void Update()
        {
            states[curentState].Update();
            OutFrame = states[curentState].CurentFrame;
        }
        public void SetState(string state)
        {
            if (state == curentState) return;
            if(curentState!=null)
            states[curentState].curentFrameId = 0;
            curentState = state;
        }
    }
}
