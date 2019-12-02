using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashTimer : MonoBehaviour
{
    [SerializeField] float timeDelayed = 0;

    void Start()
    {
        StartCoroutine(SceneDelay());
    }

    private IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(timeDelayed);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}
