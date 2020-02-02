using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTarget : MonoBehaviour
{
    public GameObject dropThing;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Snake")
        {
            Instantiate(dropThing, transform.position, transform.rotation);
        }
    }
}
