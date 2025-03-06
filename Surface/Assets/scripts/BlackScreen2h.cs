using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackScreen2h : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(fadeImage());
    }

    private IEnumerator fadeImage()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }
}
