using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public void MainMenu(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
