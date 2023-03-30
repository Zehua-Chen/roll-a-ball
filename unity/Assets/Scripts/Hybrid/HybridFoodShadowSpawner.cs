using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    [RequireComponent(typeof(HybridFood))]
    public class HybridFoodShadowSpawner : HybridShadowSpawner
    {
        public override void Awake()
        {
            base.Awake();

            World.EntityManager.AddComponent<HybridFood>(Entity);
            World.EntityManager.SetComponentData(Entity, GetComponent<HybridFood>());
        }
    }
}
