using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteView { get; private set; }
    [SerializeField] protected int health { get; private set; }
    [SerializeField] protected Color[] state;
    [SerializeField] protected bool unbreakeble;

    private void Awake()
    {
        spriteView = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (!unbreakeble)
        {
            health = state.Length;
            spriteView.color = state[health - 1];
        }
    }

    public void HitBlock()
    {
        if(unbreakeble) 
            return;

        health--;

        if(health <= 0)
            gameObject.SetActive(false);
        else
            spriteView.color = state[health - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Bullet")
        {
            HitBlock();
        }
    }
}
