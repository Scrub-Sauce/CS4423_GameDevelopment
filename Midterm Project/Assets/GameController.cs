using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Singleton")]
    public static GameController instance = null;

    [Header("Config")]
    public int score = 0;

    public int coins = 0;
    public int superCoins = 0;

    public int standardHor = 0;
    public int mediumHor = 0;
    public int largeHor = 0;

    public int standardVert = 0;
    public int mediumVert = 0;
    public int largeVert = 0;

    // Start is called before the first frame update
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }
}
