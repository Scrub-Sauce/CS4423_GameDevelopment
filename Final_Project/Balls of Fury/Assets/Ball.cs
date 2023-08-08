using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 pressPos;
    Rigidbody2D rb;
    float speed = 10f;
    LineRenderer lineRenderer;
    float lineDistanceMultiplier = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f; 
        lineRenderer.endWidth = 0.05f;   
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pressPos.z = 0;
            
            // Begin line at the ball's position
            lineRenderer.SetPosition(0, transform.position);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPos.z = 0;

            // Calculate direction from press position to current mouse position
            Vector3 dragDirection = (pressPos - currentPos).normalized;

            // Determine line length based on drag distance
            float lineLength = Vector3.Distance(currentPos, pressPos) * (lineDistanceMultiplier);

            // Set the line's end position based on drag direction and length
            lineRenderer.SetPosition(1, transform.position + dragDirection * lineLength);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            releasePos.z = 0;

            Vector3 direction = pressPos - releasePos;
            direction.Normalize();

            rb.velocity = direction * speed;

            // Clear the line on release
            lineRenderer.positionCount = 0;
        }
    }
    
}