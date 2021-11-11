using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour 
{
    Button[] LevelButtons;

    private void Awake()
    {
        int ReachLevel = PlayerPrefs.GetInt("ReachLevel", 1);

        LevelButtons = new Button[transform.childCount];

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            LevelButtons[i] = transform.GetChild(i).GetComponent<Button>();
            LevelButtons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();

            if (i + 1 > ReachLevel)
            {

                LevelButtons[i].interactable = false;

            }
        }
    }

    public void PlayLevel(int Level)
    {
        SceneManager.LoadScene(Level);
    }

}
