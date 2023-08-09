using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public void OpenOptionsMenu(){
        GetComponent<Canvas>().enabled = true;
    }

    public void CloseOptionsMenu(){
        GetComponent<Canvas>().enabled = false;
    }
}
