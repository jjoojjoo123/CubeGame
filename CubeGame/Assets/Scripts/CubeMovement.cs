using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [System.Serializable]
    public struct Cube_position_tags
    {
        public Face_tags face;
        public Side_tags side;
    }

    [System.Serializable]
    public struct Face_tags
    {
        public bool top;
        public bool bottom;
        public bool forward;
        public bool back;
        public bool left;
        public bool right;
    }

    [System.Serializable]
    public struct Side_tags
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
    }

    public Cube_position_tags cube_position;
    public float tumblingDuration = 0.2f;
    bool need_second_step = false;
    Vector3 second_dir;
    Vector3 second_rotAxis_dir;

    GameObject MoveAudio;
    AudioSource moveAudioData;

    GameObject ReboundAudio;
    AudioSource reboundAudioData;

    private EntireRotation entire_rotation_script;

    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;

    void Start()
    {
        upKey = KeyCode.UpArrow;
        downKey = KeyCode.DownArrow;
        leftKey = KeyCode.LeftArrow;
        rightKey = KeyCode.RightArrow;

        GameObject Entire = GameObject.Find("Entire");
        entire_rotation_script = Entire.GetComponent<EntireRotation>();

        MoveAudio = GameObject.Find("moveAudio");
        moveAudioData = MoveAudio.GetComponent<AudioSource>();

        ReboundAudio = GameObject.Find("reboundAudio");
        reboundAudioData = ReboundAudio.GetComponent<AudioSource>();
    }

    void Update()
    {
        var dir = Vector3.zero;
        var rotAxis_dir = Vector3.zero;

        if (cube_position.face.top && !isTumbling && !entire_rotation_script.isRotating && !tumbleBack)
        {
            rotAxis_dir = Vector3.up;

            if (Input.GetKey(upKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.forward;
                if (cube_position.side.up)
                {
                    need_second_step = true;
                    second_dir = Vector3.down;
                    second_rotAxis_dir = Vector3.forward;
                }
            }

            else if (Input.GetKey(downKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.back;
                if (cube_position.side.down)
                {
                    need_second_step = true;
                    second_dir = Vector3.down;
                    second_rotAxis_dir = Vector3.back;
                }
            }

            else if (Input.GetKey(leftKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.left;
                if (cube_position.side.left)
                {
                    need_second_step = true;
                    second_dir = Vector3.down;
                    second_rotAxis_dir = Vector3.left;
                }
            }

            else if (Input.GetKey(rightKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.right;
                if (cube_position.side.right)
                {
                    need_second_step = true;
                    second_dir = Vector3.down;
                    second_rotAxis_dir = Vector3.right;
                }
            }
        }

        else if (cube_position.face.forward && !isTumbling && !entire_rotation_script.isRotating)
        {
            rotAxis_dir = Vector3.back;

            if (Input.GetKey(upKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.up;
                if (cube_position.side.up)
                {
                    need_second_step = true;
                    second_dir = Vector3.forward;
                    second_rotAxis_dir = Vector3.up;
                }
            }

            else if (Input.GetKey(downKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.down;
                if (cube_position.side.down)
                {
                    need_second_step = true;
                    second_dir = Vector3.forward;
                    second_rotAxis_dir = Vector3.down;
                }
            }

            else if (Input.GetKey(leftKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.left;
                if (cube_position.side.left)
                {
                    need_second_step = true;
                    second_dir = Vector3.forward;
                    second_rotAxis_dir = Vector3.left;
                }
            }

            else if (Input.GetKey(rightKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.right;
                if (cube_position.side.right)
                {
                    need_second_step = true;
                    second_dir = Vector3.forward;
                    second_rotAxis_dir = Vector3.right;
                }
            }
        }

        else if (cube_position.face.left && !isTumbling && !entire_rotation_script.isRotating)
        {
            rotAxis_dir = Vector3.left;

            if (Input.GetKey(upKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.up;
                if (cube_position.side.up)
                {
                    need_second_step = true;
                    second_dir = Vector3.right;
                    second_rotAxis_dir = Vector3.up;
                }
            }

            else if (Input.GetKey(downKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.down;
                if (cube_position.side.down)
                {
                    need_second_step = true;
                    second_dir = Vector3.right;
                    second_rotAxis_dir = Vector3.down;
                }
            }

            else if (Input.GetKey(leftKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.forward;
                if (cube_position.side.left)
                {
                    need_second_step = true;
                    second_dir = Vector3.right;
                    second_rotAxis_dir = Vector3.forward;
                }
            }

            else if (Input.GetKey(rightKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.back;
                if (cube_position.side.right)
                {
                    need_second_step = true;
                    second_dir = Vector3.right;
                    second_rotAxis_dir = Vector3.back;
                }
            }
        }

        else if (cube_position.face.back && !isTumbling && !entire_rotation_script.isRotating)
        {
            rotAxis_dir = Vector3.forward;

            if (Input.GetKey(upKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.down;
                if (cube_position.side.down)
                {
                    need_second_step = true;
                    second_dir = Vector3.back;
                    second_rotAxis_dir = Vector3.down;
                }
            }

            else if (Input.GetKey(downKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.up;
                if (cube_position.side.up)
                {
                    need_second_step = true;
                    second_dir = Vector3.back;
                    second_rotAxis_dir = Vector3.up;
                }
            }

            else if (Input.GetKey(leftKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.left;
                if (cube_position.side.right)
                {
                    need_second_step = true;
                    second_dir = Vector3.back;
                    second_rotAxis_dir = Vector3.left;
                }
            }

            else if (Input.GetKey(rightKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.right;
                if (cube_position.side.left)
                {
                    need_second_step = true;
                    second_dir = Vector3.back;
                    second_rotAxis_dir = Vector3.right;
                }
            }
        }

        else if (cube_position.face.right && !isTumbling && !entire_rotation_script.isRotating)
        {
            rotAxis_dir = Vector3.right;

            if (Input.GetKey(upKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.forward;
                if (cube_position.side.right)
                {
                    need_second_step = true;
                    second_dir = Vector3.left;
                    second_rotAxis_dir = Vector3.forward;
                }
            }

            else if (Input.GetKey(downKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.back;
                if (cube_position.side.left)
                {
                    need_second_step = true;
                    second_dir = Vector3.left;
                    second_rotAxis_dir = Vector3.back;
                }
            }

            else if (Input.GetKey(leftKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.up;
                if (cube_position.side.up)
                {
                    need_second_step = true;
                    second_dir = Vector3.left;
                    second_rotAxis_dir = Vector3.up;
                }
            }

            else if (Input.GetKey(rightKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.down;
                if (cube_position.side.down)
                {
                    need_second_step = true;
                    second_dir = Vector3.left;
                    second_rotAxis_dir = Vector3.down;
                }
            }
        }

        if (cube_position.face.bottom && !isTumbling && !entire_rotation_script.isRotating)
        {
            rotAxis_dir = Vector3.down;

            if (Input.GetKey(upKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.back;
                if (cube_position.side.up)
                {
                    need_second_step = true;
                    second_dir = Vector3.up;
                    second_rotAxis_dir = Vector3.back;
                }
            }

            else if (Input.GetKey(downKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.forward;
                if (cube_position.side.down)
                {
                    need_second_step = true;
                    second_dir = Vector3.up;
                    second_rotAxis_dir = Vector3.forward;
                }
            }

            else if (Input.GetKey(leftKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.right;
                if (cube_position.side.right)
                {
                    need_second_step = true;
                    second_dir = Vector3.up;
                    second_rotAxis_dir = Vector3.right;
                }
            }

            else if (Input.GetKey(rightKey))
            {
                moveAudioData.Play(0);
                dir = Vector3.left;
                if (cube_position.side.left)
                {
                    need_second_step = true;
                    second_dir = Vector3.up;
                    second_rotAxis_dir = Vector3.left;
                }
            }
        }

        if (dir != Vector3.zero && !isTumbling && !need_second_step && !entire_rotation_script.isRotating)
            StartCoroutine(Tumble(dir, rotAxis_dir));

        if (dir != Vector3.zero && !isTumbling && need_second_step && !entire_rotation_script.isRotating)
        {
            need_second_step = false;
            StartCoroutine(Tumble_2steps(dir, rotAxis_dir, second_dir, second_rotAxis_dir));
        }
    }

    public bool isTumbling = false;
    public bool tumbleBack = false;
    IEnumerator Tumble(Vector3 direction, Vector3 rotAxisDirection)
    {
        isTumbling = true;

        var rotAxis = Vector3.Cross(rotAxisDirection, direction);
        var pivot = (transform.position + rotAxisDirection * -0.5f) + direction * 0.5f;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        var startPosition = transform.position;
        var endPosition = transform.position + direction;

        var rotSpeed = 90.0f / tumblingDuration;
        var t = 0.0f;
        var duration_t = 0.0f;

        while (t < tumblingDuration && !tumbleBack)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
                transform.position = endPosition;
            }
        }
        duration_t = t;
        isTumbling = false;

        while (t < tumblingDuration && tumbleBack)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                rotSpeed = 90.0f * 30 * duration_t;
                transform.RotateAround(pivot, -rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = startRotation;
                transform.position = startPosition;
            }
        }

        tumbleBack = false;
    }

    IEnumerator Tumble_2steps(Vector3 direction, Vector3 rotAxisDirection, Vector3 second_direction, Vector3 second_rotAxisDirection)
    {
        isTumbling = true;

        var rotAxis = Vector3.Cross(rotAxisDirection, direction);
        var pivot = (transform.position + rotAxisDirection * -0.5f) + direction * 0.5f;

        var init_startPosition = transform.position;
        var init_startRotation = transform.rotation;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        var startPosition = transform.position;
        var endPosition = transform.position + direction;

        var rotSpeed = 90.0f / tumblingDuration;
        var t = 0.0f;

        while (t < tumblingDuration && !tumbleBack)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
                transform.position = endPosition;
            }
        }


        rotAxis = Vector3.Cross(second_rotAxisDirection, second_direction);
        pivot = (transform.position + second_rotAxisDirection * -0.5f) + second_direction * 0.5f;

        startRotation = transform.rotation;
        endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        startPosition = transform.position;
        endPosition = transform.position + second_direction;

        rotSpeed = 90.0f / tumblingDuration;
        t = 0.0f;
        var duration_t = 0.0f;

        while (t < tumblingDuration && !tumbleBack)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
                transform.position = endPosition;
            }
        }

        duration_t = t;
        var rotSpeedBack = 90.0f * 30 * duration_t;
        
        while (t < tumblingDuration && tumbleBack)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, -rotAxis, rotSpeedBack * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = startRotation;
                transform.position = startPosition;
            }
        }

        rotAxis = Vector3.Cross(second_rotAxisDirection, second_direction);
        pivot = (transform.position + second_rotAxisDirection * -0.5f) + second_direction * 0.5f;

        rotSpeed = 90.0f / tumblingDuration;
        t = 0.0f;
        
        while (t < tumblingDuration && tumbleBack)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, -rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = init_startRotation;
                transform.position = init_startPosition;
            }
        }

        tumbleBack = false;
        isTumbling = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            tumbleBack = true;
            reboundAudioData.Play(0);
        }
    }
}

