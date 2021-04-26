using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingObstacles : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private UnityEvent _changeUI;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerStats.Letters--;

        _changeUI.Invoke();
    }
}
