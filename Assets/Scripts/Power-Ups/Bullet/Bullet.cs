using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 450.5f;
    protected AnimationCurve animaCurve;
    [SerializeField] protected Rigidbody2D rbBullet { get; set; }
    public Sprite spriteRenderer;
    protected BrickBehaviour brickProper;

    private void Awake()
    {
        rbBullet = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        UpBullet();
    }

    protected void UpBullet()
    {
        Vector2 bullet = Vector2.zero;
        bullet.x = 0;
        bullet.y = 1f;
        rbBullet.AddForce(((speed * 2) * Time.deltaTime * bullet.normalized)*Vector2.up);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Destroy(this.gameObject);
        }
    }
}
