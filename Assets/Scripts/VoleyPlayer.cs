using UnityEngine;
using UnityEngine.InputSystem;

public class VoleyPlayer : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 10f; // Un valor de 10-12 suele sentirse mejor
    public float jumpForce = 12f;

    [Header("Controls (New Input System)")]
    public Key leftKey;
    public Key rightKey;
    public Key jumpKey;

    [Header("Limits")]
    public float minX; 
    public float maxX;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        // 1. Verificación de seguridad (Evita el ArgumentOutOfRangeException)
        if (Keyboard.current == null) return;

        float move = 0;

        // Validamos que las teclas no sean 'None' antes de leerlas
        if (leftKey != Key.None && Keyboard.current[leftKey].isPressed) move = -1;
        if (rightKey != Key.None && Keyboard.current[rightKey].isPressed) move = 1;

        // 2. Control de Movimiento Lateral
        // Si estamos en el límite, bloqueamos la velocidad en esa dirección
        if ((transform.position.x <= minX && move < 0) || (transform.position.x >= maxX && move > 0))
        {
            move = 0;
        }

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // 3. Salto
        if (jumpKey != Key.None && Keyboard.current[jumpKey].wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        // 4. Clamping de seguridad (Solo si la física falla por un golpe fuerte)
        if (transform.position.x < minX || transform.position.x > maxX)
        {
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Frenamos el impacto
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) isGrounded = false;
    }
}