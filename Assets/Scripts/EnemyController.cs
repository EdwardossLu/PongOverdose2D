using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform ball = null;

    private float _randomDistance = 1f;
    

    private void Update() 
    {
        SetMovement();
    }

    // Move towards the balls position on the Y axis.
    private void SetMovement()
    {
        Vector3 position = transform.position;
        Vector2 clamPos = position;

        clamPos.y = Mathf.Lerp(position.y, ball.position.y, _randomDistance);   // Lerp to the balls position on the Y axis.
        clamPos.y = Mathf.Clamp(clamPos.y, -3.9f, 3.9f);                                        // Clamp the distance of the paddle.

        position = clamPos;
        transform.position = position;
    }

    // Change the speed of "SELF" everytime the player hits the ball.
    public void MovementSpeed()
    {
        _randomDistance = Random.Range(0.01f, 0.1f);
    }
}
