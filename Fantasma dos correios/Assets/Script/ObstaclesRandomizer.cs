using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclesInstances;

    [SerializeField] private PlayerStats _playerStats;

    private bool _clockInstantiated;
    private bool _letterInstantiated;

    void Start()
    {

        _clockInstantiated = false;
        _letterInstantiated = false;

        RandomizeObjects();
    }

    private void RandomizeObjects()
    {
        int randomObjectNumber;

        foreach (GameObject obstacle in _obstaclesInstances)
        {

            randomObjectNumber = Random.Range(0, 100);

            if (obstacle.CompareTag("Colectable"))
            {

                if (_playerStats.Time < 40  && !_clockInstantiated)
                {
                    Instantiate(Resources.Load<GameObject>("Clock"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                    //Debug.Log("Vai relogio");

                    _clockInstantiated = true;
                }
                else
                {
                    if (!_letterInstantiated)
                    {
                        switch (_playerStats.Letters)
                        {
                            case 0:

                                if (randomObjectNumber < 75)
                                {
                                    Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                    _letterInstantiated = true;
                                }
                                else if (randomObjectNumber >= 75 && randomObjectNumber < 75 + 12)
                                {
                                    Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }
                                else
                                {
                                    Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }

                                break;

                            case 1:

                                if (randomObjectNumber < 50)
                                {
                                    Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                    _letterInstantiated = true;
                                }
                                else if (randomObjectNumber >= 50 && randomObjectNumber < 75)
                                {
                                    Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }
                                else
                                {
                                    Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }

                                break;

                            case 2:

                                if (randomObjectNumber < 25)
                                {
                                    Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                    _letterInstantiated = true;
                                }
                                else if (randomObjectNumber >= 25 && randomObjectNumber < 62)
                                {
                                    Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }
                                else
                                {
                                    Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }

                                break;

                            case 3:

                                if (randomObjectNumber < 12)
                                {
                                    Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                    _letterInstantiated = true;
                                }
                                else if (randomObjectNumber >= 12 && randomObjectNumber < 56)
                                {
                                    Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }
                                else
                                {
                                    Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }

                                break;

                            case 4:

                                if (randomObjectNumber < 6)
                                {
                                    Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                    _letterInstantiated = true;
                                }
                                else if (randomObjectNumber >= 6 && randomObjectNumber < 53)
                                {
                                    Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }
                                else
                                {
                                    Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }

                                break;

                            default:

                                if (randomObjectNumber < 50)
                                {
                                    Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }
                                else
                                {
                                    Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                                }

                                break;

                        }
                    }
                    else
                    {
                        if (randomObjectNumber < 50)
                        {
                            Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                        else
                        {
                            Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                        }
                    }
                    
                }

            }
            else
            {
                if(randomObjectNumber < 30)
                {
                    Instantiate(Resources.Load<GameObject>("Skull"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                }
                else if(randomObjectNumber >= 30 && randomObjectNumber < 50)
                {
                    Instantiate(Resources.Load<GameObject>("Spider"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                }
                else if (randomObjectNumber >= 50 && randomObjectNumber < 70)
                {
                    Instantiate(Resources.Load<GameObject>("Bat"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                }
                else
                {
                    Instantiate(Resources.Load<GameObject>("Tomb"), obstacle.transform.position, Quaternion.identity, obstacle.transform);
                }
            }
        }
    }
}
