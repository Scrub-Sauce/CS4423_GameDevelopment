using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCoin : MonoBehaviour
{   
    AudioSource soundEffect;

    void Awake(){
        soundEffect = GetComponent<AudioSource>();
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
            soundEffect.Play();
        }
    }
}
