using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D paddleRB { get; private set; }
    [SerializeField] protected Vector2 dirctionsIn { get; private set; }
    [SerializeField] protected float paddleSpeed = 175000f;
    [SerializeField] protected float maxBounceAngle = 65f;
    [SerializeField] protected float speedAdjuster;

    private void Awake()
    {
        paddleRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dirctionsIn = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            dirctionsIn = Vector2.right;
        }
        else
        {
            dirctionsIn = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if(dirctionsIn != Vector2.zero)
        {
            paddleRB.AddForce(dirctionsIn * paddleSpeed * Time.deltaTime); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball_Behaviour ball = collision.gameObject.GetComponent<Ball_Behaviour>();

        if (ball != null)
        {
            BouncePaddleInteract(collision, ball);
        }
    }

    private void BouncePaddleInteract(Collision2D collision, Ball_Behaviour ball)
    {
        Vector3 paddlePosition = transform.position;
        Vector2 contactPoint = collision.GetContact(0).point;

        float offsetPaddle = paddlePosition.x - contactPoint.x;
        float width = collision.otherCollider.bounds.size.x / 2;

        float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbodyBall.velocity);
        float bounceAngle = (offsetPaddle / width) * maxBounceAngle;

        float newAngle = Mathf.Clamp(currentAngle + bounceAngle, - maxBounceAngle, maxBounceAngle);

        Quaternion rotationAxi = Quaternion.AngleAxis(newAngle, Vector3.forward);
        ball.rigidbodyBall.velocity = rotationAxi * Vector2.up * ball.rigidbodyBall.velocity.magnitude * speedAdjuster;
    }
}
