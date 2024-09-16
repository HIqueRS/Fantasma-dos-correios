using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _vel;
    [SerializeField] private PlayerStats _playerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_playerStats.pause)
        {
            _vel = _playerStats.PlayerVelocity;
            transform.position -= new Vector3(0, _vel / 3) * Time.deltaTime;

            //_vel += 0.05f * Time.deltaTime;
        }
        
    }
}
