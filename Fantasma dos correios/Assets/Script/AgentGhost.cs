using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine.SceneManagement;

public class AgentGhost : Agent
{
    //ML AGENTS
    private RayPerceptionSensorComponent2D _rayPerception;
    private Rigidbody2D _rb2D;

    private bool _firstTime;

    [SerializeField] private GameObject[] _letter;
    [SerializeField] private PlayerStats _playerStats;
    private Vector3 _shootDirection;
    private GameObject _aux;
    private int _letterID;

    [SerializeField] private UnityEvent _changeLetter;
    [SerializeField] private UnityEvent _shoot;

    //PLAYER MOVEMENT

    [SerializeField] private float _rotationVelocity = 250.0f;
    [SerializeField] private float _topVelocity = 2.5f;
    [SerializeField] private float _acceleration = 1f;
    private float _velocity;

    [SerializeField] private AudioSource _collisionAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rayPerception = GetComponent<RayPerceptionSensorComponent2D>();
        _rb2D = GetComponent<Rigidbody2D>();
        _letterID = 3;
        _playerStats.Letters = 5;
        _playerStats.HasDog = false;
        _playerStats.pause = false;

        _firstTime = true;
    }

    public override void OnEpisodeBegin()
    {
        if (!_firstTime)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            _firstTime = false;
        }
        
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(_rb2D.velocity.normalized);
        sensor.AddObservation(_rb2D.rotation);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        int movementWS; //nada(0), W(1), S(2)
        int movementAD; //nada(0), A(1), D(2)
        movementWS = actionBuffers.DiscreteActions[0];
        movementAD = actionBuffers.DiscreteActions[1];

        if (movementWS == 1 && movementAD == 0) //W only
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 180);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (movementWS == 2 && movementAD == 0) //S only
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (movementWS == 0 && movementAD == 1) //A only
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 270);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (movementWS == 0 && movementAD == 2) //D only
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 90);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (movementWS == 1 && movementAD == 2) //W AND D
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 135);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (movementWS == 1 && movementAD == 1) //W AND A
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 225);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (movementWS == 2 && movementAD == 1) //S AND A
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 315);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * _rotationVelocity);
        }
        if (movementWS == 2 && movementAD == 1) //S AND D
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
        _topVelocity += 0.05f * Time.deltaTime;

        _playerStats.PlayerVelocity = _topVelocity;

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        if (Input.GetKey(KeyCode.W))
        {
            discreteActionsOut[0] = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            discreteActionsOut[0] = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            discreteActionsOut[1] = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            discreteActionsOut[1] = 2;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            discreteActionsOut[0] = 1;
            discreteActionsOut[1] = 2;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            discreteActionsOut[0] = 1;
            discreteActionsOut[1] = 1;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            discreteActionsOut[0] = 2;
            discreteActionsOut[1] = 2;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            discreteActionsOut[0] = 2;
            discreteActionsOut[1] = 1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Rot" + _rb2D.rotation);
        //Input_movement();

        if (Input.GetMouseButtonDown(0))
        {
            if (_playerStats.Letters > 0)
            {
                _shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                _shootDirection.z = 0;

                _aux = Instantiate(_letter[_letterID % 3], transform.position, Quaternion.identity);
                _aux.GetComponent<LetterBehaviour>().Direction = _shootDirection.normalized;
                _aux.GetComponent<LetterBehaviour>().LetterID = _letterID % 3;

                _playerStats.Letters--;

                _shoot.Invoke();
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            _letterID++;
            _changeLetter.Invoke();
        }
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
        _topVelocity += 0.05f * Time.deltaTime;

        _playerStats.PlayerVelocity = _topVelocity;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Dog"))
        {
            AddReward(-0.5f);
            _velocity = 0;
            collision.gameObject.GetComponent<Dog>().Got = true;
            _playerStats.Letters--;
            _playerStats.HasDog = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AddReward(-0.5f);
        }
        if (collision.gameObject.CompareTag("End"))
        {
            AddReward(-1f);
            //EndEpisode();
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
