using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } 

    public ObjectSpawner objectSpawner;
    public Text levelLabel, ballLabel;
    public int level;
    int previousLevel;
    public int ballCount;
    public Vector3 ballStartPos;
    public bool ballPosFound = false;
    public int activeBallCount;
    public bool ballsLaunched;

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

        level = 1;
        ballCount = 1;
        previousLevel = level;
        ballStartPos = new Vector3(0, -4, 0);
        objectSpawner.NextLevel();
        ballsLaunched = false;
        
    }

    // Update is called once per frame
    void Update()
    {
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

    public void UpdateBallPos(Vector3 pos){
        ballStartPos = pos;
        ballPosFound = true;
        Debug.Log("Ball Pos = " + ballStartPos);
    }
}
