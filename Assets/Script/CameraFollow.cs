using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform player;      

    [Header("Settings")]
    public float smoothSpeed = 5f; 
    public Vector3 offset = new Vector3(0, 0, -10); 

    [Header("Zoom")]
    [Range(1, 20)] 
    public float cameraSize = 2f;  
    
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = cameraSize;
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        cam.orthographicSize = cameraSize;
    }
}
