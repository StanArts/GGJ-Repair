using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    public GameObject[] targetsObj;
    public Transform[] targets;

    public PathFinding path;

    private bool changeTarget = true;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<PathFinding>();

        targetsObj = GameObject.FindGameObjectsWithTag("Target");

        targets = new Transform[targetsObj.Length];

        for(int i = 0; i < targetsObj.Length; i++)
        {
            targets[i] = targetsObj[i].GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == path.target.position)
        {
            changeTarget = true;
        }

        if (changeTarget)
        {
            FindTarget();

            changeTarget = false;

            path.ClearVisited();
        }
    }

    void FindTarget()
    {
        int randNum = Mathf.FloorToInt(Random.Range(0, targets.Length));

        path.target = targets[randNum];
    }
}
