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

    private void SetMovement()
    {
        Vector2 clamPos = transform.position;

        clamPos.y = Mathf.Lerp(transform.position.y, ball.position.y, _randomDistance);
        clamPos.y = Mathf.Clamp(clamPos.y, -3.9f, 3.9f);

        transform.position = clamPos;                   
    }

    // Change the speed everytime the player hits the ball.
    public void MovementSpeed()
    {
        _randomDistance = Random.Range(0.01f, 0.1f);
    }

}
