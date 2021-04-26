using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dog"))
        {
            collision.gameObject.GetComponent<Dog>().Got = true;

            Destroy(gameObject);
        }
    }
}
