using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    GameController gameController;
    public Text counterLabel;

    public int hitCounter;
    int previousLevel;

    [SerializeField] private Gradient colorGradient;
    SpriteRenderer spriteRenderer;
    int maxColorHit = 100;

    void Awake(){
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start(){
        previousLevel = gameController.level;
        hitCounter = Random.Range(gameController.level, ((gameController.level * 2) + 1));
        counterLabel.text = hitCounter.ToString();
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    // Update is called once per frame
    void Update(){
        UpdateColor();

        if (previousLevel < gameController.level){
            previousLevel = gameController.level;
            NextLevel();
        }

        counterLabel.text = hitCounter.ToString();

        if (transform.position.y < -3.8f){
            gameController.GameOver();
        }

        if (hitCounter <= 0){
            Destroy(this.gameObject);
        }
    }

    void NextLevel(){
        Vector3 startingPos = transform.position;
        Vector3 targetPos = new Vector3(startingPos.x, (startingPos.y - 0.94f), startingPos.z);
        transform.position = targetPos;
    }

    void UpdateColor(){
        float colorValue = Mathf.Clamp01((float) hitCounter / maxColorHit);
        Color newColor = colorGradient.Evaluate(colorValue);
        spriteRenderer.color = newColor; 
    }
}
