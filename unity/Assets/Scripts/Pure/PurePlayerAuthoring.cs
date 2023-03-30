using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Pure
{
    public class PurePlayerAuthoring : MonoBehaviour
    {
        public float MovementSpeed;

        public class Baker : Baker<PurePlayerAuthoring>
        {
            public override void Bake(PurePlayerAuthoring authoring)
            {
                AddComponent(new PurePlayer()
                {
                    MovementSpeed = authoring.MovementSpeed
                });
            }
        }
    }
}
