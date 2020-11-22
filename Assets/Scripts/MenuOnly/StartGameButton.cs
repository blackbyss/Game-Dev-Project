using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string LoadedSceneName = "SampleScene";
    public TextMeshProUGUI ButtonTextBox;
    public string ButtonText;
    private Button button;

    public AudioSource myFx;
    public AudioClip HoverSoundFx;
    public AudioClip ClickSoundFx;
    public void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(Pressed);
        }
        ButtonTextBox.text = ButtonText;
    }
    private void HoverSound()
    {
        myFx.PlayOneShot(HoverSoundFx);
    }

    private void ClickSound()
    {
        myFx.PlayOneShot(ClickSoundFx);
    }
    public void Pressed()
    {
        Debug.Log("Level 1 loading...");
        SceneManager.LoadScene(LoadedSceneName);
    }
}
