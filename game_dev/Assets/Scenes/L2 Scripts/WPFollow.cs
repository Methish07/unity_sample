using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPFollow : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 1;

    [SerializeField] float speed = 2f;
    // Update is called once per frame
    void Update()
    {
    if (Vector3.Distance(transform.position,waypoints[currentWaypointIndex].transform.position) < 0.1f)
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
    }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed*Time.deltaTime*5);

        
    }
}
