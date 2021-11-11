using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoColorPlane : MonoBehaviour
{

    private GameController gameController;
    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();

        if (gameController == null)
            Debug.Log("Cannot find 'GameController' script");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ColoredSide")
            gameController.Lose_Game();
    }
}

