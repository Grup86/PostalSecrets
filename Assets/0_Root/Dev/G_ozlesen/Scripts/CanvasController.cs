using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public List<GameObject> Panels;
    public GameObject StartPanel;
    public GameObject InGamePanel;
    public void StartGameButtonClick()
    {
        TogglePanel(InGamePanel);
        GameManager.Instance.StartGame = true;
    }
    public void TogglePanel(GameObject panel)
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(Panels[i] == panel);
        }
    }
}
