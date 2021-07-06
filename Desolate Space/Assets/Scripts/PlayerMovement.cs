using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;

    public float gravityMultiplier = 10;
    public float maxSpeed = 50;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePosInGame = cam.ScreenToWorldPoint(mousePosition);

        Vector3 movement = mousePosInGame - transform.position;
        Vector3 direction = movement.normalized;
        float gravitationalMagnitude = gravityMultiplier / Mathf.Pow(movement.magnitude, 2);

        rb.AddForce(gravitationalMagnitude * direction);
        if(rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * Mathf.Clamp(rb.velocity.magnitude, 0, maxSpeed);
    }
}
