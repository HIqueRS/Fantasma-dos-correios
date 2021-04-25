using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostReceiver : MonoBehaviour
{
    private int _letterRequestID;
    [SerializeField] private Sprite[] _letterRequestSprites;
    [SerializeField] private SpriteRenderer _letterRequestGameobj;
    [SerializeField] private UnityEvent _getLetter;

    private bool _isFinished;
   

    // Start is called before the first frame update
    void Start()
    {
        _isFinished = false;
        _letterRequestID = Random.Range(0, 3);
        
        _letterRequestGameobj.sprite = _letterRequestSprites[_letterRequestID];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!_isFinished)
        {
            if (collision.tag == "Letter")
            {
                if (_letterRequestID == collision.gameObject.GetComponent<LetterBehaviour>().LetterID)
                {
                    GameObject.Destroy(collision.gameObject);

                    _getLetter.Invoke();//pq tem q aumentar o tempo tbm

                    _isFinished = true;
                }
            }
        }
        
    }
}
