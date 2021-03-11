using System;
using UnityEngine;

namespace _LevelDesignProj.Scripts.Enemies
{
    public class PlayerDetection : MonoBehaviour
    {
        [SerializeField]private float eyeSight;
        [SerializeField] private EventSO playerDetected;

        private MeshCollider range;
        
        private void Awake()
        {
            range = GetComponent<MeshCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                range.enabled = false;
                if (CheckLineOfSight(other.transform.position))
                {
                    Debug.Log("Final Hit");
                    playerDetected.raise();
                }
                range.enabled = true;
            }
        }

        bool CheckLineOfSight(Vector3 playerPosition)
        {
            Ray sight = new Ray(transform.position, playerPosition - transform.position);
            bool found = false;
            RaycastHit hit;              
            Debug.DrawRay(transform.position, playerPosition - transform.position, Color.red, 3);

            if (Physics.Raycast(sight, out hit,  eyeSight))
            {
                if (hit.transform == transform)
                {
                    RaycastHit hit2;  
                    sight = new Ray(hit.point, playerPosition - hit.point);
                    
                    if (Physics.Raycast( sight, out hit2, 5))
                    {
                        Debug.Log(hit2.collider.name);
                        Debug.DrawRay(hit.point, playerPosition-hit.point, Color.blue, 5);
                        if (hit.collider.CompareTag("Player"))
                        {
                            return true;
                        }
                    }
                }
                else if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
            return found;
        }
    }
}