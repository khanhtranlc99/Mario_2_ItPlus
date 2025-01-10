using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private struct PointInSpace
    {
        public Vector3 Position;
        public float Time;
    }

    [SerializeField]
    public Transform target;
    [SerializeField]
    public Vector3 offset;


    [SerializeField]
    private float delay = 0.5f;

    [SerializeField]

    private float speed = 5;

    private Queue<PointInSpace> pointsInSpace = new Queue<PointInSpace>();

    void FixedUpdate()
    {
        // Add the current target position to the list of positions
        pointsInSpace.Enqueue(new PointInSpace() { Position = new Vector2(target.transform.position.x, target.transform.position.y), Time = Time.time });
        // Move the camera to the position of the target X seconds ago 
        while (pointsInSpace.Count > 0 && pointsInSpace.Peek().Time <= Time.time - delay + Mathf.Epsilon)
        {
            transform.position = Vector3.Lerp(transform.position, pointsInSpace.Dequeue().Position + offset, Time.deltaTime * speed);
            transform.localScale = new Vector3(target.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        }
        if (transform.localScale.x == -1 )
        {
            offset.x = -1;
        }
        if (transform.localScale.x == 1 )
        {
            offset.x = 1;
        }



    }

}
