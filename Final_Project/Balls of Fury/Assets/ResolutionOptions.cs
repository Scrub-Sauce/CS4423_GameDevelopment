using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour
{
    public Dropdown resDropDown;
    public Toggle fullscreenToggle;

    Resolution[] resolutions;

    void Start(){
        resolutions = Screen.resolutions;
        for(int i = 0; i < resolutions.Length; i++){
            string resName = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            resDropDown.options.Add(new Dropdown.OptionData(resName));

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                resDropDown.value = i;
            }
        }
    }

    public void SetResolution() {
        Resolution selectedRes = resolutions[resDropDown.value];
        Screen.SetResolution(selectedRes.width, selectedRes.height, fullscreenToggle.isOn);
    }
}
