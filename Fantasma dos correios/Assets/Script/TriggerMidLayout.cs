using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMidLayout : MonoBehaviour
{
    [SerializeField] private MapGenerator _manager;
    [SerializeField] private ObstaclesRandomizer _obstaclesRandomizer;

    private bool _collidedOnce = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_collidedOnce)
        {
            _manager.InstantiateLayout(transform.position);

            _collidedOnce = true;
        }
    }
}
