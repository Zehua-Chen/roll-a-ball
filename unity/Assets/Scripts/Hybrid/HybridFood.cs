using UnityEngine;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    public class HybridFood : MonoBehaviour, IComponentData
    {
        public float RotationSpeed;
        public int Score = 1;
    }
}
