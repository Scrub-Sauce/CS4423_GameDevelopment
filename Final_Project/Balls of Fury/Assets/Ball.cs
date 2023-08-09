using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameController gameController;
    Vector3 pressPos;
    Rigidbody2D rb;
    float speed = 10f;
    LineRenderer lineRenderer;
    float lineDistanceMultiplier = 3f;
    public GameObject ballPrefab;

    void Awake(){
        gameController = GameController.Instance;
    }
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f; 
        lineRenderer.endWidth = 0.05f;   
    }

    void ReflectBall(Vector2 normal){
        rb.velocity = Vector2.Reflect(rb.velocity, normal);
    }

    void HandleInput()
    {
        if(!gameController.ballsLaunched){
            if (Input.GetMouseButtonDown(0)){
                pressPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pressPos.z = 0;
                lineRenderer.SetPosition(0, transform.position);
            }

            if (Input.GetMouseButton(0)){
                Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentPos.z = 0;
                Vector3 dragDirection = (pressPos - currentPos).normalized;
                float lineLength = Vector3.Distance(currentPos, pressPos) * (lineDistanceMultiplier);
                lineRenderer.SetPosition(1, transform.position + dragDirection * lineLength);
            }

            if (Input.GetMouseButtonUp(0)){
                Vector3 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                releasePos.z = 0;
                Vector3 direction = pressPos - releasePos;
                direction.Normalize();
                gameController.ballsLaunched = true;
                rb.velocity = direction * speed;
                rb.gravityScale = 0.01f;
                StartCoroutine(LaunchAfterDelay(0.1f, direction));
                lineRenderer.positionCount = 0;
            }
        }  
    }

    void OnCollisionEnter2D(Collision2D collision){

        this.gameObject.GetComponent<AudioSource>().Play();
        if (collision.gameObject.CompareTag("Box")){
            Box boxComponent = collision.gameObject.GetComponent<Box>();
            boxComponent.hitCounter -= 1;
        }
    }

    void Update(){
        HandleInput();
        if (transform.position.y <= -5.0f){
            rb.velocity = Vector2.zero; 
            if (!gameController.ballPosFound){
                gameController.UpdateBallPos(new Vector3(transform.position.x, -4.35f, 0));
            }else{
                Destroy(this.gameObject);
            }
        }

        if(this.transform.position.y > 6.0f || this.transform.position.x > 10.0f || this.transform.position.x < -10.0f){
            Destroy(this.gameObject);
        }
    }

    IEnumerator LaunchBalls(Vector3 direction){
        for (int i = 0; i < gameController.ballCount -1; i++)
        {
            GameObject newBall = Instantiate(ballPrefab, gameController.ballStartPos, Quaternion.identity);
            Rigidbody2D newRB = newBall.GetComponent<Rigidbody2D>();
            newRB.gravityScale = 0.01f;
            newRB.velocity = direction * speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator LaunchAfterDelay(float seconds, Vector3 direction){
        yield return new WaitForSeconds(seconds);
        StartCoroutine(LaunchBalls(direction));
    }
}