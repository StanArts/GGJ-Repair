using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    private Vector3Int nextPoint;
    private int xPoint;
    private int yPoint;

    public int maxXPoint;
    public int maxYPoint;

    public GameObject point;

    public GameObject snake;

    public PathFinding pf;

    // Start is called before the first frame update
    void Start()
    {
        pf = snake.GetComponent<PathFinding>();
        pf.width = (maxXPoint * 2) + 1;

        yPoint = maxYPoint * -1;

        while (yPoint <= maxYPoint)
        {
            xPoint = -maxXPoint;

            while(xPoint <= maxXPoint)
            {
                nextPoint = new Vector3Int(xPoint, yPoint, 0);

                pf.points.Add(nextPoint);

                Instantiate(point, nextPoint, transform.rotation);

                xPoint++;


            }

            yPoint++;
        }
    }
}
