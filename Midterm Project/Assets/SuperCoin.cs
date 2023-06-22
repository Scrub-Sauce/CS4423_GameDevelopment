using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCoin : MonoBehaviour
{   
    public int value = 300;

    public GameObject score;
    public Score scoreComponent;

    void Awake(){
        score = GameObject.FindGameObjectWithTag("Score");
        scoreComponent = score.GetComponent<Score>();
    }

    void Update(){

        // Garbage Collection
        if((this.transform.position.y < -5) && !(this.transform.position.x < -9)){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerCreature>() != null){
            Debug.Log("Coin Found Creature!");
            Destroy(this.gameObject);
            scoreComponent.addCoin(value);
        }
    }
}
