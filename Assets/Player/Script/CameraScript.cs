using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    //GameObject targetObj;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = targetObject.transform.position;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += targetObject.transform.position - targetPos;
        targetPos = targetObject.transform.position;
        
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
        transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 50f);

        if (Input.GetKey(KeyCode.M))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
