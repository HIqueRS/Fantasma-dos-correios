using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _pointsText;
    [SerializeField] private PlayerStats _playerStats;
    
    void Start()
    {
        _pointsText.text = string.Concat("Points: ", (int)_playerStats.Points);
    }

    public void ChangeScene(int n)
    {
        SceneManager.LoadScene(n);
    }
}
