using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotationVelocity = 250.0f;
    [SerializeField] private float _Velocity = 2.5f;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Input_movement();
    }

    private void Input_movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 90);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 270);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 180);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }

        transform.position += transform.right * Time.deltaTime * _Velocity;
    }
}
