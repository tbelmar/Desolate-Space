using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public float bounds = 250;
    public float magnitude = 1000;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            SendObjectBackToBounds(player);   
        }
    }

    private void SendObjectBackToBounds(GameObject obj)
    {
        if (obj.transform.position.magnitude > bounds)
        {
            obj.GetComponent<Rigidbody>().AddForce(-magnitude * obj.transform.position);
        }
    }
}
