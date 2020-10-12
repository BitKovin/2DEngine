﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Dynamics;

namespace Engine.Physics
{
    public class Solver : ContactListener
    {
        public delegate void EventSolver(Entity body1, Entity body2);
        public event EventSolver OnAdd;
        public event EventSolver OnPersist;
        public event EventSolver OnResult;
        public event EventSolver OnRemove;

        public override void Add(ContactPoint point)
        {
            base.Add(point);

            OnAdd?.Invoke((Entity)point.Shape1.GetBody().GetUserData(), (Entity)point.Shape2.GetBody().GetUserData());
        }

        public override void Persist(ContactPoint point)
        {
            base.Persist(point);

            OnPersist?.Invoke((Entity)point.Shape1.GetBody().GetUserData(), (Entity)point.Shape2.GetBody().GetUserData());
        }

        public override void Result(ContactResult point)
        {
            base.Result(point);

            OnResult?.Invoke((Entity)point.Shape1.GetBody().GetUserData(), (Entity)point.Shape2.GetBody().GetUserData());
        }

        public override void Remove(ContactPoint point)
        {
            base.Remove(point);

            OnRemove?.Invoke((Entity)point.Shape1.GetBody().GetUserData(), (Entity)point.Shape2.GetBody().GetUserData());
        }
    }

}
