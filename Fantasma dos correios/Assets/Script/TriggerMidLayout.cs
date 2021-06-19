using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMidLayout : MonoBehaviour
{
    [SerializeField] private MapGenerator _manager;
    [SerializeField] private ObstaclesRandomizer _obstaclesRandomizer;
    [SerializeField] private GameObject _player;

    private bool _collidedOnce = false;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Target");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_collidedOnce)
        {
            _collidedOnce = true;
            _player. GetComponent<AgentGhost>().SetModel(_manager.InstantiateLayout(transform.position));

            
        }
    }
}
