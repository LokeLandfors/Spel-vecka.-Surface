using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unlimited : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Unlimited";

    public void NewLevel()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
