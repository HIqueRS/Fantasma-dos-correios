using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviour : MonoBehaviour
{

    [HideInInspector] public Vector3 Direction;
    [SerializeField] private float _velocity = 5f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * _velocity * Time.deltaTime;
    }
}
