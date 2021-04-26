using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaa");
        if (collision.gameObject.CompareTag("Dog"))
        {
            collision.gameObject.GetComponent<Dog>().Got = true;

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("a");
        if (collision.gameObject.CompareTag("Dog"))
        {
            collision.gameObject.GetComponent<Dog>().Got = true;

            Destroy(gameObject);
        }
    }
}
