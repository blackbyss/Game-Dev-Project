using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public Button Button;
    public AudioSource myFx;
    public AudioClip HoverSoundFx;
    public AudioClip ClickSoundFx;
    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(RestartGame);
    }
    private void HoverSound()
    {
        myFx.PlayOneShot(HoverSoundFx);
    }

    private void ClickSound()
    {
        myFx.PlayOneShot(ClickSoundFx);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
