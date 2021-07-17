using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Cinemachine;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float panOutSpeed = 0.05f;

    private float[] masses = {20f, 50f, 500};
    private OrderedDictionary massToOrthographicSize = new OrderedDictionary() {
        { 20f, 7.5f },
        { 50f, 10f },
        { 500f, 15f }
    };

    private bool changingSize = false;
    private PlayerFunctions playerFns;
    private Rigidbody rb;

    private void Start()
    {
        playerFns = GameObject.Find("Player Functions").GetComponent<PlayerFunctions>();

        rb = GetComponent<Rigidbody>();
        transform.localScale = playerFns.GetScaleFromMass(rb.mass);
        rb.AddTorque(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
    }

    private void Update()
    {
        SetCameraOrthographicSize();
    }
    private void SetCameraOrthographicSize()
    {
        for (int j = massToOrthographicSize.Keys.Count - 1; j >= 0; j--)
        {
            if (!changingSize && rb.mass > (float)masses[j])
            {
                changingSize = true;
                StartCoroutine(PanCameraOut((float)massToOrthographicSize[j]));
            }
        }

    }

    private IEnumerator PanCameraOut(float newOrthographicSize)
    {
        while (vcam.m_Lens.OrthographicSize < newOrthographicSize)
        {
            vcam.m_Lens.OrthographicSize = vcam.m_Lens.OrthographicSize + panOutSpeed;
            yield return new WaitForSeconds(0.05f);
        }
        changingSize = false;
    }
}
