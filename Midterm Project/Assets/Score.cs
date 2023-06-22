using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    Text scoreText;
    public static int scoreValue = 0;

    void Awake(){
        scoreText = GetComponent<Text>();
    }

    void Start(){
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
    }

    public void addCoin(int value){
        scoreValue += value;
    }

    public void laserFee(){
        scoreValue -= 50;
    }
}
