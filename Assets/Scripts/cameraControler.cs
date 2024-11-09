using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  
    public Vector3 offset;    
    public float smoothSpeed = 0.125f; 

    public float yFixedValue = 5f; 

    void LateUpdate()
    {
        if (player != null)
        {
            
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, yFixedValue, transform.position.z);
            
           
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            
            transform.position = smoothedPosition;
        }
    }
}