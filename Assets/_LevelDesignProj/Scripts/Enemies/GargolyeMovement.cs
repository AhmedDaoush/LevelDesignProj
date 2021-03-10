using System;
using UnityEngine;
using UnityEngine.AI;

namespace _LevelDesignProj.Scripts.Enemies
{
    public class GargolyeMovement : MonoBehaviour, IEnemyMovement
    {
        private NavMeshAgent _agent;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = 0;
            _agent.angularSpeed = 2;
        }
        public void Move()
        {
            
            _agent.destination = Vector3.forward;
        }

        
    }
}