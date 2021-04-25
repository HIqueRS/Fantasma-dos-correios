using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    
    private Vector3 _mousePos;
    private int _mouseID;
    [SerializeField] private Sprite[] _mouseSprites;
    [SerializeField] private SpriteRenderer _mouseSprite;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        _mouseID = 3;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = -1;
        gameObject.transform.position = _mousePos;
    }

    public void MouseChange()
    {
        _mouseID++;
        _mouseSprite.sprite = _mouseSprites[_mouseID % 3];
    }
}
