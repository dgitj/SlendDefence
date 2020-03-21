using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goto : MonoBehaviour
{
    public Transform target;
    public GameObject Enemy;
    private Vector3 End;
    public PlayerView playerview;
    public FindSafezone findsafezone;
    public float startTime;
    public float startx;
    public float startz;
    public Vector3 startpos;

    // Adjust the speed for the application.
    public float speed = 1.0f;

    public Vector3 TargetPosition = new Vector3(0, 0, 0);
    public Vector3 InitialTargetPosition = new Vector3(0, 0, 0);

    void Start()
    {
        startTime = Time.time;
        startx = transform.position.x;
        startz = transform.position.z;
        startpos = transform.position;
    }

    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move

        Vector3 targetDirection = TargetPosition - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, TargetPosition) < 0.001f)
        {
            // Swap the position of the cylinder.
            TargetPosition *= -1.0f;
        }
        
    }

   
}
