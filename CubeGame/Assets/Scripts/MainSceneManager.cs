using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour {
    GameObject ButtonAudio;
    AudioSource buttonAudioData;

    public void Start()
    {
        ButtonAudio = GameObject.Find("buttonAudio");
        buttonAudioData = ButtonAudio.GetComponent<AudioSource>();
        PlayerPrefs.DeleteAll();
    }

    public void OnPlayButton()
    {
        buttonAudioData.Play(0);
        SceneManager.LoadScene("Level1");
    }

    public void OnExitButton()
    {
        buttonAudioData.Play(0);
        Application.Quit();
    }
}
