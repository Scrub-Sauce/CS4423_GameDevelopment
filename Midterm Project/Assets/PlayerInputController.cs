using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [Header("References")]
    public PlayerCreature player;

    void Awake(){
        player = GetComponent<PlayerCreature>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            player.RandomizeColor();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            player.ShootLaser();
        }
    }

    void FixedUpdate(){
        if(Input.GetKey(KeyCode.D)){
            player.Move(new Vector3(1, 0 ,0));
        }
        if(Input.GetKey(KeyCode.A)){
            player.Move(new Vector3(-1, 0, 0));
        }
        if(Input.GetKey(KeyCode.W) && (player.transform.position.y <= -2.6)){
            player.Move(new Vector3(0, 1, 0));
        }
        if(Input.GetKey(KeyCode.S) && (player.transform.position.y >= -4.4)){
            player.Move(new Vector3(0, -1, 0));
        }    
    }
}
