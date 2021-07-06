using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
            Eat(collision.gameObject);
    }

    private void Eat(GameObject food)
    {
        float foodMass = food.GetComponent<Rigidbody>().mass;
        Destroy(food);
    }
}
