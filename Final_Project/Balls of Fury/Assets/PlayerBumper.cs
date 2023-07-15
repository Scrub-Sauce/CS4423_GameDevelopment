using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBumper : MonoBehaviour
{

    private float speed = 6.0f;

    private Rigidbody2D rb;
    
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 direction){
        rb.MovePosition(transform.position + (direction * speed * Time.fixedDeltaTime));
    }
}
