using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    private Rigidbody rb;

    public PlayerFunctions functions;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localScale = functions.GetScaleFromMass(rb.mass);
    }
}
