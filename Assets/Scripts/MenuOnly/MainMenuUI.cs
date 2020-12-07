using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject MainButtons;
    public GameObject LevelButtons;
    public GameObject BackButton;
    public Button BackButt;
    void Start()
    {
        LevelButtons.SetActive(false);
        BackButton.SetActive(false);
    }

    public void LoadLevelScreen(bool value)
    {
        if (value)
        {
            LevelButtons.SetActive(true);
            MainButtons.SetActive(false);
            BackButton.SetActive(true);
            BackButt.onClick.AddListener(hideLevels);
        }
        if (!value)
        {
            LevelButtons.SetActive(false);
            MainButtons.SetActive(true);
            BackButton.SetActive(false);
        }
    }

    public void hideLevels()
    {
        LoadLevelScreen(false);
    }
}
