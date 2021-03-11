using System;
using UnityEngine;
using UnityEngine.AI;

namespace _LevelDesignProj.Scripts.Enemies
{
    public class GargolyeMovement : MonoBehaviour, IEnemyMovement
    {
        [SerializeField] private float angularSpeed;
        [SerializeField] private Vector3 rotationAngle;
        private Quaternion _destinationRotation;
        private Quaternion _originalRotation;
        private Vector3 _destinationPosition;
        
        private void Awake()
        {
             _destinationPosition = transform.forward;
            _originalRotation = transform.rotation;
            _destinationRotation = Quaternion.Euler(rotationAngle);

        }
        public void Move()
        {
            if (transform.rotation == _destinationRotation)
            {
                if (_destinationRotation == Quaternion.Euler(rotationAngle))
                {
                    _destinationRotation = _originalRotation;
                }
                else
                {
                    _destinationRotation = Quaternion.Euler(rotationAngle);
                }
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, _destinationRotation, Time.fixedDeltaTime * angularSpeed);
        }

        
    }
}