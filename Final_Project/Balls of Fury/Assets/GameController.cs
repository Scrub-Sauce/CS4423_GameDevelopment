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
        objectSpawner.NextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(previousLevel < level){
            objectSpawner.NextLevel();
            previousLevel = level;
        }
        levelLabel.text = level.ToString();
        ballLabel.text = "x " + ballCount.ToString();
    }
}
