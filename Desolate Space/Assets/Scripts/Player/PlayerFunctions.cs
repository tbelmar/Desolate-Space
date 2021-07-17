using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    public GameObject shatteredPlanet;

    public Vector3 GetScaleFromMass(float mass)
    {
        // Calculates radius of a planet assuming mass is area
        float scale = Mathf.Sqrt(mass / Mathf.PI);
        return new Vector3(scale, scale, scale);
    }

    public float GetMassFromScale(float scale)
    {
        float mass = Mathf.PI * Mathf.Pow(scale, 2);
        return mass;
    }

    public void SpawnShatteredPlanet(Transform planetTransform, float planetMass)
    {
        GameObject sp = Instantiate(shatteredPlanet);
        sp.transform.position = planetTransform.position;
        sp.transform.localScale = planetTransform.localScale;

        Rigidbody[] fragmentRbs = sp.GetComponentsInChildren<Rigidbody>();
        FoodFunctions[] fragmentFns = sp.GetComponentsInChildren<FoodFunctions>();

        for(int i = 0; i < fragmentRbs.Length; i++)
        {
            fragmentRbs[i].mass = planetMass / 60;
            fragmentFns[i].gracePeriod = Random.Range(0f, 0.5f);
        }
    }
}
