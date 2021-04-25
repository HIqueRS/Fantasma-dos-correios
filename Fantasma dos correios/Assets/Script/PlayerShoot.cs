using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] _letter;
    [SerializeField] private PlayerStats _playerStats;
    private Vector3 _shootDirection;
    private GameObject _aux;
    private int _letterID;

    [SerializeField] private UnityEvent _changeLetter;

    private void Start()
    {
        _letterID = 3;
        _playerStats.Letters = 5;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_playerStats.Letters > 0)
            {
                _shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                _shootDirection.z = 0;

                _aux = Instantiate(_letter[_letterID % 3], transform.position, Quaternion.identity);
                _aux.GetComponent<LetterBehaviour>().Direction = _shootDirection.normalized;
                _aux.GetComponent<LetterBehaviour>().LetterID = _letterID % 3;

                _playerStats.Letters--;
            }
            
        }
        if(Input.GetMouseButtonDown(1))
        {
            _letterID++;
            _changeLetter.Invoke();
        }
    }
}
