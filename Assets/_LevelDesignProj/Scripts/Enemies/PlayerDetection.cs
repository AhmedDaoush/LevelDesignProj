using System;
using UnityEngine;

namespace _LevelDesignProj.Scripts.Enemies
{
    public class PlayerDetection : MonoBehaviour
    {
        
        [SerializeField] private EventSO playerDetected;
        private ConeCollider _eyeSight;

        private void Awake()
        {
            _eyeSight = GetComponent<ConeCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (CheckLineOfSight(other.transform.position))
                {
                    Debug.Log("Final Hit");
                    playerDetected.raise();
                }
            }
        }

        bool CheckLineOfSight(Vector3 playerPosition)
        {
            Ray sight = new Ray(transform.position, playerPosition - transform.position);
            bool found = false;
            RaycastHit hit;              
            Debug.DrawRay(transform.position, playerPosition - transform.position, Color.red);

            var y = Physics.RaycastAll(sight, _eyeSight.GetDistance);

            foreach (var x in y)
            {
                if (x.collider.CompareTag("Player"))
                {
                    found = true;
                }
            }
            
            return found;
        }
    }
}