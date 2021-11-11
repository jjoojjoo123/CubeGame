using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundMusic : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("MainScene");
    }
}
