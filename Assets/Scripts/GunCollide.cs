using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunCollide : MonoBehaviour
{
    public SnakeDie sd;

    private void Start()
    {
        sd = GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeDie>();
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gun")
        {
            Debug.Log("collision!!!");
            

            sd.KillSnake();
            Wait(3);

            SceneManager.LoadScene("WinScreen");
        }
    }
}
