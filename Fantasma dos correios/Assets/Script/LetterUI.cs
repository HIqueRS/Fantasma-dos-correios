using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterUI : MonoBehaviour
{

    [SerializeField] private Sprite[] _lettersSprite;
    [SerializeField] private Image _letterUIImage;

    private int _letterID;

    // Start is called before the first frame update
    private void Start()
    {
        _letterID = 3;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void ChangeLetterUI()
    {
        _letterID++;
        _letterUIImage.sprite = _lettersSprite[_letterID % 3];

        
    }
}
