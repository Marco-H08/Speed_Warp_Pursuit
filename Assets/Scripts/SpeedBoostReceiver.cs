using UnityEngine;

public class SpeedBoostReceiver : MonoBehaviour
{
    [Header("Boost Einstellungen")]
    public float boostKraft = 1f;
    public Vector3 boostRichtung = Vector3.forward;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("SpeedBoost")) return;

        rb.AddForce(boostRichtung.normalized * boostKraft, ForceMode.Impulse);
    }
}