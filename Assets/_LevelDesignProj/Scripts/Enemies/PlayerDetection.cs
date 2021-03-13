using System;
using UnityEngine;

namespace _LevelDesignProj.Scripts.Enemies
{
    public class PlayerDetection : MonoBehaviour
    {
        [SerializeField] private float eyeSightRange;
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
                    playerDetected.raise();
                }
                range.enabled = true;
            }
        }

        bool CheckLineOfSight(Vector3 playerPosition)
        {
            Ray sight = new Ray(transform.position, playerPosition + new Vector3(0, 0.55f, 0) - transform.position);
            RaycastHit hit;
            if (Physics.Raycast(sight, out hit, eyeSightRange))
            {
                if (hit.transform == transform)
                {
                    RaycastHit hit2;
                    sight = new Ray(hit.point, playerPosition - hit.point);
                    if (Physics.Raycast(sight, out hit2, 5))
                    {
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
            return false;
        }
    }
}