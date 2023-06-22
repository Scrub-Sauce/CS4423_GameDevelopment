using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountWithText : MonoBehaviour
{
    Text clock;
    int counter = 0;

    void Awake(){
        clock = GetComponent<Text>();
        StartCoroutine(CountEverySecond());
    }

    // Update is called once per frame
    void Update()
    {
        // counter += 1;
        // clock.text = counter.ToString();
    }

    IEnumerator CountEverySecond(){
        while(true){
            yield return new WaitForSeconds(1);
            counter += 1;
            clock.text = "Time: " + counter.ToString();
        }
    }
}
