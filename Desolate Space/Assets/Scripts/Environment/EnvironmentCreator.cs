using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCreator : MonoBehaviour
{
    public int numberOfLocations = 100;
    public float timeBetweenPlanets = 1f;
    public float[] scaleVariation = { 1, 10 };

    public GameObject shatteredPlanet;

    public Bounds boundsObj;
    public GameManager gameManager;
    public PlayerFunctions playerFns;

    private float bounds;

    // Start is called before the first frame update
    void Start()
    {
        bounds = boundsObj.bounds;
        PlaceShatteredPlanets(numberOfLocations, bounds, scaleVariation);
    }

    private void PlaceShatteredPlanets(int numberOfLocations, float bounds, float[] scaleVariation)
    {
        bounds -= scaleVariation[1];

        StartCoroutine(CreateShatteredPlanets(numberOfLocations, bounds, scaleVariation));
        // Two shattered planets are spawned at each random location
    }

    private IEnumerator CreateShatteredPlanets(int numberOfLocations, float bounds, float[] scaleVariation)
    {
        yield return new WaitForSeconds(timeBetweenPlanets);

        if (numberOfLocations > 0) {
            GameObject[] planets = { Instantiate(shatteredPlanet), Instantiate(shatteredPlanet) };

            int[] pos = { (int)Random.Range(-bounds, bounds), (int)Random.Range(-bounds, bounds) };

            foreach (GameObject planet in planets)
            {
                float scale = Random.Range(scaleVariation[0], scaleVariation[1]);

                planet.transform.position = new Vector3(pos[0], pos[1], 10);
                planet.transform.localScale = new Vector3(scale, scale, scale);
                foreach(Rigidbody foodRb in planet.GetComponentsInChildren<Rigidbody>())
                {
                    foodRb.mass = playerFns.GetMassFromScale(scale) / 60;
                }
            }

            StartCoroutine(CreateShatteredPlanets(numberOfLocations-1, bounds, scaleVariation));
        }
    }
}
