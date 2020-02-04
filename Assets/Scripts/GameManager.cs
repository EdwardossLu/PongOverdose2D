using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] text = new TextMeshProUGUI[3]; /*
        [TEXT]
        0 = Start
        1 = Reset
        2 = Pause */

    [SerializeField] private AudioClip[] audioClips = null; /*
        [SFX]
        0 = Hit
        1 = Score
        2 = Reset */

    [SerializeField] private BallController ball = null;

    private AudioSource _audioSource;
    private bool _paused = false;


    private void Awake() 
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        DisplayText(true);
    }

    private void Update() 
    {
        if (Input.GetKeyUp(KeyCode.Space))
            DisplayText(false);

        // 
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            _paused = !_paused;
            PauseGame(_paused);
        }

        if (!Input.GetKeyUp(KeyCode.R)) return;
        ResetGame();
        PlaySound(2);
    }

    public void ResetGame()
    {
        DisplayText(true);
        ball.ResetBallPosition();                                                   // Called this script to reset the ball.
    }

    // Toggle the visibility of each text.
    private void DisplayText( bool activation )
    {
        foreach (TextMeshProUGUI tmp in text)
        {
            tmp.gameObject.SetActive(activation);
        }
    }

    // Choose which sound to play from the array.
    public void PlaySound( int sound )
    {
        _audioSource.clip = audioClips[sound];
        _audioSource.Play();
    }

    // Pause the game when the esc button is pressed.
    private static void PauseGame( bool pause )
    {
        Time.timeScale = pause ? 0 : 1;
    }
}
