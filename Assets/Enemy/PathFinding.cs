using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public int currentIndex;
    public float speed = 5f;

    public Transform target;

    public int[] movablePoints;

    public List<int> vistedNodes;

    public List<int> cantGoNodes;

    public int lastNode;

    public List<Vector3> points;
    public int width;

    private int node;

    private bool nodeChangable = true;

    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindMovePoints();
        if (nodeChangable)
        {
            node = FindPriorityNode(movablePoints);

            nodeChangable = false;
        }

        if (transform.position == points[node] || points[node] == new Vector3(0, 0, 0))
        {
            vistedNodes.Add(node);

            currentIndex = node;

            nodeChangable = true;
        }

        Debug.Log(node);

        //Debug.Log(currentIndex);

        transform.position = Vector3.MoveTowards(transform.position, points[node], speed * Time.deltaTime);
    }

    void FindMovePoints()
    {
        movablePoints[0] = currentIndex - width - 1;
        movablePoints[1] = currentIndex - width;
        movablePoints[2] = currentIndex - width + 1;
        movablePoints[3] = currentIndex - 1;
        movablePoints[4] = currentIndex + 1;
        movablePoints[5] = currentIndex + width - 1;
        movablePoints[6] = currentIndex + width;
        movablePoints[7] = currentIndex + width + 1;
    }

    float FindDist(float x1, float y1, float x2, float y2)
    {
        float xDist = x2 - x1;
        float yDist = y2 - y1;

        float cSquared = (xDist * xDist) + (yDist * yDist);
        float c = Mathf.Sqrt(cSquared);

        return c;
    }

    int FindPriorityNode(int[] node)
    {
        float[] lengths = new float[node.Length];

        for (int i = 0; i < node.Length; i++)
        {
            lengths[i] = FindDist(points[node[i]].x, points[node[i]].y, target.position.x, target.position.y);

            Debug.Log("Point " + i + "is: " + lengths[i]);
        }

        float smallest = lengths[0];

        int indx = 0;
        for (int i = 0; i < lengths.Length; i++)
        {
            Debug.Log("Point " + i + points[node[i]]);
            if(points[node[i]] != new Vector3(0, 0, 0))
            {
                bool canNode = true;

                for(int j = 0; j < vistedNodes.Count; j++)
                {
                    if (node[i] == vistedNodes[j])
                    {
                        canNode = false;
                    }
                }


                Debug.Log("THIS SHOULD DEFINATELY NOT BE HERE IF VECTOR = 0!!!!!!");
                if (lengths[i] < smallest && canNode)
                {
                    smallest = lengths[i];

                    indx = i;
                }

            }
        }

        
        if (points[node[indx]] == new Vector3(0, 0, 0))
        {
            indx = 0;

            while(points[node[indx]] == new Vector3(0, 0, 0))
            {
                indx++;
            }
        }
        
        /*
        if(node[indx] == 347)
        {
            indx = 0;
        }
        */

        Debug.Log(smallest);

        return node[indx];
    }

    public void ClearVisited()
    {
        vistedNodes.Clear();
    }
}
