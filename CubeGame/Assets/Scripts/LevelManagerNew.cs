using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManagerNew : MonoBehaviour {

    [System.Serializable]
    public class Level
    {
        public string LevelText;
        public int Unlocked;
        public bool IsInteractable;

    }
    public GameObject levelButton;
    public Transform Spacer;
    public List<Level> LevelList;

	// Use this for initialization
	void Start () {

        //DelectAll();
        FillList();

	}
	
    void FillList()
    {
        foreach(var level in LevelList)
        {
            GameObject newbutton = Instantiate(levelButton) as GameObject;
            LevelButton button = newbutton.GetComponent<LevelButton>();
            button.LevelText.text = level.LevelText;

            if(PlayerPrefs.GetInt("Level" + button.LevelText.text) ==1)
            {
                level.Unlocked = 1;
                level.IsInteractable = true;
            }

            button.unlocked = level.Unlocked;
            button.GetComponent<Button>().interactable = level.IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => loadLevels("Level" + button.LevelText.text));

            newbutton.transform.SetParent(Spacer, false);
        }
        SaveAll();
    }

    void SaveAll()
    {
        if (PlayerPrefs.HasKey("Level1"))
        {
            return;
        }
        else
        {
            GameObject[] allbuttons = GameObject.FindGameObjectsWithTag("LevelButton");
            foreach (GameObject buttons in allbuttons)
            {
                LevelButton button = buttons.GetComponent<LevelButton>();
                PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
            }
        }
    }

    void DelectAll()
    {
        PlayerPrefs.DeleteAll();
    }

    void loadLevels(string value)
    {
        SceneManager.LoadScene(value);
    }
}
