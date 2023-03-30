using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    public partial class HybridPlayerMovementSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .ForEach((HybridPlayer movement) =>
                {
                    float dt = SystemAPI.Time.DeltaTime;
                    float horizontal = Input.GetAxis("Horizontal");
                    float vertical = Input.GetAxis("Vertical");

                    horizontal *= movement.MovementSpeed * dt;
                    vertical *= movement.MovementSpeed * dt;

                    var rigidbody = movement.GetComponent<Rigidbody>();

                    rigidbody.AddForce(new Vector3(horizontal, 0.0f, vertical), ForceMode.Impulse);
                }).Run();
        }
    }
}
