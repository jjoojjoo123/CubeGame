using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Canvas WinCanvas;
    public Canvas LoseCanvas;

    GameObject WinAudio;
    AudioSource winAudioData;
    GameObject GameOverAudio;
    AudioSource gameOverAudioData;

    // Use this for initialization
    void Start () {
        WinCanvas.enabled = false;
        LoseCanvas.enabled = false;

        WinAudio = GameObject.Find("winAudio");
        winAudioData = WinAudio.GetComponent<AudioSource>();

        GameOverAudio = GameObject.Find("gameOverAudio");
        gameOverAudioData = GameOverAudio.GetComponent<AudioSource>();
    }

    public void Win_Game()
    {
        WinCanvas.enabled = true;
        winAudioData.Play(0);
       // StartCoroutine(NewGame(3.0F));
    }

    public void Lose_Game()
    {
        LoseCanvas.enabled = true;
        gameOverAudioData.Play(0);
        // StartCoroutine(NewGame(3.0F));
    }

    IEnumerator NewGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Level1");
    }

}
