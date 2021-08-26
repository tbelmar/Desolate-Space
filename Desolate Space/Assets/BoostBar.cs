using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBar : MonoBehaviour
{
    public PlayerMovement movementFns;

    // Update is called once per frame
    void Update()
    {
        float boost = movementFns.GetBoostValue();
        float maxBoost = movementFns.GetMaxBoost();

        float barLength = 200 * boost / maxBoost;

        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(barLength, 10);
    }
}
