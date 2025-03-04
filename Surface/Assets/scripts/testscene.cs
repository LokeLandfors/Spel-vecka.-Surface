using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testscene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(fadeImage());
    }

    private IEnumerator fadeImage()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
