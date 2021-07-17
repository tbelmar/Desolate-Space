using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float g = 100;
    public float foodMultiplier = 30f;

    private Transform transformParent;
    private Rigidbody rbParent;

    private void Start()
    {
        transformParent = GetComponentInParent<Transform>();
        rbParent = GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        bool isFood = false;

        if (other.CompareTag("Food"))
            isFood = true;

        if (!other.CompareTag("Player") && !isFood)
            return;

        Rigidbody rbOther = other.GetComponent<Rigidbody>();

        Vector3 movement = transformParent.position - other.transform.position;
        Vector3 direction = movement.normalized;

        float gravitationalMagnitude = g * rbOther.mass * rbParent.mass / Mathf.Pow(movement.magnitude, 2);
        if (isFood)
            gravitationalMagnitude *= foodMultiplier;

        float minDistance = (transformParent.localScale.x / 2f) + (other.transform.localScale.x / 2f);
        minDistance += minDistance * 0.05f;

        if(movement.magnitude > minDistance || isFood)
            rbOther.AddForce(gravitationalMagnitude * direction);
    }
}
