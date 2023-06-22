using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void Play(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void Quit(){
        Application.Quit();
    }
}
