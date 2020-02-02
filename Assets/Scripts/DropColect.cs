using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropColect : MonoBehaviour
{
    public CollectableCount cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("GM").GetComponent<CollectableCount>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Drop")
        {
            cc.numberOfThings++;

            Destroy(collision.gameObject);
        }
    }
}
