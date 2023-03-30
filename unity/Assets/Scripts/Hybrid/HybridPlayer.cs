using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Entities;

namespace DOTSRollABall.Hybrid
{
    public class HybridPlayer : MonoBehaviour, IComponentData
    {
        public float MovementSpeed;
        public int Score;
        public UIDocument PlayerHub;

        private HybridPlayerShadowSpawner m_ShadowSpawner;
        private Label m_ScoreLabel;

        private void Awake()
        {
            m_ShadowSpawner = GetComponent<HybridPlayerShadowSpawner>();
            m_ScoreLabel = PlayerHub.rootVisualElement.Q<Label>("Score");
        }

        private void Start()
        {
            SetScoreLabel();
        }

        private void Update()
        {
            SetScoreLabel();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var events = m_ShadowSpawner.World.EntityManager.GetComponentObject<HybridPhysicsEvents>(m_ShadowSpawner.Entity);
            events.CollisionEnter.Add(collision);
        }

        private void SetScoreLabel()
        {
            m_ScoreLabel.text = $"Score: {Score}";
        }
    }
}
