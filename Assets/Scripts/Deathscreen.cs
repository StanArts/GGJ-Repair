using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    float timeToAppear = 5f;

    // Start is called before the first frame update
    public void LoadMenuScreen()
    {
        StartCoroutine(ScreenAppearance());

        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator ScreenAppearance()
    {
        yield return new WaitForSeconds(timeToAppear);
    }
}
