using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject LosePanel;
    public void OpenLosePanel()
    {
        LosePanel.SetActive(true);
    }
    public void CloseLosePanel()
    {
        LosePanel.SetActive(false);
    }
}
