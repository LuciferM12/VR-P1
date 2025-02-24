using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MenuScene() {
        SceneManager.LoadScene("Menu");
    }
    public void GameScene() { 
        SceneManager.LoadScene("ImageTarget");
    }
    public void exit() { 
        Application.Quit();
    }
}
