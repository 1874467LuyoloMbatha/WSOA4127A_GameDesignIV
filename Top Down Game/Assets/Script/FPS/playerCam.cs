using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation; //player orientation  

    float xRotation;
    float yRotation;

    private void Start()
    {
       
    }

    private void Update()
    {
        //Cursor//
        if (Input.GetKeyDown("4")) //Hide//
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown("5")) //Hide//
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


        //get mouse input//
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orientation//
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
