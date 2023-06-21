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
    // Start is called before the first frame update
    void Start()
    {
        clock.text = "1";
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
            clock.text = counter.ToString();
        }
    }
}
