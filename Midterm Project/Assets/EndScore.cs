using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    Text score;
    int scoreValue;

    void Awake(){
        scoreValue = Score.scoreValue;
        score = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + scoreValue.ToString();
    }
}
