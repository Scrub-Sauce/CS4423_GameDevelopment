using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public ObjectSpawner objectSpawner;
    public Text levelLabel;
    public int level;
    int previousLevel;

    // Start is called before the first frame update
    void Awake()
    {
        level = 1;
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
    }
}
