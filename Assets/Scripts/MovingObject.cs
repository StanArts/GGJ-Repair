using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public GameObject objectToMove;

    public Transform startPoint;
    public Transform endPoint;

    public float movingSpeed;

    private Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, movingSpeed * Time.deltaTime);

        ChangePosition();
    }

    void ChangePosition()
    {
        if (objectToMove.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
        }

        if (objectToMove.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }
    }
}