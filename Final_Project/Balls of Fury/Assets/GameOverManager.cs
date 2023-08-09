using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text score;
    public ImageFader image;
    public GameController gameController;

    bool changingScene;

    void Awake(){
        image = GameObject.Find("ImageFader").GetComponent<ImageFader>();
        gameController = GameController.Instance;
        changingScene = false;
    }

    void Update(){
        score.text = "Score: "+ gameController.level.ToString();
    }

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
