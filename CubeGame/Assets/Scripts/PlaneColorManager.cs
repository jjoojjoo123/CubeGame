using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColorManager : MonoBehaviour {

    public GameObject related_colorChanger;
    private Renderer rend;
    private Material target_material;
    private Color initial_color;

    public float animationTime = 1f;
    public float threshold = 1.5f;

    private bool matched;
    private GameController gameController;

    GameObject ColoredByBallAudio;
    AudioSource coloredByBallAudioData;

    // Use this for initialization
    void Start () {
        //transform.gameObject.tag = "ActivedPlaneSide";
        ColoredByBallAudio = GameObject.Find("coloredByBallAudio");
        coloredByBallAudioData = ColoredByBallAudio.GetComponent<AudioSource>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();

        if (gameController == null)
            Debug.Log("Cannot find 'GameController' script");

        target_material = related_colorChanger.GetComponent<Renderer>().sharedMaterial;

        rend = GetComponent<Renderer>();
        rend.enabled = true;

        Color normal_color = target_material.color;
        initial_color = new Color(
            Mathf.Clamp01(normal_color.r * threshold),
            Mathf.Clamp01(normal_color.g * threshold),
            Mathf.Clamp01(normal_color.b * threshold)
        );
        StartHighlight(initial_color);
    }

    private void StartHighlight(Color color)
    {
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", color,
            "time", animationTime,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.pingPong
        ));
    }

    private void StopHighLight()
    {
        iTween.Stop(gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ColoredSide")
        {
            Material col_material = col.gameObject.GetComponent<Renderer>().sharedMaterial;


            if (col_material == target_material)
            {
                if (!matched)
                {
                    coloredByBallAudioData.Play(0);
                    rend.material = col_material;
                    StopHighLight();
                    matched = true;
                    CheckEndGame();
                }
            }
            else
            {
                //rend.material = col_material;
                StartHighlight(initial_color);
                matched = false;
                gameController.Lose_Game();
            }
        }
    }

    public void CheckEndGame()
    {
        bool finished = true;
        GameObject[] actived_plane_sides = GameObject.FindGameObjectsWithTag("ActivedPlaneSide");
        foreach (GameObject actived_plane_side in actived_plane_sides)
        {
            //Debug.Log(actived_plane_side);
            if (actived_plane_side.GetComponent<PlaneColorManager>().matched == false)
                finished = false;
        }
        if (finished)
            gameController.Win_Game();
    }
}
