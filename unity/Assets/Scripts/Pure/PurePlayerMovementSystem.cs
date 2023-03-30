using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Physics.Aspects;
using Unity.Mathematics;

namespace DOTSRollABall.Pure
{
    public partial struct PurePlayerMovementSystem : ISystem
    {
        [StructLayout(LayoutKind.Auto)]
        public partial struct Job : IJobEntity
        {
            public float Horizontal;
            public float Vertical;
            public float DeltaTime;

            public void Execute(in PurePlayer player, ref RigidBodyAspect rigidBody)
            {
                float horizontal = Horizontal * player.MovementSpeed * DeltaTime;
                float vertical = Vertical * player.MovementSpeed * DeltaTime;
                float3 impulse = new(horizontal, 0, vertical);

                rigidBody.ApplyLinearImpulseLocalSpace(impulse);
            }
        }

        public void OnCreate(ref SystemState state)
        {
        }

        public void OnDestroy(ref SystemState state)
        {
        }

        public void OnUpdate(ref SystemState state)
        {
            new Job()
            {
                Horizontal = Input.GetAxis("Horizontal"),
                Vertical = Input.GetAxis("Vertical"),
                DeltaTime = SystemAPI.Time.DeltaTime
            }.ScheduleParallel();
        }
    }
}
