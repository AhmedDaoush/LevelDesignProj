using System;
using UnityEngine;
using UnityEngine.AI;

namespace _LevelDesignProj.Scripts.Enemies
{
    public class GargolyeMovement : MonoBehaviour, IEnemyMovement
    {
        [SerializeField] private float angularSpeed;
        [SerializeField] private Vector3 rotationAngleFrom;
        [SerializeField] private Vector3 rotationAngleTo;
        private Quaternion _destinationRotation;
        private Quaternion _originalRotation;
        
        private void Awake()
        {
            _originalRotation = Quaternion.Euler(rotationAngleFrom);
            _destinationRotation = Quaternion.Euler(rotationAngleTo);

        }
        public void Move()
        {
            if (transform.rotation == _destinationRotation)
            {
                if (_destinationRotation == Quaternion.Euler(rotationAngleTo))
                {
                    _destinationRotation = _originalRotation;
                }
                else
                {
                    _destinationRotation = Quaternion.Euler(rotationAngleTo);
                }
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, _destinationRotation, Time.fixedDeltaTime * angularSpeed);
        }

        
    }
}