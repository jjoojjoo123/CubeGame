using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour {

    private int LevelAmount = 5;
    private int CurrentLevel;


    public void GoNextLevel()
    {

        //PlayerPrefs.SetInt("Level2", 1);
        CheckCurrentLevel();
        SceneManager.LoadScene(6);

    }

    void CheckCurrentLevel()
    {
        for (int i = 1; i < LevelAmount; i++)
        {
            if(SceneManager.GetActiveScene().name == "Level" + i)
            {
                CurrentLevel = i;
                SaveMyGame();
            }
        }
    }

    void SaveMyGame()
    {
        int NextLevel = CurrentLevel + 1;
        if(NextLevel <= LevelAmount)
        {
            PlayerPrefs.SetInt("Level" + NextLevel.ToString(), 1);

        }
    }
}
