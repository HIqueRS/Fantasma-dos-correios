using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotationVelocity = 250.0f;
    [SerializeField] private float _topVelocity = 2.5f;
    [SerializeField] private float _acceleration = 1f;
    private float _velocity;

    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private AudioSource _collisionAudioSource;


    private void Update()
    {
        Input_movement();
    }

    private void Input_movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 180);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 270);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 90);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 135);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 225);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 315);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 45);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }

        if (_velocity < _topVelocity)
        {
            _velocity += Time.deltaTime * _acceleration;
        }

        transform.position += -transform.up * Time.deltaTime * _velocity;

        _acceleration += 0.0125f * Time.deltaTime;
        _topVelocity +=  0.05f * Time.deltaTime;

        _playerStats.PlayerVelocity = _topVelocity; 
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Dog"))
        {
            _velocity = 0;
            collision.gameObject.GetComponent<Dog>().Got = true;
            _playerStats.Letters--;
        }
        if (collision.gameObject.CompareTag("End"))
        {
            _playerStats.Time = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        _velocity = 0;

        _collisionAudioSource.Play();


    }
}
