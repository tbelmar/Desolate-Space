using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBehavior : MonoBehaviour
{
    public float gameBounds = 250;
    public float outOfBoundsForce = 300;

    private GameObject[] players;

    void Start()
    {
        int i = 0;
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
            i++;

        players = new GameObject[i];
        i = 0;

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            players[i] = player;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject player in players)
        {
            if(IsOutOfBounds(player))
                player.GetComponent<Rigidbody>().AddForce(-1 * outOfBoundsForce * player.transform.position);
        }
    }

    bool IsOutOfBounds(GameObject player)
    {
        return Vector3.Distance(player.transform.position, Vector3.zero) > gameBounds;
    }
}
