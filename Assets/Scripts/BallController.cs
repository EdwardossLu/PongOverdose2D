using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameManager manager = null;

    private bool _gameStatus = false;                                   // Checks if the player is playing the game or not.

    private Rigidbody2D _rb;


    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();

        _gameStatus = false;
    }

    private void Start() 
    {
        // Set the balls position to the middle of the map.
        transform.position = Vector3.zero;
    }

    private void Update() 
    {
        // Start the game when the player presses the space bar, but check if the game isn't already playing.
        if (Input.GetKeyUp(KeyCode.Space) && _gameStatus == false || Input.GetMouseButtonUp(0) && _gameStatus == false)
        {
            int randDirection = Random.Range(1, 4);                 // Choose between the 4 direction from the MoveAngle function.
            MoveAngle(randDirection);                                       
            manager.PlaySound(0);                                            // Play sound based on the array from the GameManager Script.
            _gameStatus = true;
        }
    }

    // Reset the game.
    public void ResetBallPosition()
    {
        _rb.Sleep();                                                                      // Reset the RigidBody so the ball doesn't move.
        transform.position = Vector3.zero;                              // Set the balls position to the middle of the map.
        _gameStatus = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        manager.PlaySound(other.gameObject.CompareTag("Finish") ? 1 : 0);
    }

    // Move the ball to the desired location.
    private void MoveAngle( int value )
    {
        //TODO: Use Random.Range instead. 
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
