using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    [UpdateBefore(typeof(HybridPhysicsEventsClearSystem))]
    public partial class HybridPlayerScoreSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .WithStructuralChanges()
                .ForEach((HybridPhysicsEvents physicsEvents, HybridPlayer player) =>
                {
                    foreach (Collision collision in physicsEvents.CollisionEnter)
                    {
                        if (!collision.gameObject.CompareTag("Food"))
                        {
                            continue;
                        }

                        Debug.LogFormat("{0}: Collision enter {1}", player.gameObject.name, collision.gameObject.name);

                        var spawner = collision.gameObject.GetComponent<HybridShadowSpawner>();
                        var food = collision.gameObject.GetComponent<HybridFood>();

                        player.Score += food.Score;

                        spawner.Destroy();
                    }
                })
                .Run();
        }
    }

}
