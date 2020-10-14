using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum CameraState
{
    Default,
    ZoomIn,
    ZoomOut,
    Zoomed
}

public class CameraMoving : MonoBehaviour
{
    private readonly FloatAnimation distanceAnimation = new FloatAnimation();
    
    private const float ZoomDuration = 0.5f;
    private const float ZoomFactor = 2f;
    
    public float HeightDamping = 2.0f;
    public float RotationDamping = 3.0f;
    
    public float Distance = 0.0f;
    
    private CameraState cameraState;

    [FormerlySerializedAs("Player")] public Transform player;
   
    
    private void Update()
    {
        var currentRotationAngle = transform.eulerAngles.y;

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        
        var zoomDistance = Distance;
        
        void SetAnimationState(CameraState state)
        {
            cameraState = state;
            var startDistance = (transform.position - player.transform.position).magnitude;
            var endDistance = cameraState == CameraState.ZoomIn ? zoomDistance / ZoomFactor : zoomDistance;
           distanceAnimation.Start(startDistance,endDistance, ZoomDuration);
        }

        // Check if space is up or down on the frame
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SetAnimationState(CameraState.ZoomOut);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SetAnimationState(CameraState.ZoomIn);
        }
        
        switch (cameraState)
        {
            case CameraState.ZoomIn:
            case CameraState.ZoomOut:
                if (distanceAnimation.Update(Time.deltaTime))
                {
                    cameraState = cameraState == CameraState.ZoomIn ? 
                        CameraState.Zoomed : CameraState.Default;
                }
                zoomDistance = distanceAnimation.Value;
                break;
            case CameraState.Default:
            case CameraState.Zoomed:
                zoomDistance = cameraState == CameraState.Default ? zoomDistance : zoomDistance / ZoomFactor;
                break;
        }
        var newPosition = player.position - currentRotation * Vector3.forward * zoomDistance;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
