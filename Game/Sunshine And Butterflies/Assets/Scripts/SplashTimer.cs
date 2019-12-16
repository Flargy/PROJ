using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Main Author: Marcus Lundqvist

public class SplashTimer : MonoBehaviour
{
    [SerializeField] float timeDelayed = 0;

    /// <summary>
    /// Starts the coroutine.
    /// </summary>
    void Start()
    {
        StartCoroutine(SceneDelay());
    }

    /// <summary>
    /// Creates a delay before changing scene.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SceneDelay()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        yield return new WaitForSeconds(timeDelayed);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}
