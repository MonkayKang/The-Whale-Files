using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Find Player

    public float smoothRate = 1.5f; // Smooth Player
    public Vector3 offset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // Target Player's Transform
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }


    void LateUpdate() // Fixed Calls once per end frame
    {
        // Center of the screen
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

        // In simpler term, the framerate
        transform.position = Vector3.Lerp(transform.position, targetPos + offset, Time.deltaTime * smoothRate);
    }
}
