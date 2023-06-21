using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

        // Garbage Collection
        if(this.transform.position.y > 5){
            Destroy(this.gameObject);
        }
    }

    public void ShootLaser(){
        rb.velocity = transform.up * speed;
    }
}
