using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMoving : MonoBehaviour
{
    public Transform CameraTransform;
    
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    
    //Y limit
    public float yMaxLimit = 45.0f;
    public float yMinLimit = -45.0f;
    float yRotCounter = 0.0f;

    //X limit
    public float xMaxLimit = 45.0f;
    public float xMinLimit = -45.0f;
    float xRotCounter = 0.0f;
    
    public float xMoveThreshold = 1000.0f;
    public float yMoveThreshold = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get X value and limit it
        xRotCounter += Input.GetAxis("Mouse X") * xMoveThreshold * Time.deltaTime;
        xRotCounter = Mathf.Clamp(xRotCounter, xMinLimit, xMaxLimit);
        
        //Get Y value and limit it
        yRotCounter += Input.GetAxis("Mouse Y") * yMoveThreshold * Time.deltaTime;
        yRotCounter = Mathf.Clamp(yRotCounter, yMinLimit, yMaxLimit);
        //xRotCounter = xRotCounter % 360;//Optional
        //transform.localEulerAngles = new Vector3(-yRotCounter, xRotCounter, 0);
        transform.localEulerAngles = new Vector3(90, xRotCounter, 0);
        CameraTransform.localEulerAngles = new Vector3(-yRotCounter + 90, xRotCounter, 0);
    }
}
