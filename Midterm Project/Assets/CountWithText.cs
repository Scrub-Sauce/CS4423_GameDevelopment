using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountWithText : MonoBehaviour
{
    Text clock;
    public static int counter = 0;

    void Awake(){
        clock = GetComponent<Text>();
        StartCoroutine(CountEverySecond());
    }

    void Start(){
        counter = 0;
    }

    IEnumerator CountEverySecond(){
        while(true){
            yield return new WaitForSeconds(1);
            counter += 1;
            clock.text = "Time: " + counter.ToString();
        }
    }
}
