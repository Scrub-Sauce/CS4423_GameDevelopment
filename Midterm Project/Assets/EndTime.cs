using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndTime : MonoBehaviour
{
    Text time;
    int timeValue;

    void Awake(){
        timeValue = CountWithText.counter;
        time = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        time.text = "Time: " + timeValue.ToString() + " seconds";
    }
}
