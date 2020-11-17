using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string LoadedSceneName = "SampleScene";
    private Button button;
    public void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(Pressed);
        }
    }

    public void Pressed()
    {
        Debug.Log("Level 1 loading...");
        SceneManager.LoadScene(LoadedSceneName);
    }
}
