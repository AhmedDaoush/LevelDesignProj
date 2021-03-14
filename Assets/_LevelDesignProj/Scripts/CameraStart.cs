using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
    [SerializeField] EventSO StartGame;
    private void OnEnable()
    {
        StartGame.raise();
    }
}
