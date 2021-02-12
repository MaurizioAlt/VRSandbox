using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void selectScene()
    {
        switch (this.gameObject.name) 
        {
            case "Plain"
                SceneManager.LoadScene("");
                break;
            case "Space"
                SceneManager.LoadScene("");
                break;
            case "Forest"
                SceneManager.LoadScene("");
                break;
        }
    }
}
