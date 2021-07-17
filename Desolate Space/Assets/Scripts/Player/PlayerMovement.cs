using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isActive = true;

    public float maxSpeed = 50;
    public float maxAcceleration = 75;

    public Camera cam;

    private float gravityMultiplier = 10;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        gravityMultiplier = -0.00374f * Mathf.Pow(rb.mass, 2) + 1.84f * rb.mass + 8.164f;
        if (!isActive)
            return;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePosInGame = cam.ScreenToWorldPoint(mousePosition);

        Vector2 movement = (Vector2)(mousePosInGame - transform.position);
        Vector2 direction = movement.normalized;
        float gravitationalMagnitude = gravityMultiplier / movement.magnitude;
        float accelerationMagnitude = gravitationalMagnitude / rb.mass;

        if(rb.velocity.magnitude <= maxSpeed && accelerationMagnitude <= maxAcceleration)
            rb.AddForce(gravitationalMagnitude * direction);
        
        rb.velocity = rb.velocity.normalized * Mathf.Clamp(rb.velocity.magnitude, 0, maxSpeed);
    }
}
