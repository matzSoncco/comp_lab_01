using UnityEngine;

public class VoleyBot : MonoBehaviour
{
    public Transform ball;
    public float speed = 6f;
    public float jumpForce = 10f;
    public float minX = 0.7f;
    public float maxX = 11f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        float distanceX = ball.position.x - transform.position.x;

        if (ball.position.x > 0 && Mathf.Abs(distanceX) > 0.2f) 
        {
            float direction = (distanceX > 0) ? 1 : -1;
            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        float dist = Vector2.Distance(transform.position, ball.position);
        if (isGrounded && dist < 3f && ball.position.y > transform.position.y)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor")) isGrounded = true;
    }
}