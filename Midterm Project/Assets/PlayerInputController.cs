using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("GameOver");
        }
    }

    void FixedUpdate(){
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            player.Move(new Vector3(1, 0 ,0));
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            player.Move(new Vector3(-1, 0, 0));
        }
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (player.transform.position.y <= -2.6)){
            player.Move(new Vector3(0, 1, 0));
        }
        if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (player.transform.position.y >= -4.4)){
            player.Move(new Vector3(0, -1, 0));
        }    
    }
}
