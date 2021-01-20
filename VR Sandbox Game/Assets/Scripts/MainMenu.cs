using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void QuitInGameButton()
    {
        Debug.Log("QUIT to main menu!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Application.Quit();
    }
}
