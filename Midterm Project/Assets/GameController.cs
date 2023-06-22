using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Singleton")]
    public static GameController instance = null;

    [Header("Config")]
    public int score = 0;

    // Start is called before the first frame update
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }
}
