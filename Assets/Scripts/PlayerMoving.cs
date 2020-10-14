using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMoving : MonoBehaviour
{
    [FormerlySerializedAs("Speed")] 
    public float speed = 10;

    public float rotationSpeed = 100.0f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
 
        var movement = new Vector3(moveHorizontal, 0, moveVertical );
 
        movement = movement * speed * Time.deltaTime;
 
        transform.Translate(movement);
    }
}
