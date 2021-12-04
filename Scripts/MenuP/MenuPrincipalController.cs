using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("1-2");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
