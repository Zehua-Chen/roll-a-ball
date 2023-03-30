using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    public partial class HybridPhysicsEventsClearSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .ForEach((HybridPhysicsEvents physicsEvents) =>
                {
                    physicsEvents.CollisionEnter.Clear();
                })
                .Run();
        }
    }

}
