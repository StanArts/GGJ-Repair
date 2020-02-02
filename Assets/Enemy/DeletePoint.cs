using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePoint : MonoBehaviour
{
    public PathFinding pf;

    private void Start()
    {
        pf = GameObject.FindGameObjectWithTag("Snake").GetComponent<PathFinding>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Point")
        {
            Vector3 point = collision.transform.position;
            int indx = pf.points.IndexOf(point);

            pf.cantGoNodes.Add(indx);

            if(indx >= 0)
            {
                pf.points[indx] = new Vector3(0, 0, 0);
            }
            Destroy(collision.gameObject);
        }
    }
}
