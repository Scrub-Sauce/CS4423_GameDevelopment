using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPoolManager : MonoBehaviour
{
    public static BallPoolManager Instance;

    public Ball ballPrefab;
    public int initialPoolSize = 10;
    private List<GameObject> ballPool;

    void Awake(){
        if (Instance == null){
            Instance = this;
            InitializePool();
        }else{
            Destroy(gameObject);
        }
    }

    void InitializePool(){
        ballPool = new List<GameObject>();
        for (int i = 0; i < initialPoolSize; i++){
            GameObject ball = Instantiate(ballPrefab.gameObject);
            ball.SetActive(false);
            ballPool.Add(ball);
        }
    }

    public GameObject GetBall(){
        foreach (var ball in ballPool){
            if (!ball.activeInHierarchy){
                return ball;
            }
        }

        GameObject newBall = Instantiate(ballPrefab.gameObject);
        ballPool.Add(newBall);
        return newBall; 
    }

    public void ReturnBall(GameObject ball){
        ball.SetActive(false);
    }
}
