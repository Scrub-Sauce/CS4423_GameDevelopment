using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    GameController gameController;
    public Text counterLabel;

    int hitCounter;
    int previousLevel;

    [SerializeField] private Gradient colorGradient;
    SpriteRenderer spriteRenderer;
    int maxColorHit = 500;

    // Start is called before the first frame update
    void Start(){
        gameController = FindObjectOfType<GameController>();
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

        if (transform.position.y < -3.38f){
            // gameController.GameOver();
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

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball")){
            this.hitCounter -= 1;
        }
    }
}
