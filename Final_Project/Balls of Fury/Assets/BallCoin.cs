using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCoin : MonoBehaviour
{
    GameController gameController;
    int previousLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        previousLevel = gameController.level;
    }

    // Update is called once per frame
    void Update()
    {
        if (previousLevel < gameController.level){
            previousLevel = gameController.level;
            NextLevel();
        }

        if (transform.position.y < -3.60f){
            // gameController.GameOver();
        }
    }

    void NextLevel()
    {
        Vector3 startingPos = transform.position;
        Vector3 targetPos = new Vector3(startingPos.x, (startingPos.y - 0.94f), startingPos.z);
        transform.position = targetPos;
    }

    void OnTriggerEnter2D(Collider2D other){
        GameObject sound = GameObject.FindWithTag("BallSound");
        if (other.gameObject.GetComponent<Ball>() != null){
            gameController.ballCount += 1;
            sound.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}