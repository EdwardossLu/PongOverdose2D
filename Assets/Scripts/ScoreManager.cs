using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreUI = null;
    [SerializeField] private GameManager manager = null;

    private int _score;


    private void Awake() 
    {
        if (_score != 0) _score = 0;
    }

    private void Start() 
    {
        scoreUI.text = "0";
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            PointScored();
        }
    }

    private void PointScored()
    {
        ++_score;
        scoreUI.text = _score.ToString();

        manager.ResetGame();
    }

}
