using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.6.12
/// </summary>

public class MovingObstacles : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Transform startPoint, endPoint;

    [SerializeField]
    float changeDirectionDelay;

    private Transform destinationTarget, departTarget;
    private float startTime;
    private float juurneyLength;

    bool isWaiting;

    // Start is called before the first frame update
    void Start()
    {
        departTarget = startPoint;
        destinationTarget = endPoint;

        startTime = Time.time;
        juurneyLength = Vector3.Distance(departTarget.position, destinationTarget.position);

    }

    // Update is called once per frame
    void Update()
    {
        ObjectMoving();
    }

    private void ObjectMoving()
    {
        if(!isWaiting)
        {
            if(Vector3.Distance(transform.position,destinationTarget.position) > 0.01f)
            {
                float distanceCovered = (Time.time - startTime) * speed;
                float fractionOfJourney = distanceCovered / juurneyLength;

                transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractionOfJourney);
            }
            else
            {
                isWaiting = true;
                StartCoroutine(ChangeDelay());
            }
        }
    }

    private void ChangeDestinationDelay()
    {
        if(departTarget == endPoint && destinationTarget == startPoint)
        {
            departTarget = startPoint;
            destinationTarget = endPoint;
        }
        else
        {
            departTarget = endPoint;
            destinationTarget = startPoint;
        }
    }

    IEnumerator ChangeDelay ()
    {
        yield return new WaitForSeconds(changeDirectionDelay);
        ChangeDestinationDelay();
        startTime = Time.time;
        juurneyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
        isWaiting = false;
    }
}
