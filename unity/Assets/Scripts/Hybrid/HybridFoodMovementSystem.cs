using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    public partial class HybridFoodMovementSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .ForEach((HybridFood food) =>
                {
                    float dt = SystemAPI.Time.DeltaTime;
                    float rotation = food.RotationSpeed * dt;

                    food.gameObject.transform.Rotate(new Vector3(0, rotation, 0));
                })
                .Run();
        }
    }
}
