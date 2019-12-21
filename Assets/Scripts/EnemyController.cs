using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private Transform ball = null;
    //[SerializeField] private GameManager manager = null;

    private float _randomDistance = 1f;
    

    private void Update() 
    {
        SetMovement();
    }

    private void SetMovement()
    {
        Vector2 clamPos = transform.position;

        clamPos.y = Mathf.Lerp(transform.position.y, ball.position.y, _randomDistance);
        clamPos.y = Mathf.Clamp(clamPos.y, -4.3f, 4.3f);

        transform.position = clamPos;                   
    }

    public void MovementSpeed()
    {
        _randomDistance = Random.Range(0.01f, 0.1f);
    }

}
