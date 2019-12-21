using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private GameManager manager = null;

    private bool _gameStatus = false;

    private Rigidbody2D _rb;


    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();

        _gameStatus = false;
    }

    private void Start() 
    {
        transform.position = Vector3.zero;
    }

    private void Update() 
    {
        if (Input.GetKeyUp(KeyCode.Space) && _gameStatus == false)
        {
            int randDirection = Random.Range(1, 4);
            MoveAngle(randDirection);
            manager.PlayHitSound();
            _gameStatus = true;
        }
    }

    public void ResetBallPosition()
    {
        _rb.Sleep();
        transform.position = Vector3.zero;
        _gameStatus = false;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Finish"))
            manager.PlayScoreSound();
        else
            manager.PlayHitSound();
    }

    private void MoveAngle( int value)
    {

        //TODO: Use Random.Range instead of this.
        switch(value)
        {
            case 1:
                _rb.AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);
                break;

            case 2:
                _rb.AddForce(new Vector2(-5f, -5f), ForceMode2D.Impulse);
                break;

            case 3:
                _rb.AddForce(new Vector2(-5f, 5f), ForceMode2D.Impulse);
                break;

            case 4:
                _rb.AddForce(new Vector2(5f, -5f), ForceMode2D.Impulse);
                break;
        }
    }

}
