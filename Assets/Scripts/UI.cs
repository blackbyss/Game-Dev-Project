using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject EndGamePanel;
    public TextMeshProUGUI EndGameText;
    public Button BackToMenuButton;

    private void Awake()
    {
        Events.OnEndLevel += OnEndLevel;

        BackToMenuButton.onClick.AddListener(OnBackToMenuPressed);
        EndGamePanel.SetActive(false);
    }
    public void OnDestroy()
    {
        Events.OnEndLevel -= OnEndLevel;
    }

    public void OnEndLevel(bool isWin)
    {
        EndGamePanel.SetActive(true);
        if (isWin)
        {
            EndGameText.text = "Victory!";
        }
        else
        {
            EndGameText.text = "Game Lost!";
        }
    }

    public void OnBackToMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
