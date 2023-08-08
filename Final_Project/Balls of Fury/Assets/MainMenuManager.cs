using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public ImageFader image;

    bool changingScene = false;
    public void LoadScene(string sceneName){
        if (changingScene){
            return;
        }
        changingScene = true;

        StartCoroutine(ChangeSceneRoutine());
        IEnumerator ChangeSceneRoutine()
        {
            image.FadeToBlack();
            yield return new WaitForSeconds(image.fadeTime);
            SceneManager.LoadScene(sceneName);
            yield return null;
        }
    }
        

    public void Quit(){
        Application.Quit();
    }
}
