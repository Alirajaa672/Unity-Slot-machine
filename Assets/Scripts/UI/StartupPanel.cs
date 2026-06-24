using UnityEngine;

public class StartupPanel : MonoBehaviour
{
    public GameObject creditsPanel;

    public void StartGame()
    {
        creditsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }
}