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
    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private float _timeBonus;

    private bool _isFinished;

    private int _dogFleeChance;
   

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

                    _getLetter.Invoke();
                    _playerStats.Time += _timeBonus;
                    _playerStats.Points += _timeBonus*10f;

                    _isFinished = true;

                    _dogFleeChance = Random.Range(0, 100);

                    if(_dogFleeChance < 25)
                    {
                        Instantiate<GameObject>(Resources.Load<GameObject>("DOG"), this.transform.position, Quaternion.identity);
                    }
                }
                else
                {
                    GameObject.Destroy(collision.gameObject);
                }
            }
        }
        
    }
}
