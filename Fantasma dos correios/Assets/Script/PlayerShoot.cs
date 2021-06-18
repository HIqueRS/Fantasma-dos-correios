using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] public GameObject[] _letter;
    [SerializeField] public PlayerStats _playerStats;
    private Vector3 _shootDirection;
    public GameObject _aux;
    public int _letterID;

    [SerializeField] public UnityEvent _changeLetter;
    [SerializeField] public UnityEvent _shoot;

    private Vector3 _dir;

    public int _a;
    public int _nLetter;



    private void Start()
    {

        _letter = new GameObject[3];

        _letter[0] = Resources.Load<GameObject>("Letter/Letter1");
        _letter[1] = Resources.Load<GameObject>("Letter/Letter2");
        _letter[2] = Resources.Load<GameObject>("Letter/Letter3");

        _playerStats = Resources.Load<PlayerStats>("Scriptable/PlayerStats");

        _a = 0;
        _letterID = 3;
        _playerStats.Letters = 5;

        _nLetter = _playerStats.Letters;

    }

    public void Initialize()
    {
        _letter = new GameObject[3];

        _letter[0] = Resources.Load<GameObject>("Letter/Letter1");
        _letter[1] = Resources.Load<GameObject>("Letter/Letter2");
        _letter[2] = Resources.Load<GameObject>("Letter/Letter3");

        _playerStats = Resources.Load<PlayerStats>("Scriptable/PlayerStats");

        _a = 0;
        _letterID = 3;
        _playerStats.Letters = 5;

        _nLetter = _playerStats.Letters;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _shootDirection = CalcDirection();
            Shoot(_shootDirection);
        }
        if(Input.GetMouseButtonDown(1))
        {
            ChangeLetter();
        }
    }

    public void Shoot(Vector3 dir)
    {
        if (_playerStats.Letters > 0)
        {
            InitiateLetter(dir);

            _playerStats.Letters--;

            _shoot.Invoke();
        }
    }

    public void ChangeLetter()
    {
        _letterID++;
        _changeLetter.Invoke();
    }

    private Vector3 CalcDirection()
    {

        _dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _dir.z = 0;
        _dir = _dir.normalized;

        return _dir;
    }

    private void InitiateLetter(Vector3 dir)
    {

        _aux = Instantiate(_letter[_letterID % 3], transform.position, Quaternion.identity);
        _aux.GetComponent<LetterBehaviour>().Direction = dir;
        _aux.GetComponent<LetterBehaviour>().LetterID = _letterID % 3;

    }
}
