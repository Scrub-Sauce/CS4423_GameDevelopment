using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stopper : MonoBehaviour

{   
    public GameObject score;
    public Score scoreComponent;
    AudioSource sound;

    void Awake(){
        score = GameObject.FindGameObjectWithTag("Score");
        scoreComponent = score.GetComponent<Score>();
        sound = GetComponent<AudioSource>();
    }

    void Update(){
        // Garbage Collection
        if((this.transform.position.y < -40)){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerCreature>() != null){
            StartCoroutine(endSequence());
        }

        if(other.GetComponent<Laser>() != null){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            scoreComponent.laserFee();
        }
    }        

    IEnumerator endSequence(){
        sound.Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");
           
    }
}

