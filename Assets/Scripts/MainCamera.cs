using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int rotateSpeed = 720;
    [Header("Zoom")]
    public float sensitivity = 1;
    public float speed = 100;

    [Header("Set Dynamically")]
    public static GameObject target;
    float zoom;


    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                zoom = Input.mouseScrollDelta.y * sensitivity * speed * Time.deltaTime;

                if (Input.mouseScrollDelta.y > 0 && transform.position.y > 5)
                    transform.position += (transform.forward * zoom);
                if (Input.mouseScrollDelta.y < 0 && transform.position.y < 10)
                    transform.position += (transform.forward * zoom);
                
            }
            else
            {
                if (Input.mouseScrollDelta.y > 0)
                {
                    transform.RotateAround(target.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
                }
                else
                {
                    transform.RotateAround(target.transform.position, -Vector3.up, rotateSpeed * Time.deltaTime);
                }
            }
        }
    }
}
