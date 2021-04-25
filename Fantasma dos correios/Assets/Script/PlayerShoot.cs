using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] _letter;
    private Vector3 _shootDirection;
    private GameObject _aux;
    private int _

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            _shootDirection.z = 0;

            _aux = GameObject.Instantiate(_letter,transform.position,Quaternion.identity);
            _aux.GetComponent<LetterBehaviour>().Direction = _shootDirection.normalized;
        }

    }
}
