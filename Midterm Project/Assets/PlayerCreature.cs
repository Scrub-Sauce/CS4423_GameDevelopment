using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreature : MonoBehaviour
{
    [Header("Config")]
    public float speed = 2.0f;

    [Header("Projectiles")]
    public GameObject laserPrefab;

    [Header("References")]
    public SpriteRenderer sr;
    private Rigidbody2D rb;

    void Awake(){
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 direction){
        rb.MovePosition(transform.position + (direction * speed * Time.fixedDeltaTime));
    }

    public void RandomizeColor(){
        sr.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void ShootLaser(){
        GameObject newLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        newLaser.GetComponent<Laser>().ShootLaser();
    }
}
