using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parkour : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Parkour";

    public void NewLevel()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
