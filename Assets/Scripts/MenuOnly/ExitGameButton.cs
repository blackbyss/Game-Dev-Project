using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitGameButton : MonoBehaviour
{
    private Button button;
    public void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(doExitGame);
        }
    }

    void doExitGame()
    {
        Debug.Log("Closing game...");
        Application.Quit();
    }
}
