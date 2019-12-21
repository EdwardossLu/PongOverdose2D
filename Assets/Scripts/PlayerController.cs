using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private EnemyController enemy = null;
    //[SerializeField] private GameManager manager = null;


    private void Update() 
    {
        Movement();
    }

    private void Movement() 
    {
        float moveVert = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(Vector2.up * moveVert);

        Vector2 clamPos = transform.position;
        clamPos.y = Mathf.Clamp(clamPos.y, -4.3f, 4.3f);
        transform.position = clamPos;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        enemy.MovementSpeed();
    }

}
