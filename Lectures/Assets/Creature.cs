using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{

    public int healthPoints = 3;
    public float speed = 3.0f;
    public string creatureName = "Asshole";

    public Transform myTransform;

    // Awake is called before all other Start calls
    void Awake(){
        Debug.Log("Awake Called");
         
        myTransform = GetComponent<Transform>();
    }

    // void OnEnable(){

    // }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Called");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Called");

        myTransform.position += new Vector3(0.1f,0,0);
    }
}
