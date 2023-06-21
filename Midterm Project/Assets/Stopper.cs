using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour

{   
    void Update(){

        // Garbage Collection
        if((this.transform.position.y < -5) && !(this.transform.position.x < -9)){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerCreature>() != null){
            Debug.Log("Stopper Found Creature!");
        }

        if(other.GetComponent<Laser>() != null){
            Debug.Log("BOOM!");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}

