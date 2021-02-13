using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectScript : MonoBehaviour
{
    public void selectScene()
    {
        switch (this.gameObject.name) 
        {
            case "Plain":
                SceneManager.LoadScene("Plain");
                break;
            case "Space":
                SceneManager.LoadScene("Space");
                break;
            case "Forest":
                SceneManager.LoadScene("Forest");
                break;
        }
    }
}
