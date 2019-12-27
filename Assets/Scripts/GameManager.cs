using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI[] text = new TextMeshProUGUI[3];
    /*
        [TEXT]
        0 = Start
        1 = Reset
        2 = Pause
    */

    [SerializeField] private AudioClip[] audioClips = null;
    /*
        [SFX]
        0 = Hit
        1 = Score
        2 = Reset
    */

    [SerializeField] private BallController ball = null;

    private AudioSource _audioSource;
    private bool _paused = false;


    private void Awake() 
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start() 
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].gameObject.SetActive(true);
        }   
    }

    private void Update() 
    {
        if (Input.GetKeyUp(KeyCode.Space))
            DisplayText(false);

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            _paused = !_paused;
            PauseGame(_paused);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            ResetGame();
            PlaySound(2);
        }
    }

    public void ResetGame()
    {
        DisplayText(true);
        ball.ResetBallPosition();
    }

    public void DisplayText( bool activation )
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].gameObject.SetActive(activation);
        }
    }

    public void PlaySound( int sound )
    {
        _audioSource.clip = audioClips[sound];
        _audioSource.Play();
    }

    private void PauseGame( bool pause )
    {
        if (pause)
            Time.timeScale = 0;
        else if (!pause)
            Time.timeScale = 1;
    }

}
