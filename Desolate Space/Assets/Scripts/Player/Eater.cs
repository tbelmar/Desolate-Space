using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    private PlayerFunctions playerFns;
    private Rigidbody rb;

    private void Start()
    {
        playerFns = GameObject.Find("Player Functions").GetComponent<PlayerFunctions>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food") && collision.gameObject.GetComponent<FoodFunctions>().IsEdible())
            Eat(collision.gameObject);
    }

    private void Eat(GameObject food)
    {
        float foodMass = food.GetComponent<Rigidbody>().mass;
        Destroy(food);

        float newMass = rb.mass + foodMass;
        rb.mass = newMass;

        transform.localScale = playerFns.GetScaleFromMass(rb.mass);
    }


}
