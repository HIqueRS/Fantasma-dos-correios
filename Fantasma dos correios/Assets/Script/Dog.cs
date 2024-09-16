using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private Vector2 _closer;
    private Vector3 _dir;
    private float _distanceMin;
    private float _aux;
    private GameObject[] _targets;

    public bool Got;

    [SerializeField] public float _velocity;
    [SerializeField] private float _dogVelocity;
    [SerializeField] public PlayerStats _playerStats;


    void Start()
    {
        _closer = Vector2.zero;

        Got = false;

        _velocity = _playerStats.PlayerVelocity * _dogVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Got)
        {
            Follow();
            _velocity = _playerStats.PlayerVelocity * _dogVelocity;
        }
        else
        {
            transform.position += transform.up * Time.deltaTime * 2;
            _playerStats.HasDog = false;
            Destroy(gameObject, 3);
        }
    }

    private Vector3 Closer()
    {
        _distanceMin = float.MaxValue;
        _aux = 0;

        _targets = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject target in _targets)
        {
            _aux = Vector3.Distance(transform.position, target.transform.position);

            if (_aux < _distanceMin)
            {
                _distanceMin = _aux;
                _closer = target.transform.position;
            }
        }

        return _closer;
    }

    private void Follow()
    {

         _dir = Closer();

        _dir = _dir - transform.position;

        _dir = _dir.normalized;
        _dir.z = 0;

        transform.position += _dir * Time.deltaTime * _velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Target"))
        {
            Got = true;

        }

            
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Target"))
        {
            Got = true;

        }

    }
}
