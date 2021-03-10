using System;
using UnityEngine;
using UnityEngine.AI;

namespace _LevelDesignProj.Scripts.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class GhostMovement : MonoBehaviour, IEnemyMovement
    {
        private NavMeshAgent _agent;
        [SerializeField] PathPoints path;
        int index = -1;
        Vector3 target;
        
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Move()
        {
            if (index == -1)
            {
                (index, target) = path.GetNearestChild(transform.position);
                _agent.destination = target;
            }
            else if(Vector3.Distance(transform.position, target) < 1)
            {
                (index, target) = path.GetNextChild(index);
                _agent.destination = target;
            }
        }
        
        
        
        
    }
}