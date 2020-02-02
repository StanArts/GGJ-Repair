using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPoint : MonoBehaviour
{
    public PathFinding pf;

    private void Start()
    {
        pf = GetComponent<PathFinding>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            Vector3 start = collision.transform.position;

            int srtIndx = pf.points.IndexOf(start);

            pf.currentIndex = srtIndx;
        }
    }
}
