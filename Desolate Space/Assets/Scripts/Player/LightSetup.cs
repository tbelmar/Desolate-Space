using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSetup : MonoBehaviour
{
    public GameObject playerBody;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = playerBody.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)playerBody.transform.position;
        float lightIntensity = 2.25f*5f * rb.mass + 12.5f*5f;
        GetComponent<Light>().intensity = lightIntensity < 32.5f ? 32.5f : lightIntensity;
    }
}
