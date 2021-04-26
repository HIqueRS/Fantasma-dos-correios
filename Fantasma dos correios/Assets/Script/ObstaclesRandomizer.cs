using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclesInstances;
    [SerializeField] private GameObject[] _obstacles;

    [SerializeField] private PlayerStats _playerStats;

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

                if (_playerStats.HasDog)
                {
                    if(randomObjectNumber < 50)
                    {
                        Instantiate(Resources.Load<GameObject>("Bone"), obstacle.transform);
                    }
                    else if(_playerStats.Letters <= 1)
                    {
                        Instantiate(Resources.Load<GameObject>("Letter"));
                    }
                }

            }
        }
    }
}
