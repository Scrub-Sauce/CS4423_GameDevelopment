using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stopper : MonoBehaviour

{   
    public GameObject score;
    public Score scoreComponent;

    void Awake(){
        score = GameObject.FindGameObjectWithTag("Score");
        scoreComponent = score.GetComponent<Score>();
    }

    void Update(){

        // Garbage Collection
        if((this.transform.position.y < -8) && !(this.transform.position.x < -9)){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerCreature>() != null){
            StopAllCoroutines();
            SceneManager.LoadScene("GameOver");
        }

        if(other.GetComponent<Laser>() != null){
            Debug.Log("BOOM!");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            scoreComponent.laserFee();
        }
    }
}

