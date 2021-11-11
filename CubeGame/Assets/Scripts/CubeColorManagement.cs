using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorManagement : MonoBehaviour 
{
    public Material material;
    Renderer rend;

    GameObject PaintFloorAudio;
    AudioSource paintFloorAudioData;

    // Use this for initialization
    void Start () 
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.material = material;

        PaintFloorAudio = GameObject.Find("paintFloorAudio");
        paintFloorAudioData = PaintFloorAudio.GetComponent<AudioSource>();
    }
	

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "CubeColorChanger")
        {
            paintFloorAudioData.Play(0);
            rend.sharedMaterial = col.gameObject.GetComponent<Renderer>().sharedMaterial;
            transform.gameObject.tag = "ColoredSide";
        }
    }
}
