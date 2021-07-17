using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFunctions : MonoBehaviour
{
    public float gracePeriod = 1f;

    private float timeElapsed = 0f;

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed < gracePeriod)
            timeElapsed += Time.deltaTime;
    }

    public bool IsEdible()
    {
        return timeElapsed > gracePeriod;
    }
}
