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
        int range;

        foreach (GameObject obstacle in _obstaclesInstances)
        {
            if (obstacle.CompareTag("Colectable"))
            {
                if (_playerStats.HasDog)
                {
                    range = 60;
                }
                else
                {
                    range = 50;
                }
                randomObjectNumber = Random.Range(0, range);

            }
        }
    }
}
