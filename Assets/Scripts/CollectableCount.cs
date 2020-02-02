using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCount : MonoBehaviour
{
    public int numberOfThings;
    public int maxPieces = 4;

    public GameObject gun;

    public GameObject gunColl;

    // Start is called before the first frame update
    void Start()
    {
        numberOfThings = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfThings >= maxPieces)
        {
            gun.SetActive(true);

            gunColl.SetActive(true);
        }
    }
}
