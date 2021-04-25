using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesRandomizer : MonoBehaviour
{
    [SerializeField] GameObject[] _obstaclesInstances;
    [SerializeField] PlayerStats _playerStats;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomizeObjects()
    {
        int randomObjectNumber;

        foreach (GameObject obstacle in _obstaclesInstances)
        {
            if (obstacle.CompareTag("Colectable"))
            {

                randomObjectNumber = Random.Range(0, 100);

                

            }
        }
    }
}
