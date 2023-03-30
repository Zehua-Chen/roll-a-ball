using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    [RequireComponent(typeof(HybridPlayer))]
    public class HybridPlayerShadowSpawner : HybridShadowSpawner
    {
        public override void Awake()
        {
            base.Awake();

            World.EntityManager.AddComponent<HybridPlayer>(Entity);
            World.EntityManager.SetComponentData(Entity, GetComponent<HybridPlayer>());

            World.EntityManager.AddComponent<HybridPhysicsEvents>(Entity);
            World.EntityManager.SetComponentData(Entity, new HybridPhysicsEvents());
        }
    }
}
