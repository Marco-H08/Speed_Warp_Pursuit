using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    // Geschwindigkeit der Bewegung
    public float speed = 700f;

    private Rigidbody rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input vom neuen Input System lesen
        moveInput = 0f;

        if (Keyboard.current.aKey.isPressed)
        {
            moveInput = -1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            moveInput = 1f;
        }
    }

    void FixedUpdate()
    {
        // Kraft anwenden basierend auf Input
        rb.AddForce(moveInput * speed * Time.deltaTime, 0, 0);
    }
}