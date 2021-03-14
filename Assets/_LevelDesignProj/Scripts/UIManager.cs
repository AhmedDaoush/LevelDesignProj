using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject LosePanel; 
    [SerializeField]
    GameObject WinPanel;
    public void OpenLosePanel()
    {
        LosePanel.SetActive(true);
    }
    public void CloseLosePanel()
    {
        LosePanel.SetActive(false);
    }
    public void OpenWinPanel()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
