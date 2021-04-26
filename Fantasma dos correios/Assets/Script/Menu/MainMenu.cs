using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        _music.Pause();
    }

    public void Back()
    {
        _music.UnPause();
    }
}
