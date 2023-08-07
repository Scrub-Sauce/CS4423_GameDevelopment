using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public Image image;
    
    public float fadeTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    public void FadeFromBlack(){
        StartCoroutine(FadeFromBlack());

        IEnumerator FadeFromBlack(){
        float timer = 0;
        while(timer < fadeTime){
            timer += Time.deltaTime;
            image.color = new Color(0,0,0, 1 - (timer/fadeTime));
            yield return null;
        }
        image.color = Color.clear;

        yield return null;
        }
    }  

    public void FadeToBlack(){
        StartCoroutine(FadeToBlack());
        IEnumerator FadeToBlack(){
        float timer = 0;
        while(timer < fadeTime){
            timer += Time.deltaTime;
            image.color = new Color(0,0,0,(timer/fadeTime));
            yield return null;
        }
        image.color = Color.clear;

        yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
