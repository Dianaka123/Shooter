using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMoving : MonoBehaviour
{
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    
    public float rotationSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        pitch = Input.GetAxis("Mouse Y") * 10;
        Debug.Log(pitch);
        transform.Rotate(pitch, yaw , 0);
        
    }
}
