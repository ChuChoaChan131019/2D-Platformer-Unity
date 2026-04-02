using UnityEngine;
public partial class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 5f;
    private Vector3 startPoint;
    private bool movingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPoint = transform.position; 
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(movingRight ? moveSpeed : -moveSpeed, rb.linearVelocity.y);
        float distanceTravelled = Vector2.Distance(startPoint, transform.position);
        if (distanceTravelled >= patrolDistance)
        {
            Flip();
            startPoint = transform.position; 
        }
    }
    void Flip()
    {
        movingRight = !movingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}