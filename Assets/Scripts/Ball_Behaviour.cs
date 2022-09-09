using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Behaviour : MonoBehaviour
{
    public Rigidbody2D rigidbodyBall { get; set; }
    [SerializeField] protected float ballSpeed = 500f;
    public Vector2 initialVelocity;
    public bool isMoving;

    private void Awake()
    {
        rigidbodyBall = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //delay del calculo de la pelota
        //Invoke(nameof(SetRandomTrajectory), 1f);
        SetRandomTrajectory();
    }

    private void SetRandomTrajectory()
    {
        Vector2 forceball = Vector2.zero;
        forceball.x = Random.Range(-1f, 1f);
        forceball.y = -1f;

        rigidbodyBall.AddForce(forceball.normalized * ballSpeed * Time.deltaTime);
        //initialVelocity = rigidbodyBall.velocity;
    }

    private void Update()
    {
        if (!isMoving)
        {
            if (rigidbodyBall.velocity.x > 0 || rigidbodyBall.velocity.y > 0)
            {
                isMoving = true;
            }
        }
    }

    private void FixedUpdate()
    {
        //tracking the speed
        //Debug.Log("The ball console: Transform -> " + gameObject.transform.position + " and the velocity: " + rigidbodyBall.velocity); 
    }
}
