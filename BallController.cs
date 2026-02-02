using UnityEngine;

public class EasyBallController : MonoBehaviour
{
    public float moveSpeed = 10;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("EasyBallController gestartet!");
    }

    void Update()
    {
        // Prüfen ob A oder D gedrückt wird
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A gedrückt - bewege nach links");
            rb.AddForce(moveSpeed, 0,0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D gedrückt - bewege nach rechts");
            rb.AddForce(moveSpeed, 0, 0);
        }
    }
}