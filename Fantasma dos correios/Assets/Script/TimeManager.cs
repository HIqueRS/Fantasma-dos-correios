using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{

    // [SerializeField] private float _time;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private float _maxTime;
    [SerializeField] private Image _fill;
    [SerializeField] private UnityEvent _timeEnd;
    [SerializeField] private AudioSource _gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        _playerStats.Time = _maxTime;
        _playerStats.Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerStats.Time > 0)
        {
            _playerStats.Time -= Time.deltaTime;
            _playerStats.Points += Time.deltaTime;
        }
        else
        {
            //_playerStats.pause = true;
            Cursor.visible = true;
            //_gameMusic.Stop();
            _timeEnd.Invoke();
            
        }

        _fill.fillAmount = _playerStats.Time / _maxTime;
    }
}
