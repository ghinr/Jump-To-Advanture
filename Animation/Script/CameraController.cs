using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = -2f;
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
}