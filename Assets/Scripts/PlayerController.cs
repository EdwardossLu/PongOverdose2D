using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private EnemyController enemy = null;


    private void Update() 
    {
        Movement();
    }

    // Move the character based on the players input.
    private void Movement() 
    {
        float moveVert = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Transform transform1;
        (transform1 = transform).Translate(Vector2.up * moveVert);

        Vector2 clamPos = transform1.position;
        clamPos.y = Mathf.Clamp(clamPos.y, -3.9f, 3.9f);
        transform.position = clamPos;
    }

    // Check the movement speed of the enemy each time the player hits the ball.
    private void OnCollisionEnter2D(Collision2D other) 
    {
        enemy.MovementSpeed();
    }
}
