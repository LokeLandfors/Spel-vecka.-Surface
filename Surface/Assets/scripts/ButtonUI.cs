using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Drunk";

    public void NewLevel()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
