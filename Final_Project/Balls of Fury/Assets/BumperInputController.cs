using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperInputController : MonoBehaviour
{
    public PlayerBumper bumper;
    public GameController gameController;
    // Start is called before the first frame update

    void FixedUpdate(){
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (bumper.transform.position.x >= -7.75)){
            bumper.Move(new Vector3(-1, 0, 0));
        }

        if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (bumper.transform.position.x <= 7.75)){
            bumper.Move(new Vector3(1, 0, 0));
        }
    }

    void Update(){
        if((Input.GetKeyDown(KeyCode.Space))){
            gameController.level += 1;  
        }
    }
}
