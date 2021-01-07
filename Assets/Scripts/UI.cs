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
    public TextMeshProUGUI LivesText;
    public Button BackToMenuButton;

    public AudioSource GameoverSound;
    //public AudioSource VictorySound;
    public AudioSource LifeLossSound;

    private int lives = 5;

    private void Awake()
    {
        Events.OnSetLives += OnSetLives;
        Events.OnRequestLives += OnRequestLives;
        Events.OnEndLevel += OnEndLevel;

        BackToMenuButton.onClick.AddListener(OnBackToMenuPressed);
        EndGamePanel.SetActive(false);
        Events.SetLives(lives);
    }
    public void OnDestroy()
    {
        Events.OnSetLives -= OnSetLives;
        Events.OnRequestLives -= OnRequestLives;
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

    public void OnSetLives(int value)
    {
        if (lives > 0 && value <= 0)
        {
            GameoverSound.Play();
            Events.EndLevel(false);
        }
        if (lives > value) // if life is lost
        {
            LifeLossSound.Play();
        }
        lives = Mathf.Max(0, value);
        LivesText.text = "Lives: " + lives;
    }
    public int OnRequestLives() => lives;
    public void OnBackToMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
