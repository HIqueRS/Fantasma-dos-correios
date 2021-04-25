using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    // [SerializeField] private float _time;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private float _maxTime;
    [SerializeField] private Image _fill;

    // Start is called before the first frame update
    void Start()
    {
        _playerStats.Time = _maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerStats.Time > 0)
        {
            _playerStats.Time -= Time.deltaTime;
        }

        _fill.fillAmount = _playerStats.Time / _maxTime;
    }
}
