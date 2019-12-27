using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreUI = null;
    [SerializeField] private GameManager manager = null;

    private int score;


    private void Awake() 
    {
        if (score != 0) score = 0;
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
        ++score;
        scoreUI.text = score.ToString();

        manager.ResetGame();
    }

}
