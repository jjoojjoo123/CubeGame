using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireRotation : MonoBehaviour
{
    public float rotatingDuration;
    private CubeMovement cube_movement_script;
    private SideTag[] sideTag_scripts;

    // Use this for initialization
    void Start()
    {
        GameObject Cube = GameObject.FindWithTag("Cube");
        cube_movement_script = Cube.GetComponent<CubeMovement>();

        sideTag_scripts = FindObjectsOfType<SideTag>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && !isRotating && !cube_movement_script.isTumbling && !cube_movement_script.tumbleBack)
        {
            StartCoroutine(Rotate(Vector3.up));
            change_side_tags("D");
        }

        if (Input.GetKey(KeyCode.A) && !isRotating && !cube_movement_script.isTumbling && !cube_movement_script.tumbleBack)
        {
            StartCoroutine(Rotate(Vector3.down));
            change_side_tags("A");
        }

        if (Input.GetKey(KeyCode.W) && !isRotating && !cube_movement_script.isTumbling && !cube_movement_script.tumbleBack)
        {
            StartCoroutine(Rotate(Vector3.left));
            change_side_tags("W");
        }

        if (Input.GetKey(KeyCode.S) && !isRotating && !cube_movement_script.isTumbling && !cube_movement_script.tumbleBack)
        {
            StartCoroutine(Rotate(Vector3.right));
            change_side_tags("S");
        }

        if (Input.GetKey(KeyCode.E) && !isRotating && !cube_movement_script.isTumbling && !cube_movement_script.tumbleBack)
        {
            StartCoroutine(Rotate(Vector3.forward));
            change_side_tags("E");
        }

        if (Input.GetKey(KeyCode.Q) && !isRotating && !cube_movement_script.isTumbling && !cube_movement_script.tumbleBack)
        {
            StartCoroutine(Rotate(Vector3.back));
            change_side_tags("Q");
        }
    }

    public bool isRotating = false;
    IEnumerator Rotate(Vector3 direction)
    {
        isRotating = true;

        var t = 0.0f;
        var speed = -90.0f / rotatingDuration;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, -direction) * startRotation;

        while (t < rotatingDuration)
        {
            t += Time.deltaTime;
            if (t < rotatingDuration)
            {
                transform.RotateAround(transform.position, direction, speed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
            }
        }

        isRotating = false;
    }

    void change_side_tags(string key)
    {
        switch (key)
        {
            case "D":
                foreach (SideTag tag in sideTag_scripts)
                {
                    SideTag t = tag.GetComponent<SideTag>();
                    if (t.plane_position.face.top)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                    }
                    else if (t.plane_position.face.bottom)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                    }
                    else if (t.plane_position.face.forward)
                    {
                        t.plane_position.face.forward = false;
                        t.plane_position.face.right = true;
                    }
                    else if (t.plane_position.face.right)
                    {
                        t.plane_position.face.right = false;
                        t.plane_position.face.back = true;
                    }
                    else if (t.plane_position.face.back)
                    {
                        t.plane_position.face.back = false;
                        t.plane_position.face.left = true;
                    }
                    else if (t.plane_position.face.left)
                    {
                        t.plane_position.face.left = false;
                        t.plane_position.face.forward = true;
                    }
                }
                break;

            case "A":
                foreach (SideTag tag in sideTag_scripts)
                {
                    SideTag t = tag.GetComponent<SideTag>();
                    if (t.plane_position.face.top)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                    }
                    else if (t.plane_position.face.bottom)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                    }
                    else if (t.plane_position.face.forward)
                    {
                        t.plane_position.face.forward = false;
                        t.plane_position.face.left = true;
                    }
                    else if (t.plane_position.face.right)
                    {
                        t.plane_position.face.right = false;
                        t.plane_position.face.forward = true;
                    }
                    else if (t.plane_position.face.back)
                    {
                        t.plane_position.face.back = false;
                        t.plane_position.face.right = true;
                    }
                    else if (t.plane_position.face.left)
                    {
                        t.plane_position.face.left = false;
                        t.plane_position.face.back = true;
                    }
                }
                break;

            case "W":
                foreach (SideTag tag in sideTag_scripts)
                {
                    SideTag t = tag.GetComponent<SideTag>();
                    if (t.plane_position.face.top)
                    {
                        t.plane_position.face.top = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.right = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.left = true;
                            }
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.right = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.left = true;
                            }
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.left = true;
                        }
                        t.plane_position.face.back = true;
                    }
                    else if (t.plane_position.face.bottom)
                    {
                        t.plane_position.face.bottom = false;
                        t.plane_position.face.forward = true;
                    }
                    else if (t.plane_position.face.forward)
                    {
                        t.plane_position.face.forward = false;
                        t.plane_position.face.top = true;
                    }
                    else if (t.plane_position.face.right)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                    }
                    else if (t.plane_position.face.back)
                    {
                        t.plane_position.face.back = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.right = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.left = true;
                            }
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.right = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.left = true;
                            }
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.left = true;
                        }
                        t.plane_position.face.bottom = true;
                    }
                    else if (t.plane_position.face.left)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                    }
                }
                break;

            case "S":
                foreach (SideTag tag in sideTag_scripts)
                {
                    SideTag t = tag.GetComponent<SideTag>();
                    if (t.plane_position.face.top)
                    {
                        t.plane_position.face.top = false;
                        t.plane_position.face.forward = true;
                    }
                    else if (t.plane_position.face.bottom)
                    {
                        t.plane_position.face.bottom = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.right = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.left = true;
                            }
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.right = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.left = true;
                            }
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.left = true;
                        }
                        t.plane_position.face.back = true;
                    }
                    else if (t.plane_position.face.forward)
                    {
                        t.plane_position.face.forward = false;
                        t.plane_position.face.bottom = true;
                    }
                    else if (t.plane_position.face.right)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                    }
                    else if (t.plane_position.face.back)
                    {
                        t.plane_position.face.back = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.right = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.left = true;
                            }
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.right = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.left = true;
                            }
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.left = true;
                        }
                        t.plane_position.face.top = true;
                    }
                    else if (t.plane_position.face.left)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                    }
                }
                break;

            case "E":
                foreach (SideTag tag in sideTag_scripts)
                {
                    SideTag t = tag.GetComponent<SideTag>();
                    if (t.plane_position.face.top)
                    {
                        t.plane_position.face.top = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                        t.plane_position.face.right = true;
                    }
                    else if (t.plane_position.face.bottom)
                    {
                        t.plane_position.face.bottom = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                        t.plane_position.face.left = true;
                    }
                    else if (t.plane_position.face.forward)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                    }
                    else if (t.plane_position.face.right)
                    {
                        t.plane_position.face.right = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                        t.plane_position.face.bottom = true;
                    }
                    else if (t.plane_position.face.back)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                    }
                    else if (t.plane_position.face.left)
                    {
                        t.plane_position.face.left = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                        t.plane_position.face.top = true;
                    }
                }
                break;

            case "Q":
                foreach (SideTag tag in sideTag_scripts)
                {
                    SideTag t = tag.GetComponent<SideTag>();
                    if (t.plane_position.face.top)
                    {
                        t.plane_position.face.top = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        t.plane_position.face.left = true;
                    }
                    else if (t.plane_position.face.bottom)
                    {
                        t.plane_position.face.bottom = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                        t.plane_position.face.right = true;
                    }
                    else if (t.plane_position.face.forward)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                    }
                    else if (t.plane_position.face.right)
                    {
                        t.plane_position.face.right = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                        t.plane_position.face.top = true;
                    }
                    else if (t.plane_position.face.back)
                    {
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.up = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.down = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.up = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.down = true;
                        }
                    }
                    else if (t.plane_position.face.left)
                    {
                        t.plane_position.face.left = false;
                        if (t.plane_position.side.up)
                        {
                            t.plane_position.side.up = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.left = true;
                        }
                        else if (t.plane_position.side.down)
                        {
                            t.plane_position.side.down = false;
                            if (t.plane_position.side.left)
                            {
                                t.plane_position.side.left = false;
                                t.plane_position.side.down = true;
                            }
                            else if (t.plane_position.side.right)
                            {
                                t.plane_position.side.right = false;
                                t.plane_position.side.up = true;
                            }
                            t.plane_position.side.right = true;
                        }
                        else if (t.plane_position.side.left)
                        {
                            t.plane_position.side.left = false;
                            t.plane_position.side.down = true;
                        }
                        else if (t.plane_position.side.right)
                        {
                            t.plane_position.side.right = false;
                            t.plane_position.side.up = true;
                        }
                        t.plane_position.face.bottom = true;
                    }
                }
                break;
        }
    }
}
