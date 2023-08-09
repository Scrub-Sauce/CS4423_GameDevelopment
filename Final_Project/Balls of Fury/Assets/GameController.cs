using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } 

    public ImageFader image;
    public ObjectSpawner objectSpawner;
    public Text levelLabel, ballLabel;
    public int level;
    int previousLevel;
    public int ballCount;
    public Vector3 ballStartPos;
    public bool ballPosFound = false;
    public int activeBallCount;
    public bool ballsLaunched;
    bool changingScene = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
            return;  
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space))){
            level += 1;  
        }
        activeBallCount = GameObject.FindGameObjectsWithTag("Ball").Length;
        if (activeBallCount == 0 && ballsLaunched && ballPosFound){
            level++;
        }

        if(previousLevel < level){
            objectSpawner.NextLevel();
            ballsLaunched = false;
            ballPosFound = false;
            previousLevel = level;
        }
        levelLabel.text = level.ToString();
        ballLabel.text = "x " + ballCount.ToString();
    }

    public void GameOver(){
        if (changingScene){
            return;
        }
        changingScene = true;

        StartCoroutine(ChangeSceneRoutine());
        IEnumerator ChangeSceneRoutine()
        {
            image.FadeToBlack();
            yield return new WaitForSeconds(image.fadeTime);
            SceneManager.LoadScene("GameOver");
            yield return null;
        }
    }

    public void UpdateBallPos(Vector3 pos){
        ballStartPos = pos;
        ballPosFound = true;
    }

    public void ResetGame(){
        image = GameObject.FindGameObjectWithTag("ImageFader").GetComponent<ImageFader>();
        levelLabel = GameObject.FindGameObjectWithTag("Level").GetComponent<Text>();
        ballLabel = GameObject.FindGameObjectWithTag("BallCount").GetComponent<Text>();
        objectSpawner = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<ObjectSpawner>();

        changingScene = false;
        level = 1;
        ballCount = 1;
        previousLevel = level;
        ballStartPos = new Vector3(0, -4.35f, 0);
        objectSpawner.NextLevel();
        ballsLaunched = false;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            ResetGame();
        }
    }
    
}
