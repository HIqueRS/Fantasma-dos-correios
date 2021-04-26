using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclesInstances;

    [SerializeField] private PlayerStats _playerStats;

    void Start()
    {
        _playerStats.HasDog = true;
        _playerStats.Letters = 1;
        RandomizeObjects();
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
                        Instantiate(Resources.Load<GameObject>("Bone"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                    }
                    else if(_playerStats.Letters <= 1)
                    {
                        Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                    }
                    else if(_playerStats.Letters == 2)
                    {
                        if(randomObjectNumber >= 50 && randomObjectNumber < 75)
                        {
                            Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                        else if(randomObjectNumber == 75 && randomObjectNumber < 75 + 12)
                        {
                            Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                        else
                        {
                            Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                    }
                    else if(_playerStats.Letters == 3)
                    {
                        if (randomObjectNumber >= 50 && randomObjectNumber < 62)
                        {
                            Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                        else if(randomObjectNumber >= 62 && randomObjectNumber < 81)
                        {
                            Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                        else
                        {
                            Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                    }
                    else if (_playerStats.Letters == 4)
                    {
                        if (randomObjectNumber >= 50 && randomObjectNumber < 56)
                        {
                            Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                        else if (randomObjectNumber >= 56 && randomObjectNumber < 78)
                        {
                            Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                        else
                        {
                            Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                    }
                    else
                    {
                        if (randomObjectNumber >= 50 && randomObjectNumber < 75)
                        {
                            Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                        else
                        {
                            Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                    }
                }
                else
                {
                    switch(_playerStats.Letters)
                    {
                        case 0:

                            if(randomObjectNumber < 75)
                            {
                                Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                            }

                            break;

                        case 1:
                            break;

                        case 2:
                            break;

                        case 3:
                            break;

                        case 4:
                            break;

                        default:
                            break;

                    }
                }

            }
        }
    }
}
