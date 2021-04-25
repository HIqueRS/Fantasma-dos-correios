using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroyLayout : MonoBehaviour
{
    [SerializeField] private GameObject _layout;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(_layout, 2);
    }
}
