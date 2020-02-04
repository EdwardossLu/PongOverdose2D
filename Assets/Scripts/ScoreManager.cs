using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI = null;
    [SerializeField] private GameManager manager = null;

    private int _score;

    // If the score isn't zero, change it to zero.
    private void Awake() 
    {
        if (_score != 0) _score = 0;
    }

    // Display the score to zero when the game starts.
    private void Start() 
    {
        scoreUI.text = _score.ToString();
    }

    // Score one point when the ball hits this collider.
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ball"))
            PointScored();
    }

    private void PointScored()
    {
        ++_score;
        scoreUI.text = _score.ToString();

        manager.ResetGame();                                            // Call this to reset the game.
    }
}
