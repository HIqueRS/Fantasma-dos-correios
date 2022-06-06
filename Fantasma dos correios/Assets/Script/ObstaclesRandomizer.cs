using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclesInstances;

    [SerializeField] private PlayerStats _playerStats;

    private bool _boneInstantiated;
    private bool _letterInstantiated;

    void Start()
    {
        _boneInstantiated = false;
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
                if (_playerStats.HasDog && !_boneInstantiated)
                {
                    
                    Instantiate(Resources.Load<GameObject>("Bone"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                    _boneInstantiated = true;
                }
                else if (!_letterInstantiated)
                {
                    switch (_playerStats.Letters)
                    {
                        case 0:
                            
                            Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                            _letterInstantiated = true;
                            
                            break;

                        case 1:

                            if (randomObjectNumber < 90)
                            {
                                Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                _letterInstantiated = true;
                            }

                            break;

                        case 2:

                            if (randomObjectNumber < 75)
                            {
                                Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                _letterInstantiated = true;
                            }

                            break;

                        case 3:

                            if (randomObjectNumber < 60)
                            {
                                Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                _letterInstantiated = true;
                            }
                            break;

                        case 4:

                            if (randomObjectNumber < 40)
                            {
                                Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                _letterInstantiated = true;
                            }

                            break;

                        case 5:

                            if (randomObjectNumber < 15)
                            {
                                Instantiate(Resources.Load<GameObject>("Letter"), obstacle.transform.position, Quaternion.identity, obstacle.transform);

                                _letterInstantiated = true;
                            }

                            break;

                        default:

                            break;

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
