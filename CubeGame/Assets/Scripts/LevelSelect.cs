using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
    GameObject ButtonAudio;
    AudioSource buttonAudioData;

    void Start()
    {
        ButtonAudio = GameObject.Find("buttonAudio");
        buttonAudioData = ButtonAudio.GetComponent<AudioSource>();
    }

    public void load2x2x2()
    {
        buttonAudioData.Play(0);
        SceneManager.LoadScene("2x2x2");
    }
    public void load4x4x4()
    {
        buttonAudioData.Play(0);
        SceneManager.LoadScene("4x4x4");
    }
    public void loadArise3X3()
    {
        buttonAudioData.Play(0);
        SceneManager.LoadScene("Arise 3X3");
    }
    public void load3x3x3()
    {
        buttonAudioData.Play(0);
        SceneManager.LoadScene("3x3x3");
    }
    
}
