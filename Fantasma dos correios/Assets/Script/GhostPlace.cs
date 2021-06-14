using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlace : MonoBehaviour
{
    [SerializeField] private GameObject[] _ghostPlace;

    [SerializeField] private PlayerStats _playerStats;

    private int _leftOrRight; //0 or 1

    private Vector3[] _ghostPlacePosition;

    // Start is called before the first frame update
    void Start()
    {
        _ghostPlacePosition = new Vector3[2];

        _ghostPlacePosition[0].x = _ghostPlace[0].transform.position.x;
        _ghostPlacePosition[0].y = _ghostPlace[0].transform.position.y;
        _ghostPlacePosition[0].z = _ghostPlace[0].transform.position.z;

        _ghostPlacePosition[1].x = _ghostPlace[1].transform.position.x;
        _ghostPlacePosition[1].y = _ghostPlace[1].transform.position.y;
        _ghostPlacePosition[1].z = _ghostPlace[1].transform.position.z;


        DefineIfHasGhost();
    }

    private void DefineIfHasGhost()
    {
        _leftOrRight = Random.Range(0, 2);
    
        if(_leftOrRight == 0)
        {
            Instantiate(Resources.Load<GameObject>("LeftHouse"), _ghostPlacePosition[0], Quaternion.identity, _ghostPlace[0].transform);
    
            Instantiate(Resources.Load<GameObject>("RightWall"), _ghostPlacePosition[1], Quaternion.identity, _ghostPlace[1].transform);
        }
        else
        {
            Instantiate(Resources.Load<GameObject>("RightHouse"), _ghostPlacePosition[1], Quaternion.identity, _ghostPlace[1].transform);
    
            Instantiate(Resources.Load<GameObject>("LeftWall"), _ghostPlacePosition[0], Quaternion.identity, _ghostPlace[0].transform);
        }
    }
}
