using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isActive = true;

    public float boostMultiplier = 10f;

    public float maxSpeed = 50;
    public float maxAcceleration = 75;

    public Camera cam;

    private float maxBoost = 200;
    private float boost;
    private float gravityMultiplier = 10;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boost = maxBoost;
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

        if(Input.GetKey(KeyCode.Space) && boost > 0)
        {
            gravitationalMagnitude *= boostMultiplier;
            boost--;
        }

        if (Input.GetKey(KeyCode.Return)) AddToBoost(1);

        if(rb.velocity.magnitude <= maxSpeed && accelerationMagnitude <= maxAcceleration)
            rb.AddForce(gravitationalMagnitude * direction);
        
        rb.velocity = rb.velocity.normalized * Mathf.Clamp(rb.velocity.magnitude, 0, maxSpeed);
    }

    public void AddToBoost(float add) => boost = boost >= maxBoost ? boost : boost + add;

    public float GetBoostValue() => boost;

    public float GetMaxBoost() => maxBoost;

}
