using System;
using UnityEngine;

namespace _LevelDesignProj.Scripts.Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        private IEnemyMovement _enemyMovement;

        private void Awake()
        {
            _enemyMovement = GetComponent<IEnemyMovement>();
        }

        private void Update()
        {
            _enemyMovement.Move();
        }
    }
}