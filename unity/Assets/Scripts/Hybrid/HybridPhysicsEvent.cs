using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    public class HybridPhysicsEvents : IComponentData
    {
        public List<Collision> CollisionEnter = new();
    }
}
