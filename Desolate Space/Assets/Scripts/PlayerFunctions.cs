using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{

    public Vector3 GetScaleFromMass(float mass)
    {
        float scale = Mathf.Sqrt(mass / Mathf.PI);
        return new Vector3(scale, scale, scale);
    }
}
