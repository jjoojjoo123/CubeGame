using UnityEngine;
using System.Collections.Generic;

public class SideTag : MonoBehaviour
{
    [System.Serializable]
    public struct Plane_position_tags
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

    public Plane_position_tags plane_position;
    private CubeMovement cube_movement_script;

    void Start()
    {
        GameObject Cube = GameObject.FindWithTag("Cube");
        cube_movement_script = Cube.GetComponent<CubeMovement>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Cube")
        {
            cube_movement_script.cube_position.face.top = plane_position.face.top;
            cube_movement_script.cube_position.face.bottom = plane_position.face.bottom;
            cube_movement_script.cube_position.face.forward = plane_position.face.forward;
            cube_movement_script.cube_position.face.back = plane_position.face.back;
            cube_movement_script.cube_position.face.left = plane_position.face.left;
            cube_movement_script.cube_position.face.right = plane_position.face.right;
            cube_movement_script.cube_position.side.up = plane_position.side.up;
            cube_movement_script.cube_position.side.down = plane_position.side.down;
            cube_movement_script.cube_position.side.left = plane_position.side.left;
            cube_movement_script.cube_position.side.right = plane_position.side.right;
        }
    }
}