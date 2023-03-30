using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    public class HybridShadowSpawner : MonoBehaviour
    {
        public World World { get; private set; }
        public Entity Entity { get; private set; }

        public virtual void Awake()
        {
            World = World.DefaultGameObjectInjectionWorld;
            Entity = World.EntityManager.CreateEntity();
            World.EntityManager.SetName(Entity, $"{@gameObject.name} (Shadow)");
        }

        public void Destroy()
        {
            World.EntityManager.DestroyEntity(Entity);
            Destroy(gameObject);
        }
    }
}
