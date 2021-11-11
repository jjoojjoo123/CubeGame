using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlwaysUI : MonoBehaviour {
    GameObject ButtonAudio;
    AudioSource buttonAudioData;

    void Start()
    {
        ButtonAudio = GameObject.Find("buttonAudio");
        buttonAudioData = ButtonAudio.GetComponent<AudioSource>();
    }

    public void backToLevel()
    {
        buttonAudioData.Play(0);
        SceneManager.LoadScene("LevelScene");
    }

    public void restart()
    {
        buttonAudioData.Play(0);
        StartCoroutine(NewGame(0.0F));
    }

    public void toMain()
    {
        buttonAudioData.Play(0);
        SceneManager.LoadScene("MainScene");
    }

    public void toLevel2()
    {
        buttonAudioData.Play(0);
        SceneManager.LoadScene("Level2");
    }

    IEnumerator NewGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
